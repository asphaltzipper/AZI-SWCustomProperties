using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading.Tasks;

using CredentialManagement;
using sw_BOM_Scan;
using SwApiAbstraction;
using PropertyDataScaffold;
using OdooObjects;
using RawMaterialSelect;

namespace AZI_SWCustomProperties
{
    public partial class MainForm : Form
    {
        private SplashScreen splash;
        private string splashStatusText = "";
        private Color splashStatusColor = Color.White;
        private bool formLoading = false;
        private bool suspendChangeHandler = false;
        private int previousConfigIndex = -1;
        //BindingSource bindingSource = new BindingSource();

        private Dictionary<string, Dictionary<string, string>> toolTipList = new Dictionary<string, Dictionary<string, string>>();

        private string odooCredentialTarget;
        private string odooUrl;
        private string odooDb;
        private string odooUser;

        private OdooRpcCs.OdooClient oClient;
        private OdooTools oTools;
        private string licenseKey = Properties.AppSettings.Default.SwLicenseKey;
        SwApiWrapper swApi;
        private SwModelWrapper swMod;
        private OdooProduct oProduct;

        private PropertyScaffold scaffold = new PropertyScaffold();
        private DataTable mainProps;
        private DataTable origMainProps;
        private DataTable odooProps;
        private DataTable origOdooProps;
        private DataTable rawMaterials;

        public MainForm()
        {
            InitializeComponent();

            formLoading = true;

            odooCredentialTarget = Properties.AppSettings.Default.OdooCredentialTarget;
            odooUrl = Properties.UserSettings.Default.OdooUrl;
            odooDb = Properties.UserSettings.Default.OdooDb;

            InitializeToolTipList();

            System.Windows.Forms.DialogResult dr = System.Windows.Forms.DialogResult.No;
            while (dr != System.Windows.Forms.DialogResult.OK)
            {
                splash = new SplashScreen();
                Thread connThread = new Thread(new ThreadStart(ConnectionControl));
                connThread.Start();
                dr = splash.ShowDialog(this);
                if (dr == System.Windows.Forms.DialogResult.Abort)
                    Environment.Exit(0);
            }

            this.Text = "SW Properties: " + swMod.ModelName;
            lblUserStatus.Text = "Odoo User: " + odooUser;

            BindData();
            PullFromOdoo();
            PushToOdoo();

            //this.cboCurrentConfig.SelectedIndex = -1;
            this.mainProps.DefaultView.RowFilter = "configname=''";
            this.origMainProps.DefaultView.RowFilter = "configname=''";
            this.mainProps.ColumnChanged += new DataColumnChangeEventHandler(Props_Changed);
            //this.odooProps.ColumnChanged += new DataColumnChangeEventHandler(OdooProps_Changed);
            this.cboCurrentConfig.SelectedIndexChanged += new EventHandler(CboCurrentConfig_SelectedIndexChanged);
            this.cboCurrentConfig.SelectedIndex = 0;

            formLoading = false;
        }

        #region Connection Management

        private void WriteSplashStatus()
        {
            splash.UpdateStatus(splashStatusText, splashStatusColor);
        }

        private void CloseSplash()
        {
            splash.DialogResult = System.Windows.Forms.DialogResult.OK;
            splash.Close();
        }

        private void ConnectionControl()
        {
            bool result = true;
            MethodInvoker WriteStatusDelegate = new MethodInvoker(WriteSplashStatus);
            while (!splash.IsHandleCreated)
                Thread.Sleep(50);

            // connect to odoo
            splash.AddStatusLine("NORMAL", "Connecting to Odoo...");
            splashStatusText = "Connecting to Odoo...";
            splashStatusColor = Color.Yellow;
            Invoke(WriteStatusDelegate);
            result = OdooLogin();
            Invoke(WriteStatusDelegate);
            if (!result)
                return;

            // connect to solidworks
            splash.AddStatusLine("NORMAL", "Connecting to SolidWorks...");
            splashStatusText = "Connecting to Solidworks...";
            splashStatusColor = Color.Yellow;
            Invoke(WriteStatusDelegate);
            result = SolidWorksConnect();
            Invoke(WriteStatusDelegate);
            if (!result)
            {
                splash.AddStatusLine("ERROR", "Failed connecting to SolidWorks...");
                return;
            }

            // get odoo product
            splash.AddStatusLine("NORMAL", "Getting Odoo product...");
            splashStatusText = "Getting Odoo Product...";
            splashStatusColor = Color.Yellow;
            Invoke(WriteStatusDelegate);
            result = GetOdooProduct();
            Invoke(WriteStatusDelegate);
            if (!result)
            {
                splash.AddStatusLine("WARNING", "Failed to get Odoo product...");
                splashStatusText = "Failed to get Odoo product...";
                splashStatusColor = Color.Red;
                result = true;
            }

            // get form data
            splash.AddStatusLine("NORMAL", "Loading form data...");
            splashStatusText = "Loading Form Data...";
            splashStatusColor = Color.Yellow;
            Invoke(WriteStatusDelegate);
            result = LoadFormData();
            Invoke(WriteStatusDelegate);
            if (!result)
            {
                splash.AddStatusLine("ERROR", "Failed loading form data...");
                return;
            }

            MethodInvoker CloseDelegate = new MethodInvoker(CloseSplash);
            Invoke(CloseDelegate);
        }

