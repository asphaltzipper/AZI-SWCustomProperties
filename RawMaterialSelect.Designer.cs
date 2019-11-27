namespace RawMaterialSelect
{
    partial class RawMaterialSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cboCode = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dsOdoo = new System.Data.DataSet();
            this.dgRawMaterial = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.default_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uom_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categ_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.cboUom = new System.Windows.Forms.ComboBox();
            this.cboCat = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dsOdoo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRawMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // cboCode
            // 
            this.cboCode.FormattingEnabled = true;
            this.cboCode.Location = new System.Drawing.Point(55, 11);
            this.cboCode.Name = "cboCode";
            this.cboCode.Size = new System.Drawing.Size(57, 21);
            this.cboCode.TabIndex = 17;
            this.cboCode.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // dsOdoo
            // 
            this.dsOdoo.DataSetName = "NewDataSet";
            // 
            // dgRawMaterial
            // 
            this.dgRawMaterial.AllowUserToAddRows = false;
            this.dgRawMaterial.AllowUserToDeleteRows = false;
            this.dgRawMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRawMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRawMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.default_code,
            this.name,
            this.uom_name,
            this.categ_name,
            this.action});
            this.dgRawMaterial.Location = new System.Drawing.Point(13, 38);
            this.dgRawMaterial.Name = "dgRawMaterial";
            this.dgRawMaterial.ReadOnly = true;
            this.dgRawMaterial.Size = new System.Drawing.Size(552, 353);
            this.dgRawMaterial.TabIndex = 23;
            this.dgRawMaterial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgRawMaterial_CellContentClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // default_code
            // 
            this.default_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.default_code.DataPropertyName = "default_code";
            this.default_code.HeaderText = "Code";
            this.default_code.Name = "default_code";
            this.default_code.ReadOnly = true;
            this.default_code.Width = 57;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 60;
            // 
            // uom_name
            // 
            this.uom_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.uom_name.DataPropertyName = "uom_name";
            this.uom_name.HeaderText = "UOM";
            this.uom_name.Name = "uom_name";
            this.uom_name.ReadOnly = true;
            this.uom_name.Width = 57;
            // 
            // categ_name
            // 
            this.categ_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.categ_name.DataPropertyName = "categ_name";
            this.categ_name.HeaderText = "Category";
            this.categ_name.Name = "categ_name";
            this.categ_name.ReadOnly = true;
            this.categ_name.Width = 74;
            // 
            // action
            // 
            this.action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.action.FillWeight = 50F;
            this.action.HeaderText = "Action";
            this.action.Name = "action";
            this.action.ReadOnly = true;
            this.action.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.action.Text = "Apply";
            this.action.UseColumnTextForButtonValue = true;
            this.action.Width = 50;
            // 
            // cboName
            // 
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(112, 11);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(60, 21);
            this.cboName.TabIndex = 24;
            this.cboName.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // cboUom
            // 
            this.cboUom.FormattingEnabled = true;
            this.cboUom.Location = new System.Drawing.Point(172, 11);
            this.cboUom.Name = "cboUom";
            this.cboUom.Size = new System.Drawing.Size(57, 21);
            this.cboUom.TabIndex = 25;
            this.cboUom.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // cboCat
            // 
            this.cboCat.FormattingEnabled = true;
            this.cboCat.Location = new System.Drawing.Point(229, 11);
            this.cboCat.Name = "cboCat";
            this.cboCat.Size = new System.Drawing.Size(74, 21);
            this.cboCat.TabIndex = 26;
            this.cboCat.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(491, 397);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // RawMaterialSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 432);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cboCat);
            this.Controls.Add(this.cboUom);
            this.Controls.Add(this.cboName);
            this.Controls.Add(this.dgRawMaterial);
            this.Controls.Add(this.cboCode);
            this.Name = "RawMaterialSelect";
            this.Text = "Select Raw Material";
            ((System.ComponentModel.ISupportInitialize)(this.dsOdoo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRawMaterial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cboCode;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Data.DataSet dsOdoo;
        private System.Windows.Forms.DataGridView dgRawMaterial;
        private System.Windows.Forms.ComboBox cboName;
        private System.Windows.Forms.ComboBox cboUom;
        private System.Windows.Forms.ComboBox cboCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn default_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn uom_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn categ_name;
        private System.Windows.Forms.DataGridViewButtonColumn action;
        private System.Windows.Forms.Button btnCancel;
    }
}

