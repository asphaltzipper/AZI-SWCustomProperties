using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using CookComputing.XmlRpc;
using CredentialManagement;
using OdooClient;
using sw_BOM_Scan;
using SwApiWrapper;

namespace AZI_SWCustomProperties
{
    public partial class MainForm : Form
    {
        private bool formLoading = false;

        private Thread thdOdooLogin;
        private string odooUserStatusLabel;
        private Color odooUserStatusColor;
        private string odooProductStatusLabel;
        private Color odooProductStatusColor;

        //private string odooCredentialTarget = "AZI-SWCustomProperties-OdooUser";
        //private string odooUrl = "https://ando.zipper.azi/xmlrpc";
        //private string odooDb = "mtaylor-odoo";
        private string odooCredentialTarget;
        private string odooUrl;
        private string odooDb;

        private XMLRPCClient odooObject;
        private string licenseKey = Properties.AppSettings.Default.SwLicenseKey;
        private SwModelWrapper swMod;
        private OdooProduct oProduct;
        private SwCustProp props;
        private string productCode;

        public MainForm()
        {
            InitializeComponent();

            formLoading = true;
            SolidWorksConnect();
            PopulateConfigs();

            odooCredentialTarget = Properties.AppSettings.Default.OdooCredentialTarget;
            odooUrl = Properties.UserSettings.Default.OdooUrl;
            odooDb = Properties.UserSettings.Default.OdooDb;
            thdOdooLogin = new Thread(new ThreadStart(OdooLoginControl));
            thdOdooLogin.Start();

            formLoading = false;
        }