        private bool SolidWorksConnect()
        {
            // Get solidworks process and fill the configuration select box
            try
            {
                this.swApi = new SwApiWrapper();
                this.swMod = swApi.MainModel;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return false;
            }

            // Get custom properties and accept changes
            this.mainProps = swMod.GetCustomProps();
            this.origMainProps = mainProps.Clone();
            this.origMainProps.TableName = "origMainProps";
            AcceptAllChanges(current: mainProps, original: origMainProps);

            string productCode = String.Format(
                "{0}.{1}",
                this.mainProps.DefaultView[0].Row["PartNum"].ToString(),
                this.mainProps.DefaultView[0].Row["Revision"].ToString());
            productCode = productCode == "." ? "" : productCode;
            SwProductCode.Invoke((MethodInvoker)(() => SwProductCode.Text = productCode));
            PopulateConfigs();
            return true;
        }

        private bool OdooLogin()
        {
            // https://stackoverflow.com/questions/17741424/retrieve-credentials-from-windows-credentials-store-using-c-sharp
            var cm = new Credential { Target = odooCredentialTarget };
            if (!cm.Load())
            {
                splash.AddStatusLine("ERROR", "No credentials found");
                splashStatusText = "No Credentials Found!";
                splashStatusColor = Color.Red;
                return false;
            }

            // Get stored username and password
            string odooUsername = cm.Username;
            string odooPassword = cm.Password;

            // Get Odoo connection
            oClient = new OdooRpcCs.OdooClient(odooUrl, odooDb, odooUsername, odooPassword);
            if (!oClient.Login(7000))
            {
                splash.AddStatusLine("ERROR", "Odoo connection failed: " + oClient.LatestException);
                splashStatusText = "Odoo Connection Failed: " + oClient.LatestException;
                splashStatusColor = Color.Red;
                return false;
            }
            splash.AddStatusLine("OKAY", "Logged in to odoo: " + odooUsername);
            splashStatusText = odooUsername;
            splashStatusColor = Color.LightGreen;
            oTools = new OdooObjects.OdooTools(oClient);
            odooUser = odooUsername;
            return true;
        }

        #endregion

        #region Form Control Management

        private int FindValueIndex(ComboBox box, string value)
        {
            for (int i = 0; i < box.Items.Count; i++)
                if (((ComboboxItem)box.Items[i]).Value == value)
                    return i;
            return -1;
        }

        //public void LockAllControls(bool enableControl)
        //{
        //    foreach (Control thisControl in this.Controls)
        //        thisControl.Enabled = enableControl;
        //    btnApply.Enabled = enableControl;
        //    btnApplyClose.Enabled = enableControl;
        //}

        //public static Control FindFocusedControl(Control control)
        //{
        //    var container = control as IContainerControl;
        //    while (container != null)
        //    {
        //        control = container.ActiveControl;
        //        container = control as IContainerControl;
        //    }
        //    return control;
        //}

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    // Insert the current date on CTRL+;
        //    if (keyData == (Keys.Control | Keys.OemSemicolon))
        //    {
        //        var focused = FindFocusedControl(this);
        //        if (focused is TextBox)
        //        {
        //            int selectionIndex = ((TextBox)focused).SelectionStart;
        //            int selectionLength = ((TextBox)focused).SelectionLength;
        //            string allText = ((TextBox)focused).Text;
        //            string newText = allText.Remove(selectionIndex, selectionLength);
        //            newText = newText.Insert(selectionIndex, DateTime.Today.ToShortDateString());
        //            ((TextBox)focused).Text = newText;
        //            ((TextBox)focused).SelectionStart = selectionIndex + DateTime.Today.ToShortDateString().Length;
        //        }
        //        else
        //            focused.Text = DateTime.Today.ToShortDateString();
        //        return true;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        #endregion

        #region DataRow Versioning

        private void AcceptAllChanges(DataTable current, DataTable original)
        {
            original.Rows.Clear();
            foreach (DataRow dr in current.Rows)
                original.ImportRow(dr);
        }

        private void RejectAllChanges(DataTable current, DataTable original)
        {
            current.Rows.Clear();
            foreach (DataRow dr in original.Rows)
                current.ImportRow(dr);
        }

        private void AcceptRowChanges(DataRow current, DataRow original)
        {
            CopyRowData(source: current, target: original);
        }

        private void RejectRowChanges(DataRow current, DataRow original)
        {
            CopyRowData(source: original, target: current);
        }

        private void CopyRowData(DataRow source, DataRow target)
        {
            target.ItemArray = source.ItemArray.Clone() as object[];
        }

        private bool HasRowChanges(DataTable current, DataTable original)
        {
            for (int i = 0; i < current.Rows.Count; i++)
                if (!DataRow.Equals(current.Rows[i], original.Rows[i]))
                {
                    object[] origVals = original.Rows[i].ItemArray;
                    object[] currVals = current.Rows[i].ItemArray;
                    for (int r = 0; r < currVals.Length; r++)
                        if (!currVals[r].Equals(origVals[r]))
                            return true;
                }
            return false;
        }

        private DataRow[] GetRowChanges(DataTable current, DataTable original)
        {
            /// Compares rows in order until it finds a pair that doesn't match.
            /// Then it returns those 2 rows
            /// The first row is from the original DataTable
            /// The second row is from the current DataTable
            DataTable changes = original.Clone();
            DataRow[] rows = new DataRow[2];
            for (int i = 0; i < current.Rows.Count; i++)
                if (!DataRow.Equals(current.Rows[i], original.Rows[i]))
                {
                    rows[0] = original.Rows[i];
                    rows[1] = current.Rows[i];
                    object[] origVals = original.Rows[i].ItemArray;
                    object[] currVals = current.Rows[i].ItemArray;
                    for (int r = 0; r < currVals.Length; r++)
                        if (!currVals[r].Equals(origVals[r]))
                            return rows;
                }
            return new DataRow[2];
        }

