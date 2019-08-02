/*
 * Created by SharpDevelop.
 * User: mtaylor
 * Date: 1/6/2010
 * Time: 9:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace sw_BOM_Scan
{
	partial class BomScan
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BomScan));
            this.txtActiveDoc = new System.Windows.Forms.TextBox();
            this.lblActiveDoc = new System.Windows.Forms.Label();
            this.lblTargetFile = new System.Windows.Forms.Label();
            this.txtTargetFile = new System.Windows.Forms.TextBox();
            this.cmdTargetFile = new System.Windows.Forms.Button();
            this.cmdScan = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblActiveConfig = new System.Windows.Forms.Label();
            this.txtActiveConfig = new System.Windows.Forms.TextBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxGetImages = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtActiveDoc
            // 
            this.txtActiveDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActiveDoc.BackColor = System.Drawing.SystemColors.Control;
            this.txtActiveDoc.Location = new System.Drawing.Point(89, 9);
            this.txtActiveDoc.Name = "txtActiveDoc";
            this.txtActiveDoc.Size = new System.Drawing.Size(306, 20);
            this.txtActiveDoc.TabIndex = 0;
            this.txtActiveDoc.TabStop = false;
            // 
            // lblActiveDoc
            // 
            this.lblActiveDoc.Location = new System.Drawing.Point(12, 9);
            this.lblActiveDoc.Name = "lblActiveDoc";
            this.lblActiveDoc.Size = new System.Drawing.Size(71, 20);
            this.lblActiveDoc.TabIndex = 1;
            this.lblActiveDoc.Text = "Active Doc";
            this.lblActiveDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTargetFile
            // 
            this.lblTargetFile.Location = new System.Drawing.Point(12, 61);
            this.lblTargetFile.Name = "lblTargetFile";
            this.lblTargetFile.Size = new System.Drawing.Size(71, 20);
            this.lblTargetFile.TabIndex = 3;
            this.lblTargetFile.Text = "DB File";
            this.lblTargetFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTargetFile
            // 
            this.txtTargetFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetFile.BackColor = System.Drawing.SystemColors.Control;
            this.txtTargetFile.Location = new System.Drawing.Point(89, 61);
            this.txtTargetFile.Name = "txtTargetFile";
            this.txtTargetFile.ReadOnly = true;
            this.txtTargetFile.Size = new System.Drawing.Size(306, 20);
            this.txtTargetFile.TabIndex = 2;
            // 
            // cmdTargetFile
            // 
            this.cmdTargetFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTargetFile.Location = new System.Drawing.Point(401, 60);
            this.cmdTargetFile.Margin = new System.Windows.Forms.Padding(0);
            this.cmdTargetFile.Name = "cmdTargetFile";
            this.cmdTargetFile.Size = new System.Drawing.Size(62, 22);
            this.cmdTargetFile.TabIndex = 2;
            this.cmdTargetFile.Text = "Get File";
            this.cmdTargetFile.UseVisualStyleBackColor = true;
            this.cmdTargetFile.Click += new System.EventHandler(this.CmdTargetFileClick);
            // 
            // cmdScan
            // 
            this.cmdScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdScan.Location = new System.Drawing.Point(401, 99);
            this.cmdScan.Margin = new System.Windows.Forms.Padding(0);
            this.cmdScan.Name = "cmdScan";
            this.cmdScan.Size = new System.Drawing.Size(62, 22);
            this.cmdScan.TabIndex = 3;
            this.cmdScan.Text = "Scan";
            this.cmdScan.UseVisualStyleBackColor = true;
            this.cmdScan.Click += new System.EventHandler(this.CmdScanClick);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 101);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(71, 20);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Scan Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Location = new System.Drawing.Point(89, 101);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(306, 20);
            this.txtStatus.TabIndex = 5;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "db3";
            this.saveFileDialog1.Filter = "SQLLite Database (*.db3)|*.db3|All Files (*.*)|*.*";
            this.saveFileDialog1.OverwritePrompt = false;
            this.saveFileDialog1.Title = "New Target Data File";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(401, 99);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(0);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(62, 22);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.TabStop = false;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.CmdCancelClick);
            // 
            // lblActiveConfig
            // 
            this.lblActiveConfig.Location = new System.Drawing.Point(12, 35);
            this.lblActiveConfig.Name = "lblActiveConfig";
            this.lblActiveConfig.Size = new System.Drawing.Size(71, 20);
            this.lblActiveConfig.TabIndex = 11;
            this.lblActiveConfig.Text = "Active Config";
            this.lblActiveConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtActiveConfig
            // 
            this.txtActiveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActiveConfig.BackColor = System.Drawing.SystemColors.Control;
            this.txtActiveConfig.Location = new System.Drawing.Point(89, 35);
            this.txtActiveConfig.Name = "txtActiveConfig";
            this.txtActiveConfig.ReadOnly = true;
            this.txtActiveConfig.Size = new System.Drawing.Size(306, 20);
            this.txtActiveConfig.TabIndex = 0;
            this.txtActiveConfig.TabStop = false;
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.Location = new System.Drawing.Point(329, 136);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(64, 32);
            this.btnReturn.TabIndex = 12;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.BtnReturn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(399, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 32);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // cbxGetImages
            // 
            this.cbxGetImages.AutoSize = true;
            this.cbxGetImages.Location = new System.Drawing.Point(15, 136);
            this.cbxGetImages.Name = "cbxGetImages";
            this.cbxGetImages.Size = new System.Drawing.Size(80, 17);
            this.cbxGetImages.TabIndex = 14;
            this.cbxGetImages.Text = "Get Images";
            this.cbxGetImages.UseVisualStyleBackColor = true;
            // 
            // BomScan
            // 
            this.AcceptButton = this.btnReturn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(477, 181);
            this.ControlBox = false;
            this.Controls.Add(this.cbxGetImages);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.lblActiveConfig);
            this.Controls.Add(this.txtActiveConfig);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.cmdTargetFile);
            this.Controls.Add(this.lblTargetFile);
            this.Controls.Add(this.txtTargetFile);
            this.Controls.Add(this.lblActiveDoc);
            this.Controls.Add(this.txtActiveDoc);
            this.Controls.Add(this.cmdScan);
            this.Controls.Add(this.cmdCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BomScan";
            this.Text = "sw_BOM_Scan";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button cmdScan;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.TextBox txtStatus;
		private System.Windows.Forms.Button cmdTargetFile;
		private System.Windows.Forms.TextBox txtTargetFile;
		private System.Windows.Forms.Label lblTargetFile;
		private System.Windows.Forms.Label lblActiveDoc;
		private System.Windows.Forms.TextBox txtActiveDoc;
        private System.Windows.Forms.Label lblActiveConfig;
        private System.Windows.Forms.TextBox txtActiveConfig;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbxGetImages;
    }
}
