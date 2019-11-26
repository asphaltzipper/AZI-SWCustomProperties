using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZI_SWCustomProperties
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        public void UpdateStatus(string statusMessage, Color backColor)
        {
            if (label1.InvokeRequired == false)
            {
                lblStatus.Text = statusMessage;
                lblStatus.BackColor = backColor;
            }
            else
            {
                lblStatus.Invoke((MethodInvoker)(() => lblStatus.Text = statusMessage));
                lblStatus.Invoke((MethodInvoker)(() => lblStatus.BackColor = backColor));
            }
        }

        public void AddStatusLine(string Action, string Description)
        {
            string[] strStatusParams = new String[2] { Action, Description };
            AddStatusLine(strStatusParams);
        }

        private delegate void AddStatusLineDel(string[] Params);
        private void AddStatusLine(string[] Params)
        {
            if (this.InvokeRequired)
            {
                // this is a worker thread so delegate the task to the UI thread
                AddStatusLineDel del = new AddStatusLineDel(AddStatusLine);
                this.Invoke(del, (object)Params);
            }
            else
            {
                // we are executing in the UI thread
                ListViewItem lvItem = new ListViewItem(Params);

                // set background color, based on status action
                if (Params[0] == "NORMAL") { lvItem.BackColor = Color.White; }
                else if (Params[0] == "OKAY") { lvItem.BackColor = Color.Green; }
                else if (Params[0] == "WARNING") { lvItem.BackColor = Color.Yellow; }
                else if (Params[0] == "ERROR") { lvItem.BackColor = Color.Red; }

                lvMessages.Items.Add(lvItem);
                lvMessages.EnsureVisible(lvMessages.Items.Count - 1);
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm setForm = new SettingsForm();
            setForm.ShowDialog(this);
            this.DialogResult = DialogResult.No;
        }
    }
}