        private List<string> GetChangedColumns(DataRow current, DataRow original)
        {
            /// Returns a list of column names that have changed
            List<string> colNames = new List<string>();
            foreach (DataColumn col in current.Table.Columns)
            {
                string colName = col.ColumnName;
                if (!current[colName].Equals(original[colName]))
                    colNames.Add(colName);
            }
            return colNames;
        }

        private void AcceptColumnChanges(DataRow current, DataRow original, List<string> colAcceptNames)
        {
            if (DataRow.Equals(original, current))
                return;

            // suspend column change event handler
            suspendChangeHandler = true;

            // copy and revert the current data
            DataRow copy = current.Table.NewRow();
            CopyRowData(target: copy, source: current);
            RejectRowChanges(current: current, original: original);

            // apply the accepted column changes
            foreach (string colName in colAcceptNames)
                current[colName] = copy[colName];
            AcceptRowChanges(current: current, original: original);

            // apply the unaccepted column changes
            foreach (DataColumn col in current.Table.Columns)
            {
                if (!colAcceptNames.Contains(col.ColumnName))
                    current[col.ColumnName] = copy[col.ColumnName];
            }

            // resume column change event handler
            suspendChangeHandler = false;
        }

        #endregion

        private bool LoadFormData()
        {
            // This is here because of a "quirk"
            // https://stackoverflow.com/questions/37145354/selected-index-combobox-winforms
            //BindData();

            // Here's some info on DataBinding
            // https://www.akadia.com/services/dotnet_databinding.html

            // Make
            Make.Items.Clear();
            Make.ValueMember = "Value";
            Make.DisplayMember = "Text";
            Make.DataSource = new List<ComboboxItem>() { new ComboboxItem("", ""), new ComboboxItem("Purchase", "P"), new ComboboxItem("Make", "M") };

            // MaterialPN
            MaterialPn.Items.Clear();
            MaterialPn.ValueMember = "Value";
            MaterialPn.DisplayMember = "Text";
            rawMaterials = oTools.GetRawMaterials();
            List<ComboboxItem> itemsRm = new List<ComboboxItem>();
            itemsRm.Add(new ComboboxItem("", ""));
            foreach (DataRow dr in rawMaterials.Select("", "default_code"))
                itemsRm.Add(new ComboboxItem(dr["default_code"].ToString(), dr["default_code"].ToString()));
            MaterialPn.DataSource = itemsRm;

            // UOM
            Uom.Items.Clear();
            Uom.ValueMember = "Value";
            Uom.DisplayMember = "Text";
            List<ComboboxItem> itemsUom = new List<ComboboxItem>();
            itemsUom.Add(new ComboboxItem("", ""));
            foreach (string item in scaffold.Uoms)
                itemsUom.Add(new ComboboxItem(item, item));
            Uom.DataSource = itemsUom;

            // Routing
            RouteTemplate.Items.Clear();
            RouteTemplate.ValueMember = "Value";
            RouteTemplate.DisplayMember = "Text";
            List<ComboboxItem> itemsRouteTmpl = new List<ComboboxItem>();
            itemsRouteTmpl.Add(new ComboboxItem("", ""));
            foreach (string item in oTools.GetRouteTemplates())
                itemsRouteTmpl.Add(new ComboboxItem(item, item));
            RouteTemplate.DataSource = itemsRouteTmpl;

            // Type
            Type.Items.Clear();
            Type.ValueMember = "Value";
            Type.DisplayMember = "Text";
            List<ComboboxItem> itemsType = new List<ComboboxItem>();
            itemsType.Add(new ComboboxItem("", ""));
            foreach (KeyValuePair<string, string> item in oTools.GetPartTypes())
                itemsType.Add(new ComboboxItem(item.Value, item.Key));
            Type.DataSource = itemsType;

            // Finish
            Finish.Items.Clear();
            Finish.ValueMember = "Value";
            Finish.DisplayMember = "Text";
            List<ComboboxItem> itemsFinish = new List<ComboboxItem>();
            itemsFinish.Add(new ComboboxItem("", ""));
            foreach (string item in oTools.GetPreparations())
                itemsFinish.Add(new ComboboxItem(item, item));
            Finish.DataSource = itemsFinish;

            // Coating
            Coating.Items.Clear();
            Coating.ValueMember = "Value";
            Coating.DisplayMember = "Text";
            List<ComboboxItem> itemsCoating = new List<ComboboxItem>();
            itemsCoating.Add(new ComboboxItem("", ""));
            foreach (string item in oTools.GetCoatings())
                itemsCoating.Add(new ComboboxItem(item, item));
            Coating.DataSource = itemsCoating;

            return true;
        }

