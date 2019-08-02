using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Threading;

using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

using SwApiWrapper;


namespace sw_BOM_Scan
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class BomScan : Form
	{
		
		private String statLabel;
		private Thread thdScan;
		
		private DbConnection cnn;
		private DbCommand cmdCheckFiles;
		private DbCommand cmdInsertConfigs;
		private DbCommand cmdCheckConfigs;
		private DbCommand cmdShowChildren;
		private DbCommand cmdInsertAdjacency;
		private DbCommand cmdUpdateAdjacency;
		private DbCommand cmdGetAdjCount;
		private DbCommand cmdCheckAdjacency;

        private SwModelWrapper swMod;

        public BomScan(SwModelWrapper swModel)
		{
			InitializeComponent();
            swMod = swModel;
        }

        void MainFormLoad(object sender, EventArgs e)
		{
            txtActiveDoc.Text = swMod.PathName;
            txtActiveConfig.Text = swMod.ConfigName;
        }

		void CmdTargetFileClick(object sender, EventArgs e) {
			
			String fileName;
			
			saveFileDialog1.FileName = null;		// Clear old file names
			saveFileDialog1.ShowDialog();			// Display the dialog
			fileName = saveFileDialog1.FileName;	// Get filename
			
			if ( File.Exists(fileName) ) {

                AppendOverwriteBox appendBox = new AppendOverwriteBox();
                DialogResult dr = appendBox.ShowDialog(this);

                if (dr == DialogResult.Yes) {
                    // Yes = Append
					// Append data to specified file
					InitDB(fileName);
				} else if (dr == DialogResult.No) {
                    // No = Overwrite
					// try to delete the file
					try {
						File.Delete(fileName);
					} catch (Exception ex) {
						MessageBox.Show("Could not overwrite " + fileName + ".\n" + ex.ToString(),
							"Output File Error",
							MessageBoxButtons.OK);
						return;
					}
					// Open a new file
					InitDB(fileName);
				} else {
					// Dialog was apparently closed
					return;
				}
				
			} else {
				// File does not exist, so make a new one
				InitDB(fileName);
			}
			
			txtTargetFile.Text = fileName;
			this.txtStatus.Text = "Output file ready for scan";
			
		}

		void CmdScanClick(object sender, EventArgs e)
		{
			
			// check for lightweight components
			if (swMod.LiteCompCount > 0) {
				DialogResult dr = MessageBox.Show("All lightweight components will be fully resolved.  Continue?",
				                                  "Lightweight Components",
				                                  MessageBoxButtons.YesNo);
				if (dr == DialogResult.Yes) {
					this.txtStatus.Text = "Resolving lightweight components...";
					swMod.ResolveAllComps();
					this.txtStatus.Text = "Proceding with scan";
				} else {
					this.txtStatus.Text = "Some components still lightweight";
					return;
				}
			}
			
			// create and start the scanning thread
			this.thdScan = new Thread(new ThreadStart(ScanControl));
			thdScan.Start();
			
			// change button config
			this.cmdScan.Visible = false;
			//this.cmdCancel.Enabled = true;
			
		}

		void CmdCancelClick(object sender, EventArgs e)
		{
			
			// stop scanning thread
			thdScan.Interrupt();
			
			// change button config
			this.cmdScan.Visible = true;
			//this.cmdCancel.Enabled = false;
			
		}
		
		
		
		void ScanControl() {
			
			MethodInvoker WriteLabelDelegate = new MethodInvoker(WriteLabel);
			
			try{
				DoScan();
			} catch(ThreadInterruptedException e) {
				this.statLabel = "Interupted \n "+e.ToString();
				Invoke(WriteLabelDelegate);
				return;
			}
			this.statLabel = "Scanning Completed Successfully";
			Invoke(WriteLabelDelegate);
			
		}
		
		
		
		ThreadInterruptedException DoScan() {
			
			try{
				Thread.Sleep(0);
			} catch(ThreadInterruptedException e) {
				return(e);
			}
			
			
			// Set the initial BOM level
			int intLevel = 0;
			
			// Find the root node.  This is only done ONCE for the entire assembly structure
			SwComponentWrapper swRootComp = swMod.GetRootComponentWrapper();
			
			// Get name of configuration containing properties
			string strMainConfig = swMod.ConfigName;
			string strMainPath = swMod.PathName;
		
			// write custom properties for main model
			DbWriteConfig(strMainPath, strMainConfig, swModel: swMod);
			
			// Recursively traverse the assembly
			if ( swRootComp != null ) {
				TraverseAssy(swRootComp, strMainPath, strMainConfig, intLevel);
			}
			
			return(null);
			
		}

		void WriteLabel() {
			this.txtStatus.Text = this.statLabel.ToString();
		}

		ThreadInterruptedException TraverseAssy(SwComponentWrapper swParentComp, string strParentPath, string strParentConfig, int intStartLevel) {
			
			// Check for cancel button
			try{
				Thread.Sleep(0);
			} catch(ThreadInterruptedException e) {
				return(e);
			}
			
			// If no component, then exit
			if (swParentComp == null) {
				return(null);
			}
			
			// Prepare to write status label
			MethodInvoker WriteLabelDelegate = new MethodInvoker(WriteLabel);
			
			// increment BOM level
			int intNextLevel = intStartLevel + 1;
			
			// Get the list of children (if any)
			List<SwComponentWrapper> children = swParentComp.GetComponents();

			// die if array contains no children
			if (children.Count == 0) {
				return(null);
			}
			
			// get children for each Child in this subassembly
			foreach ( SwComponentWrapper swChildComp in children ) {
				
				// Skip suppressed/excluded parts
				if (!swChildComp.Suppressed && !swChildComp.ExcludeFromBOM ) {
					
					// Get the model doc and info of the component
					string strChildPath = swChildComp.PathName;
					string strChildConfig = swChildComp.ConfigName;
					
					// write status to form label
					string strModelName = swChildComp.FileName;
					this.statLabel = strModelName;
					Invoke(WriteLabelDelegate);

                    // Write custom properties for this config of this child 
                    DbWriteConfig(strChildPath, strChildConfig, swComponent: swChildComp);
					
					// Write BOM adjacency
					DbWriteAdjacency(strParentPath, strParentConfig, strChildPath, strChildConfig);
					
					// If this component not already traversed
					cmdCheckAdjacency.Parameters["@PName"].Value = strChildPath;
					cmdCheckAdjacency.Parameters["@PConfig"].Value = strChildConfig;
					long intExists = Convert.ToInt64(cmdCheckAdjacency.ExecuteScalar());
					if ( intExists==0 ) {
						
						// If components not hidden from BOM
						cmdShowChildren.Parameters["@filename"].Value = strChildPath;
						cmdShowChildren.Parameters["@configname"].Value = strChildConfig;
						long intShow = Convert.ToInt64(cmdShowChildren.ExecuteScalar());
						if ( intShow!=0 ) {
							
							// Recurse into this child
							TraverseAssy(swChildComp, strChildPath, strChildConfig, intNextLevel);
							
						}
					}
					
				}
				
			}
			
			return(null);
			
		}

		void DbWriteConfig(string strPathName, string strConfigName, SwComponentWrapper swComponent = null, SwModelWrapper swModel = null) {
			
			// Return if the config properties have already been written
			cmdCheckConfigs.Parameters["@filename"].Value = strPathName;
			cmdCheckConfigs.Parameters["@configname"].Value = strConfigName;
			int intExists = Convert.ToInt32(cmdCheckConfigs.ExecuteScalar().ToString());
			if (intExists!=0)
				return;
			
			// Write status to form label
			MethodInvoker WriteLabelDelegate = new MethodInvoker(WriteLabel);
			string strModelName = this.statLabel;
			this.statLabel = strModelName + "(" + strConfigName + ")" + " ... getting custom properties";
			Invoke(WriteLabelDelegate);
			
			// Get model doc extension
            if (swModel == null)
                swModel = swComponent.GetModelWrapper(strConfigName);

            // Get custom properties
            SwCustProp props = swModel.GetCustProp(strConfigName, cbxGetImages.Checked);

            // Execute query
            foreach (KeyValuePair<string, object> prop in props.FieldValues)
                cmdInsertConfigs.Parameters["@" + prop.Key].Value = prop.Value;
            cmdInsertConfigs.ExecuteNonQuery();
			
		}


		
		void DbWriteAdjacency (string strParentPath, string strParentConfig, string strChildPath, string strChildConfig) {
			
			// Check for existing quantity
			long intCount = 1;
			cmdGetAdjCount.Parameters[0].Value = strParentPath;
			cmdGetAdjCount.Parameters[1].Value = strParentConfig;
			cmdGetAdjCount.Parameters[2].Value = strChildPath;
			cmdGetAdjCount.Parameters[3].Value = strChildConfig;
			object oTest = cmdGetAdjCount.ExecuteScalar();
			
			if (oTest==null) {
				
				cmdInsertAdjacency.Parameters[0].Value = strParentPath;
				cmdInsertAdjacency.Parameters[1].Value = strParentConfig;
				cmdInsertAdjacency.Parameters[2].Value = strChildPath;
				cmdInsertAdjacency.Parameters[3].Value = strChildConfig;
				cmdInsertAdjacency.Parameters[4].Value = intCount;
				cmdInsertAdjacency.ExecuteNonQuery();
				
			} else {
				
				intCount = Convert.ToInt64(oTest);
				intCount++;
				
				cmdUpdateAdjacency.Parameters[0].Value = intCount;
				cmdUpdateAdjacency.Parameters[1].Value = (string)strParentPath;
				cmdUpdateAdjacency.Parameters[2].Value = (string)strParentConfig;
				cmdUpdateAdjacency.Parameters[3].Value = (string)strChildPath;
				cmdUpdateAdjacency.Parameters[4].Value = (string)strChildConfig;
				
				cmdUpdateAdjacency.ExecuteNonQuery();
				
			}
			
			// Write status to form label
			MethodInvoker WriteLabelDelegate = new MethodInvoker(WriteLabel);
			string strModelName = this.statLabel;
			this.statLabel = strModelName + " ... writing adjacency (" + intCount.ToString() + ")";
			Invoke(WriteLabelDelegate);
			
		}
		
		
		
		void InitDB(string fileName) {

			cnn = new SQLiteConnection("Data Source=" + fileName);
			cnn.Open();
			
			DbCommand cmd = cnn.CreateCommand();
			
			cmd.CommandText = @"
				CREATE TABLE IF NOT EXISTS configs (
					filename TEXT,
 					configname TEXT,
					PlaceHoldFlag INTEGER,
					ShowChildren INTEGER,
 						
                    Image BLOB,
                    CuttingLengthOuter REAL,
                    CuttingLengthInner REAL,
                    CutOutCount REAL,
                    BendCount REAL,

					Uom TEXT,
					PartNum TEXT,
					Description TEXT,
					DesignedBy TEXT,
					DrawDate TEXT,
					Type TEXT,
					AltQty REAL,
					EngApproval TEXT,
					EngApprDate TEXT,
					MfgApproval TEXT,
					MfgApprDate TEXT,
					QaApproval TEXT,
					QaApprDate TEXT,
					PurchApproval TEXT,
					PurchApprDate TEXT,
					Material TEXT,
					Finish TEXT,
					Coating TEXT,
					Notes TEXT,
					Revision TEXT,
					Ecos TEXT,
					EcoRevs TEXT,
					Zone TEXT,
					EcoDescriptions TEXT,
					EcoDates TEXT,
					EcoChks TEXT,
					Catalog TEXT,

                    MaterialPn TEXT,
                    RouteTemplate TEXT,
                    PurchFlag INTEGER,

                    PRIMARY KEY (filename,configname)
						
				)
			";
			cmd.ExecuteNonQuery();
			
			cmd.CommandText = @"
				CREATE TABLE IF NOT EXISTS adjacency (
					pname TEXT,
					pconfig TEXT,
					cname TEXT,
					cconfig TEXT,
					adjcount INTEGER,
						
					PRIMARY KEY (pname,pconfig,cname,cconfig),
						
					FOREIGN KEY (pname) REFERENCES configs(filename),
					FOREIGN KEY (pconfig) REFERENCES configs(configname),
					FOREIGN KEY (cname) REFERENCES configs(filename),
					FOREIGN KEY (cconfig) REFERENCES configs(configname)
				)
			";
			cmd.ExecuteNonQuery();
			
			cmdCheckFiles = cnn.CreateCommand();
			cmdCheckFiles.CommandText = "SELECT COUNT(*) FROM Configs where filename like @filename";
			cmdCheckFiles.Parameters.Add(new SQLiteParameter("@filename"));
			
			cmdCheckConfigs = cnn.CreateCommand();
			cmdCheckConfigs.CommandText = "SELECT COUNT(*) FROM Configs where filename like @filename and configname like @configname";
			cmdCheckConfigs.Parameters.Add(new SQLiteParameter("@filename"));
			cmdCheckConfigs.Parameters.Add(new SQLiteParameter("@configname"));
			
			cmdShowChildren = cnn.CreateCommand();
			cmdShowChildren.CommandText = "SELECT ShowChildren FROM Configs where filename like @filename and configname like @configname";
			cmdShowChildren.Parameters.Add(new SQLiteParameter("@filename"));
			cmdShowChildren.Parameters.Add(new SQLiteParameter("@configname"));

            SwCustProp tempProp = new SwCustProp();
            string strFields = String.Format("filename,configname,PlaceHoldFlag,ShowChildren,Image," +
                "CuttingLengthOuter,CuttingLengthInner,CutOutCount,BendCount,{0}", String.Join(",", tempProp.FieldNames));
            string strParams = String.Format("@filename,@configname,@PlaceHoldFlag,@ShowChildren," +
                "@Image,@CuttingLengthOuter,@CuttingLengthInner,@CutOutCount,@BendCount,@{0}", String.Join(",@", tempProp.FieldNames));
            cmdInsertConfigs = cnn.CreateCommand();
			cmdInsertConfigs.CommandText = String.Format("INSERT INTO configs ({0}) VALUES({1})", strFields, strParams);
			cmdInsertConfigs.Parameters.Add(new SQLiteParameter("@filename"));
			cmdInsertConfigs.Parameters.Add(new SQLiteParameter("@configname"));
			cmdInsertConfigs.Parameters.Add(new SQLiteParameter("@PlaceHoldFlag"));
			cmdInsertConfigs.Parameters.Add(new SQLiteParameter("@ShowChildren"));
			cmdInsertConfigs.Parameters.Add(new SQLiteParameter("@Image"));
			cmdInsertConfigs.Parameters.Add(new SQLiteParameter("@CuttingLengthOuter"));
			cmdInsertConfigs.Parameters.Add(new SQLiteParameter("@CuttingLengthInner"));
			cmdInsertConfigs.Parameters.Add(new SQLiteParameter("@CutOutCount"));
			cmdInsertConfigs.Parameters.Add(new SQLiteParameter("@BendCount"));
            foreach (string fieldName in tempProp.FieldNames)
			    cmdInsertConfigs.Parameters.Add(new SQLiteParameter("@"+fieldName));
			
			cmdInsertAdjacency = cnn.CreateCommand();
			cmdInsertAdjacency.CommandText = "INSERT INTO adjacency VALUES(@PName,@PConfig,@CName,@CConfig,@Count)";
			cmdInsertAdjacency.Parameters.Add(new SQLiteParameter("@PName"));
            cmdInsertAdjacency.Parameters.Add(new SQLiteParameter("@PConfig"));
            cmdInsertAdjacency.Parameters.Add(new SQLiteParameter("@CName"));
            cmdInsertAdjacency.Parameters.Add(new SQLiteParameter("@CConfig"));
            cmdInsertAdjacency.Parameters.Add(new SQLiteParameter("@Count"));

            cmdUpdateAdjacency = cnn.CreateCommand();
			cmdUpdateAdjacency.CommandText = @"
				UPDATE adjacency SET adjcount=@Count
				WHERE pname like @PName
				AND pconfig like @PConfig
				AND cname like @CName
				AND cconfig like @CConfig
			";
            cmdUpdateAdjacency.Parameters.Add(new SQLiteParameter("@Count"));
            cmdUpdateAdjacency.Parameters.Add(new SQLiteParameter("@PName"));
            cmdUpdateAdjacency.Parameters.Add(new SQLiteParameter("@PConfig"));
            cmdUpdateAdjacency.Parameters.Add(new SQLiteParameter("@CName"));
            cmdUpdateAdjacency.Parameters.Add(new SQLiteParameter("@CConfig"));
			
			cmdGetAdjCount = cnn.CreateCommand();
			cmdGetAdjCount.CommandText = @"
				SELECT adjcount FROM adjacency
				WHERE pname like @PName
				AND pconfig like @PConfig
				AND cname like @CName
				AND cconfig like @CConfig
			";
            cmdGetAdjCount.Parameters.Add(new SQLiteParameter("@PName"));
            cmdGetAdjCount.Parameters.Add(new SQLiteParameter("@PConfig"));
            cmdGetAdjCount.Parameters.Add(new SQLiteParameter("@CName"));
            cmdGetAdjCount.Parameters.Add(new SQLiteParameter("@CConfig"));

            cmdCheckAdjacency = cnn.CreateCommand();
			cmdCheckAdjacency.CommandText = "SELECT count(*) FROM adjacency WHERE pname like @PName AND pconfig like @PConfig";
            cmdCheckAdjacency.Parameters.Add(new SQLiteParameter("@PName"));
            cmdCheckAdjacency.Parameters.Add(new SQLiteParameter("@PConfig"));
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
