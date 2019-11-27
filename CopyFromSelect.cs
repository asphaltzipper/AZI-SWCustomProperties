using System;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CopyFromSelect
{
    public partial class CopyFromSelect : Form
    {
        //private DataSet dsOdoo;
        private DataTable dtRawMaterial;
        public string ConfigName { get; set; }

        public CopyFromSelect(List<string> configNames)
        {
            InitializeComponent();
            foreach (string name in configNames)
                if (name == "")
                    cboConfigs.Items.Add(new ComboboxItem("<File Level Properties>", name));
                else
                    cboConfigs.Items.Add(new ComboboxItem(name, name));
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmdSelect_Click(object sender, EventArgs e)
        {
            string currentConfigName = ((ComboboxItem)cboConfigs.SelectedItem).Value;
            this.ConfigName = currentConfigName;
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