        private void BindData()
        {
            //cboCurrentConfig.DataBindings.Clear();
            //cboCurrentConfig.DataBindings.Add("SelectedValue", this.props, "configname");

            //bindingSource.DataSource = props;
            //bindingSource.Filter = "configname=''";
            //PartNum.DataBindings.Clear();
            //PartNum.DataBindings.Add(
            //    "Text",
            //    bindingSource,
            //    "PartNum",
            //    false,
            //    DataSourceUpdateMode.OnPropertyChanged);
            //return;

            // Bind SW custom properties
            foreach (DataRow drField in scaffold.FieldDefs.Select("binding=1"))
            {
                string fieldName = drField["field"].ToString();
                if (this.Controls.ContainsKey(fieldName))
                {
                    if (this.Controls[fieldName] is ComboBox)
                    {
                        ComboBox combo = (ComboBox)this.Controls[fieldName];
                        combo.DataBindings.Clear();
                        combo.DataBindings.Add(
                            "SelectedValue",
                            this.mainProps.DefaultView,
                            //this.props,
                            fieldName);
                        //combo.DataBindings.Add(
                        //    "SelectedValue",
                        //    bindingSource,
                        //    fieldName);
                    }
                    if (this.Controls[fieldName] is TextBox)
                    {
                        //if (fieldName == "PartNum")
                        //    System.Diagnostics.Debug.WriteLine(fieldName);
                        //TextBox text = (TextBox)this.Controls[fieldName];
                        //text.DataBindings.Clear();
                        //text.DataBindings.Add(
                        //    "Text",
                        //    mainSource,
                        //    fieldName,
                        //    false,
                        //    DataSourceUpdateMode.OnPropertyChanged);
                        this.Controls[fieldName].DataBindings.Clear();
                        this.Controls[fieldName].DataBindings.Add(
                            "Text",
                            this.mainProps.DefaultView,
                            //this.props,
                            fieldName,
                            false,
                            DataSourceUpdateMode.OnPropertyChanged);
                        //this.Controls[fieldName].DataBindings.Add(
                        //    "Text",
                        //    bindingSource,
                        //    fieldName,
                        //    false,
                        //    DataSourceUpdateMode.OnPropertyChanged);
                    }
                    if (this.Controls[fieldName] is CheckBox)
                    {
                        if (this.mainProps.DefaultView[0].Row[fieldName].GetType() != System.Type.GetType("System.Boolean"))
                            throw new Exception(String.Format("Failed binding {0}: Can't bind DBNull value to a checkbox", fieldName));
                        this.Controls[fieldName].DataBindings.Clear();
                        this.Controls[fieldName].DataBindings.Add(
                            "Checked",
                            this.mainProps.DefaultView,
                            //this.props,
                            fieldName);
                        //this.Controls[fieldName].DataBindings.Add(
                        //    "Checked",
                        //    bindingSource,
                        //    fieldName);
                    }
                }
            }
        }

        private bool GetOdooProduct()
        {
            if (OdooProduct.InvokeRequired == false)
                OdooProduct.Text = null;
            else
                OdooProduct.Invoke((MethodInvoker)(() => OdooProduct.Text = null));

            // Get Odoo product
            string configName = "";
            if (cboCurrentConfig.SelectedIndex != -1)
                configName = ((ComboboxItem)cboCurrentConfig.SelectedItem).Value.ToString();
            // string productCode = PropertyScaffold.ProductCode(props, configName);
            string productCode = SwProductCode.Text;
            oProduct = new OdooProduct(oClient, productCode, scaffold);
            odooProps = oProduct.Table;
            odooProps.TableName = "odooProps";
            origOdooProps = odooProps.Clone();
            origOdooProps.TableName = "origOdooProps";
            AcceptAllChanges(current: odooProps, original: origOdooProps);

            if (!oProduct.HasProduct)
            {
                UpdateOdoo.Enabled = false;
                return false;
            }

            string odooProductName = odooProps.Rows[0]["OdooProduct"].ToString();
            splash.AddStatusLine("OKAY", "Got Odoo product: " + odooProductName);
            splashStatusText = odooProductName;
            splashStatusColor = Color.LightGreen;
            if (OdooProduct.InvokeRequired == false)
                OdooProduct.Text = odooProductName;
            else
                OdooProduct.Invoke((MethodInvoker)(() => OdooProduct.Text = odooProductName));
            UpdateOdoo.Enabled = true;

            return true;
        }

        private void PushToOdoo()
        {
            /// Overwrite Odoo data with data from SolidWorks
            /// These SolidWorks field values take precedence over Odoo values
            /// These changes will NOT dirty the props data table
            /// We must manually indicate Odoo unsaved changes in the interface

            // Bind odoo eco datagridview to ecos datatable
            dgEcos.DataSource = oProduct.Ecos;

            if (oProduct.HasProduct)
            {
                // Overwrite odoo product data with custom properties
                string filter = "push_odoo=1";
                foreach (DataRow drField in scaffold.FieldDefs.Select(filter))
                {
                    string fieldName = drField["field"].ToString();
                    object swValue = this.mainProps.DefaultView[0].Row[fieldName];
                    DataRow dr = this.odooProps.Rows[0];
                    if (!swValue.Equals(dr[fieldName]))
                        dr[fieldName] = swValue;
                }
            }
        }