        private void SolidWorksConnect()
        {
            // Get solidworks process
            try
            {
                SwApiWrapper.SwApiWrapper swApi = new SwApiWrapper.SwApiWrapper();
                swMod = swApi.MainModel;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            this.props = swMod.GetCustProp("");
            this.productCode = swMod.GetProductCode();
            txtEffectiveCode.Text = this.productCode;
            this.Text = "SW Properties: " + swMod.ModelName;
        }

        private void WriteOdooStatusLabels()
        {
            lblUserStatus.Text = odooUserStatusLabel;
            lblUserStatus.BackColor = odooUserStatusColor;
            lblOdooProduct.Text = odooProductStatusLabel;
            lblOdooProduct.BackColor = odooProductStatusColor;
        }

        private void OdooLoginControl()
        {
            MethodInvoker WriteLabelDelegate = new MethodInvoker(WriteOdooStatusLabels);
            odooUserStatusLabel = "Connecting to Odoo...";
            odooUserStatusColor = Color.Yellow;
            odooProductStatusLabel = "Searching for product...";
            odooProductStatusColor = Color.Yellow;
            Invoke(WriteLabelDelegate);
            OdooLogin();
            if (oProduct == null || oProduct.TemplateRecord == null)
            {
                odooProductStatusLabel = "No Odoo Product";
                odooProductStatusColor = Color.Red;
            }
            Invoke(WriteLabelDelegate);
        }

        private void OdooLogin()
        {
            // https://stackoverflow.com/questions/17741424/retrieve-credentials-from-windows-credentials-store-using-c-sharp
            var cm = new Credential { Target = odooCredentialTarget };
            if (!cm.Load())
            {
                odooUserStatusLabel = "No Credentials Found!";
                odooUserStatusColor = Color.Red;
                return;
            }

            // Get stored username and password
            string odooUsername = cm.Username;
            string odooPassword = cm.Password;

            // Get Odoo connection
            XMLRPCClient oCommon = new XMLRPCClient(odooUrl + "/common");
            try
            {
                oCommon.Login(odooDb, odooUsername, odooPassword);
                odooObject = new XMLRPCClient(odooUrl + "/object");
            }
            catch (Exception exc)
            {
                odooUserStatusLabel = "Odoo Connection Failed: " + exc.Message;
                odooUserStatusColor = Color.Red;
                return;
            }
            if (oCommon.UserId <= 0)
            {
                odooUserStatusLabel = "Failed to login";
                odooUserStatusColor = Color.Red;
                return;
            }
            odooUserStatusLabel = odooUsername;
            odooUserStatusColor = Color.LightGreen;

            // Get Odoo product
            oProduct = new OdooProduct(odooUrl, oCommon, productCode);
            if (oProduct.TemplateRecord != null)
            {
                odooProductStatusLabel = (string)oProduct.TemplateRecord["display_name"];
                odooProductStatusColor = Color.LightGreen;
            }
        }

        private void PopulateConfigs()
        {
            if (swMod == null)
                return;
            cboCurrentConfig.Items.Add(new ComboboxItem("<File Level Properties>", ""));
            foreach (string config in swMod.ConfigNames)
                cboCurrentConfig.Items.Add(new ComboboxItem(config, config));
            cboCurrentConfig.SelectedIndex = 0;
        }

        private void PopulateFormData()
        {
            foreach (KeyValuePair<string, object> prop in props.FieldValues)
            {
                if (this.Controls.ContainsKey(prop.Key))
                    this.Controls[prop.Key].Text = (string)prop.Value;
                if (tabPage1.Controls.ContainsKey(prop.Key))
                    tabPage1.Controls[prop.Key].Text = (string)prop.Value;
                if (tabPage2.Controls.ContainsKey(prop.Key))
                    tabPage2.Controls[prop.Key].Text = (string)prop.Value;
            }
        }

        private bool CheckForChanges()
        {
            foreach (KeyValuePair<string, Object> prop in this.props.FieldValues)
            {
                if (this.Controls.ContainsKey("field" + prop.Key))
                    if (this.Controls[prop.Key].Text != (string)prop.Value)
                        return true;
                if (tabPage1.Controls.ContainsKey(prop.Key))
                    if (tabPage1.Controls[prop.Key].Text != (string)prop.Value)
                        return true;
                if (tabPage2.Controls.ContainsKey(prop.Key))
                    if (tabPage2.Controls[prop.Key].Text != (string)prop.Value)
                        return true;
            }
            return false;
        }

        private bool StoreChanges()
        {
            foreach (KeyValuePair<string, Object> prop in this.props.FieldValues)
            {
                if (this.Controls.ContainsKey("field" + prop.Key))
                    props.UpdateFieldValue(prop.Key, this.Controls[prop.Key].Text);
                if (tabPage1.Controls.ContainsKey(prop.Key))
                    props.UpdateFieldValue(prop.Key, tabPage1.Controls[prop.Key].Text);
                if (tabPage2.Controls.ContainsKey(prop.Key))
                    props.UpdateFieldValue(prop.Key, tabPage2.Controls[prop.Key].Text);
            }
            return false;
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
            SolidWorksConnect();
        }

        private void BtnBomScan_Click(object sender, EventArgs e)
        {
            BomScan bomScan = new BomScan(swMod);
            bomScan.ShowDialog(this);
        }

        private void BtnGetImage_Click(object sender, EventArgs e)
        {
            //if (oProduct == null)
            //    return;
            ImageForm.ImageForm imgForm = new ImageForm.ImageForm(swMod, oProduct);
            imgForm.ShowDialog();
        }

        private void CboCurrentConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formLoading && CheckForChanges())
            {
                System.Windows.Forms.DialogResult result = MessageBox.Show(
                    "Data has changed.  Do you want to discard changes?",
                    "Discard Changes",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;
            }
            swMod.ConfigName = (string)((ComboboxItem)cboCurrentConfig.SelectedItem).Value;
            props = swMod.GetCustProp((string)((ComboboxItem)cboCurrentConfig.SelectedItem).Value);
            PopulateFormData();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CheckForChanges())
            {
                System.Windows.Forms.DialogResult result = MessageBox.Show(
                    "Data has changed.  Do you want to discard changes?",
                    "Discard Changes",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
            thdOdooLogin.Abort();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            StoreChanges();
            swMod.WriteCustProp(props, (string)((ComboboxItem)cboCurrentConfig.SelectedItem).Value);
            props = swMod.GetCustProp((string)((ComboboxItem)cboCurrentConfig.SelectedItem).Value);
            PopulateFormData();
        }

        private void BtnApplyClose_Click(object sender, EventArgs e)
        {
            BtnApply_Click(sender, e);
            this.Close();
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

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
