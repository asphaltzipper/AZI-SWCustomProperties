using System;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RawMaterialSelect
{
    public partial class RawMaterialSelect : Form
    {
        //private DataSet dsOdoo;
        private DataTable dtRawMaterial;
        public string RawMaterialPn { get; set; }

        public RawMaterialSelect(DataTable dt)
        {
            InitializeComponent();
            dtRawMaterial = dt;
            dsOdoo.Tables.Add(dtRawMaterial);

            foreach (DataRow dr in dtRawMaterial.Rows)
            {
                AddUniqueCboItem(cboCode, dr["default_code"]);
                AddUniqueCboItem(cboName, dr["name"]);
                AddUniqueCboItem(cboUom, dr["uom_name"]);
                AddUniqueCboItem(cboCat, dr["categ_name"]);
            }

            dgRawMaterial.AutoGenerateColumns = false;
            dgRawMaterial.DataSource = dtRawMaterial;

            cboCode.Width = dgRawMaterial.Columns["default_code"].Width;
            cboName.Left = cboCode.Left + cboCode.Width;
            cboName.Width = dgRawMaterial.Columns["name"].Width;
            cboUom.Left = cboName.Left + cboName.Width;
            cboUom.Width = dgRawMaterial.Columns["uom_name"].Width;
            cboCat.Left = cboUom.Left + cboUom.Width;
            cboCat.Width = dgRawMaterial.Columns["categ_name"].Width;

            dgRawMaterial.Columns["default_code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgRawMaterial.Columns["default_code"].Width = cboCode.Width;
            dgRawMaterial.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgRawMaterial.Columns["name"].Width = cboName.Width;
            dgRawMaterial.Columns["uom_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgRawMaterial.Columns["uom_name"].Width = cboUom.Width;
            dgRawMaterial.Columns["categ_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgRawMaterial.Columns["categ_name"].Width = cboCat.Width;
        }

        private void AddUniqueCboItem(ComboBox comboBox, object itemValue)
        {
            if (!comboBox.Items.Contains(itemValue))
                comboBox.Items.Add(itemValue);
        }

        private string EscapeLikeValue(string value)
        {
            StringBuilder sb = new StringBuilder(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                switch (c)
                {
                    case ']':
                    case '[':
                    case '%':
                    case '*':
                        sb.Append("[").Append(c).Append("]");
                        break;
                    case '\'':
                        sb.Append("''");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string codeLike = cboCode.Text;
            string nameLike = cboName.Text;
            string uomLike = cboUom.Text;
            string catLike = cboCat.Text;

            List<string> filterSet = new List<string>();
            if (codeLike != null & codeLike != "")
            { filterSet.Add(string.Format("default_code like '%{0}%'", EscapeLikeValue(codeLike))); }
            if (nameLike != null & nameLike != "")
            { filterSet.Add(string.Format("name like '%{0}%'", EscapeLikeValue(nameLike))); }
            if (uomLike != null & uomLike != "")
            { filterSet.Add(string.Format("uom_name like '%{0}%'", EscapeLikeValue(uomLike))); }
            if (catLike != null & catLike != "")
            { filterSet.Add(string.Format("categ_name like '%{0}%'", EscapeLikeValue(catLike))); }

            string filter = String.Join(" and ", filterSet);

            dsOdoo.Tables["raw_material"].DefaultView.RowFilter = filter;
            dgRawMaterial.Refresh();
        }

        private void DgRawMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                this.RawMaterialPn = senderGrid.Rows[e.RowIndex].Cells["default_code"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