        private void PullFromOdoo()
        {
            // Show Odoo image
            if (this.oProduct.HasProduct && !odooProps.Rows[0].IsNull("OdooImage"))
            {
                byte[] bytes = Convert.FromBase64String((string)odooProps.Rows[0]["OdooImage"]);
                OdooImage.Image = PropertyScaffold.ByteArrayToImage(bytes);
            }
            else
                OdooImage.Image = Properties.Resources.missing_image_320x;

            if (!oProduct.HasProduct)
                return;

            string filter;
            DataRow drMainCurr = this.mainProps.DefaultView[0].Row;
            DataRow drMainOrig = this.origMainProps.DefaultView[0].Row;
            // Overwrite uninitialized Odoo fields from Odoo data
            // These fields are sourced from Odoo only
            // These chages should NOT dirty the props DataTable
            // We can't accept changes to the entire row, as this would accept
            // other changes that the user made before changing the part number.
            // We have created a method to accept only the changes that
            // result from populating the uninitialized fields.
            // As an alternative,we could ignore these changes by checking each
            // specific column every time we need to check for changes.
            filter = "pull_odoo=1 and sw_prop is null";
            List<string> columnNames = new List<string>();
            foreach (DataRow drField in scaffold.FieldDefs.Select(filter))
            {
                string fieldName = drField["field"].ToString();
                object odooValue = odooProps.Rows[0][fieldName];
                drMainCurr[fieldName] = odooValue;
                columnNames.Add(fieldName);
            }
            AcceptColumnChanges(current: drMainCurr, original: drMainOrig, colAcceptNames: columnNames);

            // Overwrite SolidWorks data with data from Odoo
            // These Odoo field values take precedence over SolidWorks values
            // If the Odoo value is DBNull, don't overwrite
            // These changes will dirty the props data table and indicate unsaved changes in the interface
            filter = "sw_prop is not null and pull_odoo=1";
            foreach (DataRow drField in scaffold.FieldDefs.Select(filter))
            {
                string fieldName = drField["field"].ToString();
                object odooValue = odooProps.Rows[0][fieldName];
                if (odooValue != System.DBNull.Value && !odooValue.Equals(drMainCurr[fieldName]))
                    drMainCurr[fieldName] = odooValue;
            }

            // Overwrite empty SolidWorks data with data from Odoo
            // These Odoo field values take precedence over empty SolidWorks values
            // These changes will dirty the props data table and indicate unsaved changes in the interface
            filter = "sw_prop is not null and conditional_odoo_pull=1";
            foreach (DataRow drField in scaffold.FieldDefs.Select(filter))
            {
                string fieldName = drField["field"].ToString();
                object odooValue = odooProps.Rows[0][fieldName];
                if (drMainCurr.IsNull(fieldName) || drMainCurr[fieldName].ToString() == "")
                    drMainCurr[fieldName] = odooValue;
            }
        }

        private void CorrectInvalidFields(DataRow dr)
        {
            if (String.IsNullOrEmpty(SwProductCode.Text))
                return;
            // Correct UOM
            scaffold.UomMapping.TryGetValue(dr["Uom"].ToString(), out string matchedUom);
            if (matchedUom != null)
                dr["Uom"] = matchedUom;
            // Correct Make
            if (dr["Make"].ToString() != "P")
            {
                dr["Make"] = "M";
            }
            // Correct coating
            scaffold.CoatingMapping.TryGetValue(dr["Coating"].ToString(), out string matchedCoating);
            if (matchedCoating != null)
                dr["Coating"] = matchedCoating;
            // Correct finish
            scaffold.CoatingMapping.TryGetValue(dr["Coating"].ToString(), out string matchedFinish);
            if (matchedFinish != null)
                dr["Finish"] = matchedFinish;
            // Check for valid values in select boxes
            foreach (DataRow drField in scaffold.FieldDefs.Select("binding=1"))
            {
                string fieldName = drField["field"].ToString();
                if (this.Controls.ContainsKey(fieldName))
                {
                    if (this.Controls[fieldName] is ComboBox)
                    {
                        ComboBox combo = (ComboBox)this.Controls[fieldName];
                        string dataValue = dr[fieldName].ToString();
                        if (FindValueIndex(combo, dataValue) == -1)
                            dr[fieldName] = DBNull.Value;
                    }
                }
            }
        }

        private void PopulateConfigs()
        {
            if (swMod == null)
                return;

            cboCurrentConfig.Items.Clear();
            cboCurrentConfig.Items.Add(new ComboboxItem("<File Level Properties>", ""));
            foreach (string config in swMod.ConfigNames)
                cboCurrentConfig.Items.Add(new ComboboxItem(config, config));

            //DataTable dt = new DataTable("configs");
            //dt.Columns.Add(new DataColumn("name", System.Type.GetType("System.String")));
            //dt.Columns.Add(new DataColumn("display", System.Type.GetType("System.String")));
            //dt.Rows.Add("", "<File Level Properties>");
            //foreach (string config in swMod.ConfigNames)
            //    dt.Rows.Add(config, config);
            //cboCurrentConfig.DataSource = dt;
            //cboCurrentConfig.DisplayMember = "display";
        }

        private void InitializeToolTipList()
        {
            foreach (DataRow drField in scaffold.FieldDefs.Select("binding=1"))
            {
                string fieldName = drField["field"].ToString();
                Dictionary<string, string> dict = new Dictionary<string, string>
                {
                    { "origSw", "" },
                    { "currSw", "" },
                    { "origOd", "" },
                    { "currOd", "" },
                };
                toolTipList.Add(fieldName, dict);
            }
        }

        private void RefreshToolTips()
        {
            foreach (DataRow drField in scaffold.FieldDefs.Select("binding=1"))
            {
                string fieldName = drField["field"].ToString();
                Control control = this.Controls[fieldName];
                string tip = String.Format(
                    "SW Original: {0}\nSW Current: {1}\nOdoo Original: {2}\nOdoo Current: {3}\n",
                    toolTipList[fieldName]["origSw"],
                    toolTipList[fieldName]["currSw"],
                    toolTipList[fieldName]["origOd"],
                    toolTipList[fieldName]["currOd"]);
                toolTip1.SetToolTip(control, tip);
            }
        }

