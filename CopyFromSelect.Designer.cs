namespace CopyFromSelect
{
    partial class CopyFromSelect
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dsOdoo = new System.Data.DataSet();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboConfigs = new System.Windows.Forms.ComboBox();
            this.cmdSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dsOdoo)).BeginInit();
            this.SuspendLayout();
            // 
            // dsOdoo
            // 
            this.dsOdoo.DataSetName = "NewDataSet";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(587, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // cboConfigs
            // 
            this.cboConfigs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConfigs.FormattingEnabled = true;
            this.cboConfigs.Location = new System.Drawing.Point(12, 13);
            this.cboConfigs.Name = "cboConfigs";
            this.cboConfigs.Size = new System.Drawing.Size(488, 21);
            this.cboConfigs.TabIndex = 28;
            // 
            // cmdSelect
            // 
            this.cmdSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdSelect.Location = new System.Drawing.Point(506, 11);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(75, 23);
            this.cmdSelect.TabIndex = 29;
            this.cmdSelect.Text = "Copy";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.CmdSelect_Click);
            // 
            // CopyFromSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 46);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.cboConfigs);
            this.Controls.Add(this.btnCancel);
            this.Name = "CopyFromSelect";
            this.Text = "Copy Properties From Config";
            ((System.ComponentModel.ISupportInitialize)(this.dsOdoo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Data.DataSet dsOdoo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboConfigs;
        private System.Windows.Forms.Button cmdSelect;
    }
}

