using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CredentialManagement;

namespace AZI_SWCustomProperties
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            txtOdooUrl.Text = Properties.UserSettings.Default.OdooUrl;
            txtOdooDb.Text = Properties.UserSettings.Default.OdooDb;
            txtSwKey.Text = Properties.AppSettings.Default.SwLicenseKey;
            var cm = new Credential { Target = Properties.AppSettings.Default.OdooCredentialTarget };
            if (cm.Load())
            {
                txtOdooUser.Text = cm.Username;
                txtOdooPass.Text = cm.Password;
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            Properties.UserSettings.Default.OdooDb = txtOdooDb.Text;
            Properties.UserSettings.Default.OdooUrl = txtOdooUrl.Text;
            Properties.AppSettings.Default.SwLicenseKey = txtSwKey.Text;
            Properties.UserSettings.Default.Save();
            Properties.AppSettings.Default.Save();

            var cm = new Credential { Target = Properties.AppSettings.Default.OdooCredentialTarget };
            if (cm.Load())
                cm.Delete();

            Credential cred = new Credential
            {
                Target = Properties.AppSettings.Default.OdooCredentialTarget,
                Username = txtOdooUser.Text,
                Password = txtOdooPass.Text,
                PersistanceType = PersistanceType.LocalComputer
            };
            cred.Save();

            Close();
        }
    }
}