        private void SetFieldToolTipList(string fieldName, object origSw = null, object currSw = null, object origOd = null, object currOd = null)
        {
            // Passing only the arguments you want to change will keep other elements unchanged
            if (origSw == null)
                toolTipList[fieldName]["origSw"] = toolTipList[fieldName]["origSw"];
            else if (origSw.GetType() == System.Type.GetType("System.DBNull"))
                toolTipList[fieldName]["origSw"] = "";
            else if (origSw.GetType() == System.Type.GetType("System.String") && origSw.ToString() == "")
                toolTipList[fieldName]["origSw"] = "\"\"";
            else
                toolTipList[fieldName]["origSw"] = origSw.ToString();

            if (currSw == null)
                toolTipList[fieldName]["currSw"] = toolTipList[fieldName]["currSw"];
            else if (currSw.GetType() == System.Type.GetType("System.DBNull"))
                toolTipList[fieldName]["currSw"] = "";
            else if (currSw.GetType() == System.Type.GetType("System.String") && currSw.ToString() == "")
                toolTipList[fieldName]["currSw"] = "\"\"";
            else
                toolTipList[fieldName]["currSw"] = currSw.ToString();

            if (origOd == null)
                toolTipList[fieldName]["origOd"] = toolTipList[fieldName]["origOd"];
            else if (origOd.GetType() == System.Type.GetType("System.DBNull"))
                toolTipList[fieldName]["origOd"] = "";
            else if (origOd.GetType() == System.Type.GetType("System.String") && origOd.ToString() == "")
                toolTipList[fieldName]["origOd"] = "\"\"";
            else
                toolTipList[fieldName]["origOd"] = origOd.ToString();

            if (currOd == null)
                toolTipList[fieldName]["currOd"] = toolTipList[fieldName]["currOd"];
            else if (currOd.GetType() == System.Type.GetType("System.DBNull"))
                toolTipList[fieldName]["currOd"] = "";
            else if (currOd.GetType() == System.Type.GetType("System.String") && currOd.ToString() == "")
                toolTipList[fieldName]["currOd"] = "\"\"";
            else
                toolTipList[fieldName]["currOd"] = currOd.ToString();
        }

        private bool CheckForChanges()
        {
            return this.mainProps.DefaultView[0].Row.RowState == DataRowState.Modified;
        }

        private void Props_Changed(object sender, DataColumnChangeEventArgs e)
        {
            if (suspendChangeHandler)
                return;

            // Handle part number changes
            if (e.Column.ColumnName == "PartNum" || e.Column.ColumnName == "Revision")
            {
                string productCode = String.Format(
                    "{0}.{1}",
                    this.mainProps.DefaultView[0].Row["PartNum"].ToString(),
                    this.mainProps.DefaultView[0].Row["Revision"].ToString());
                SwProductCode.Text = productCode == "." ? "" : productCode;
                GetOdooProduct();
                PullFromOdoo();
                PushToOdoo();
            }
            //else
            //{
            //    //DataTable mainChanges = mainProps.GetChanges();
            //    bool hasChanges = HasRowChanges(current: this.mainProps, original: this.origMainProps);
            //    if (!hasChanges)
            //        return;
            //}

            DataRow[] changes = GetRowChanges(current: this.mainProps, original: this.origMainProps);
            string fieldName = e.Column.ColumnName;
            object newValue = e.ProposedValue;

            // Copy changes to odoo DataTable
            DataRow drField = scaffold.FieldDefs.Select("field='" + fieldName + "'")[0];
            if ((long)drField["push_odoo"] == 1 && !newValue.Equals(odooProps.Rows[0][fieldName]))
                odooProps.Rows[0][fieldName] = newValue;

            UpdateChangeIndicators();
        }

        private void UpdateChangeIndicators()
        {
            /// Update field change indicators
            /// The change indicator is a label string having 4 states
            /// "  "
            /// "OS"
            /// "O "
            /// " S"

            bool mainMod = HasRowChanges(current: mainProps, original: origMainProps);
            bool odooMod = HasRowChanges(current: odooProps, original: origOdooProps);
            DataRow[] mainChanges = GetRowChanges(current: mainProps, original: origMainProps);
            // DataRow[] mainChanges = GetRowChanges(current: mainProps.DefaultView.ToTable(), original: origMainProps.DefaultView.ToTable());
            DataRow[] odooChanges = GetRowChanges(current: odooProps, original: origOdooProps);
            if (!mainMod)
            {
                mainChanges[0] = this.mainProps.DefaultView[0].Row;
                mainChanges[1] = this.mainProps.DefaultView[0].Row;
            }
            if (!odooMod)
            {
                odooChanges[0] = this.odooProps.Rows[0];
                odooChanges[1] = this.odooProps.Rows[0];
            }
            foreach (DataRow drField in this.scaffold.FieldDefs.Select("binding=1 and (sw_prop is not null or odoo_field is not null)"))
            {
                // check for a matching indicator label
                string fieldName = drField["field"].ToString();
                string indicatorName = fieldName + "Change";
                if (!this.Controls.ContainsKey(indicatorName))
                    continue;

                bool isSw = !drField.IsNull("sw_prop");
                bool isOdoo = !drField.IsNull("odoo_field");
                Control indicator = this.Controls[indicatorName];
                Control field = this.Controls[fieldName];

                // clear the indicator and reset the tooltip
                indicator.Text = "  ";
                SetFieldToolTipList(
                    fieldName,
                    origSw: isSw ? mainChanges[0][fieldName] : DBNull.Value,
                    currSw: isSw ? mainChanges[1][fieldName] : DBNull.Value,
                    origOd: isOdoo && oProduct.HasProduct ? odooChanges[0][fieldName] : DBNull.Value,
                    currOd: isOdoo && oProduct.HasProduct ? odooChanges[1][fieldName] : DBNull.Value);

                // continue if no changes to this field
                if (!mainMod && !odooMod)
                    continue;

                // indicate SolidWorks changes
                if (!isSw || !mainMod)
                    indicator.Text = indicator.Text[0] + " ";
                else if (isSw)
                {
                    object origValue = mainChanges[0][fieldName];
                    object currValue = mainChanges[1][fieldName];
                    if (origValue.Equals(currValue))
                        indicator.Text = indicator.Text[0] + " ";
                    else
                    {
                        indicator.Text = indicator.Text[0] + "S";
                        //SetFieldToolTipList(fieldName, origSw: origValue, currSw: currValue);
                    }
                }

                // indicate Odoo changes
                if (!isOdoo || !odooMod)
                    indicator.Text = " " + indicator.Text[1];
                else if (isOdoo)
                {
                    object origValue = odooChanges[0][fieldName];
                    object currValue = odooChanges[1][fieldName];
                    if (origValue.Equals(currValue))
                        indicator.Text = " " + indicator.Text[1];
                    else
                    {
                        indicator.Text = "O" + indicator.Text[1];
                        //SetFieldToolTipList(fieldName, origOd: origValue, currOd: currValue);
                    }
                }
            }
            RefreshToolTips();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm setForm = new SettingsForm();
            setForm.ShowDialog(this);
            odooUrl = Properties.UserSettings.Default.OdooUrl;
            odooDb = Properties.UserSettings.Default.OdooDb;
            SolidWorksConnect();
            OdooLogin();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            bool hasChanges = HasRowChanges(current: this.mainProps, original: this.origMainProps);
            if (hasChanges)
            {
                DataRow[] changes = GetRowChanges(current: this.mainProps, original: this.origMainProps);
                List<string> changedCols = GetChangedColumns(current: changes[1], original: changes[0]);
                System.Windows.Forms.DialogResult result = MessageBox.Show(
                    "Data has changed in the following columns.  Do you want to discard changes?\r\n" + String.Join(", ", changedCols),
                    "Discard Changes",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;
            }

            this.Enabled = false;
            SolidWorksConnect();
            this.Text = "SW Properties: " + swMod.ModelName;
            GetOdooProduct();
            PullFromOdoo();
            BindData();
            PushToOdoo();
            //CboCurrentConfig_SelectedIndexChanged(sender, e);
            cboCurrentConfig.SelectedIndex = -1;
            this.Refresh();
            this.Enabled = true;
        }
        
        private void BtnBomScan_Click(object sender, EventArgs e)
        {
            BomScan bomScan = new BomScan(swApi, swMod, scaffold);
            bomScan.ShowDialog(this);
        }

        private void BtnGetImage_Click(object sender, EventArgs e)
        {
            ImageForm.ImageForm imgForm = new ImageForm.ImageForm(swMod, oProduct);
            imgForm.ShowDialog();
        }

        private void CboCurrentConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedConfig = (string)((ComboboxItem)cboCurrentConfig.SelectedItem).Value;
            //props.DefaultView.RowFilter = "configname='" + selectedConfig + "'";

            //string selectedConfig = ((System.Data.DataRowView)cboCurrentConfig.SelectedItem).Row["name"].ToString();
            //bindingSource.Filter = "configname='" + selectedConfig + "'";

            //CurrencyManager cm = (CurrencyManager)this.BindingContext[props];
            //cm.Position = 0;

            if (cboCurrentConfig.SelectedIndex == previousConfigIndex)
                return;
            if (cboCurrentConfig.SelectedIndex == -1)
            {
                cboCurrentConfig.SelectedIndex = 0;
                return;
            }
            if (!formLoading)
            {
                bool hasChanges = HasRowChanges(current: this.mainProps, original: this.origMainProps);
                if (hasChanges)
                {
                    DataRow[] changes = GetRowChanges(current: this.mainProps, original: this.origMainProps);
                    List<string> changedCols = GetChangedColumns(current: changes[1], original: changes[0]);
                    System.Windows.Forms.DialogResult result = MessageBox.Show(
                        "Data has changed in the following columns.  Do you want to discard changes?\r\n" + String.Join(", ", changedCols),
                        "Discard Changes",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    if (result == System.Windows.Forms.DialogResult.Cancel)
                    {
                        cboCurrentConfig.SelectedIndex = previousConfigIndex;
                        return;
                    }
                    else
                    {
                        //mainProps.RejectChanges();
                        suspendChangeHandler = true;
                        RejectRowChanges(current: changes[1], original: changes[0]);
                        suspendChangeHandler = false;
                    }
                }
            }

            string selectedConfig = (string)((ComboboxItem)cboCurrentConfig.SelectedItem).Value;
            swMod.CurrentConfigName = selectedConfig;
            //foreach (Control cont in this.Controls)
            //    cont.BackColor = default;
            mainProps.DefaultView.RowFilter = "configname='" + selectedConfig + "'";
            origMainProps.DefaultView.RowFilter = "configname='" + selectedConfig + "'";
            previousConfigIndex = cboCurrentConfig.SelectedIndex;
            string productCode = String.Format(
                "{0}.{1}",
                this.mainProps.DefaultView[0].Row["PartNum"].ToString(),
                this.mainProps.DefaultView[0].Row["Revision"].ToString());
            SwProductCode.Text = productCode == "." ? "" : productCode;

            CorrectInvalidFields(mainProps.DefaultView[0].Row);
            GetOdooProduct();
            PullFromOdoo();
            PushToOdoo();
            UpdateChangeIndicators();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HasRowChanges(current: mainProps, original: origMainProps))
            {
                DataRow[] changes = GetRowChanges(current: this.mainProps, original: this.origMainProps);
                List<string> changedCols = GetChangedColumns(current: changes[1], original: changes[0]);
                System.Windows.Forms.DialogResult result = MessageBox.Show(
                    "Data has changed in the following columns.  Do you want to discard changes?\r\n" + String.Join(", ", changedCols),
                    "Discard Changes",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            swMod.WriteCustomProp(mainProps.DefaultView[0].Row);
            DataRow[] changes = GetRowChanges(current: this.mainProps, original: this.origMainProps);
            if (changes[0] != null && changes[1] != null)
                AcceptRowChanges(current: changes[1], original: changes[0]);
            UpdateChangeIndicators();
        }

        private void BtnApplyClose_Click(object sender, EventArgs e)
        {
            BtnApply_Click(sender, e);
            //foreach (Control cont in this.Controls)
            //    cont.BackColor = default;
            this.Close();
        }

        private void EcoDescriptions_TextChanged(object sender, EventArgs e)
        {
            if (TextRenderer.MeasureText(EcoDescriptions.Text, EcoDescriptions.Font).Width > EcoDescriptions.Width)
                //EcoDescriptions.BackColor = Color.Red;
                EcoDescriptions.ScrollBars = ScrollBars.Horizontal;
            else
                //EcoDescriptions.BackColor = Color.White;
                EcoDescriptions.ScrollBars = ScrollBars.None;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PartNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSearchRm_Click(object sender, EventArgs e)
        {
            // get raw material DataTable and load the select form
            DataTable dtRm = oTools.GetRawMaterials();
            using (RawMaterialSelect.RawMaterialSelect form = new RawMaterialSelect.RawMaterialSelect(dtRm))
            {
                var result = form.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    string rawMaterialPn = form.RawMaterialPn;
                    MaterialPn.SelectedIndex = FindValueIndex(MaterialPn, rawMaterialPn);
                    mainProps.DefaultView[0]["MaterialPn"] = rawMaterialPn;
                }
            }
        }

        private void UpdateOdoo_Click(object sender, EventArgs e)
        {
            DataRow[] changes = GetRowChanges(current: odooProps, original: origOdooProps);
            try
            {
                oProduct.WriteRowChanges(changes);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            GetOdooProduct();
            PullFromOdoo();
            PushToOdoo();
            UpdateChangeIndicators();
        }

        private void BtnErase_Click(object sender, EventArgs e)
        {
            foreach (DataRow drField in this.scaffold.FieldDefs.Select("sw_prop is not null"))
            {
                string fieldName = drField["field"].ToString();
                string fieldType = drField["dt_type"].ToString();
                mainProps.DefaultView[0][fieldName] = SwModelWrapper.GetPropDefaultValue("", fieldType);
            }

            // Update everything
            CorrectInvalidFields(mainProps.DefaultView[0].Row);
            GetOdooProduct();
            PullFromOdoo();
            PushToOdoo();
            UpdateChangeIndicators();
        }

        private void BtnCopyFrom_Click(object sender, EventArgs e)
        {
            // Get a list of configuration names
            List<string> configNames = new List<string>(swMod.ConfigNames);
            configNames.Insert(0, "");
            string currentConfigName = ((ComboboxItem)cboCurrentConfig.SelectedItem).Value;
            configNames.Remove(currentConfigName);

            // Get configuration from which we will copy properties
            string configName = null;
            using (CopyFromSelect.CopyFromSelect form = new CopyFromSelect.CopyFromSelect(configNames))
            {
                var result = form.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                    configName = form.ConfigName;
                else
                    return;
            }

            // Copy SolidWorks custom properties from one row to another
            DataRow drFrom = this.mainProps.Select(String.Format("configname='{0}'", configName))[0];
            DataRow drTo = this.mainProps.DefaultView[0].Row;
            foreach (DataRow drField in scaffold.FieldDefs.Select("sw_prop is not null"))
            {
                string fieldName = drField["field"].ToString();
                drTo[fieldName] = drFrom[fieldName];
            }

            // Update everything
            CorrectInvalidFields(mainProps.DefaultView[0].Row);
            GetOdooProduct();
            PullFromOdoo();
            PushToOdoo();
            UpdateChangeIndicators();
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ComboboxItem(string Text, string Value)
        {
            this.Text = Text;
            this.Value = Value;
        }

        public override string ToString()
        {
            return Text;
        }
    }

}

//
/// We have different sources and destinations and combinations of both for various fields.  Here are a few scenarios:
// filename
//  - not stored in the custom properties
//  - acquired from the SW API
//  - not stored in odoo
// Uom
//  - stored in the custom properties
//  - copied from Odoo to custom properties
//  - not written to Odoo because we aren't using the exact same uom as Odoo
// PartNum
//  - stored in the custom properties
//  - used to look up an odoo product, but not copied from Odoo
//  - not written to Odoo
//
/// Button: Update Odoo
// TODO: Icon indicating changes to odoo data that need to be pushed
// MaterialPN
//  - stored in cust prop
//  - cust prop takes priority
//  - if cust prop not set, overwrite from odoo
//  - write to odoo on change
// ChildQty
//  - if sheet metal, calc from cut list, else store in cust prop
//  - cust prop takes priority
//  - if cust prop not set, overwrite from odoo
//  - write to odoo on change
// RouteTemplate
//  - stored in cust prop
//  - cust prop takes priority
//  - if cust prop not set, overwrite from odoo
//  - write to odoo on change
// CuttingLengthOuter, CuttingLengthInner, CutOutCount, BendCount
//  - not stored in cust prop
//  - calculated from cut list
//  - cut list takes priority
//  - write to odoo
// Notes
//  - stored in the custom properties
//  - odoo takes priority
//  - overwrite cust prop on load
//  - write to Odoo
// HasEtching, NonEcoMod, HoldProduction
//  - not stored in cust prop
//  - pull direct from odoo
//  - write to odoo
//
//
