namespace AZI_SWCustomProperties
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnBomScan = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnGetImage = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblUserStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblOdooProduct = new System.Windows.Forms.ToolStripStatusLabel();
            this.cboCurrentConfig = new System.Windows.Forms.ComboBox();
            this.lblCurrentConfig = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnApplyClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSettings,
            this.btnRefresh,
            this.btnBomScan,
            this.btnGetImage,
            this.lblCurrentFile,
            this.lblUserStatus,
            this.lblOdooProduct});
            this.statusStrip1.Location = new System.Drawing.Point(0, 506);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(791, 24);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnSettings
            // 
            this.btnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.ShowDropDownArrow = false;
            this.btnSettings.Size = new System.Drawing.Size(20, 22);
            this.btnSettings.Text = "Settings";
            this.btnSettings.ToolTipText = "Settings";
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ShowDropDownArrow = false;
            this.btnRefresh.Size = new System.Drawing.Size(20, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnBomScan
            // 
            this.btnBomScan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBomScan.Image = ((System.Drawing.Image)(resources.GetObject("btnBomScan.Image")));
            this.btnBomScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBomScan.Name = "btnBomScan";
            this.btnBomScan.ShowDropDownArrow = false;
            this.btnBomScan.Size = new System.Drawing.Size(20, 22);
            this.btnBomScan.Text = "toolStripDropDownButton1";
            this.btnBomScan.Click += new System.EventHandler(this.BtnBomScan_Click);
            // 
            // btnGetImage
            // 
            this.btnGetImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGetImage.Image = ((System.Drawing.Image)(resources.GetObject("btnGetImage.Image")));
            this.btnGetImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGetImage.Name = "btnGetImage";
            this.btnGetImage.ShowDropDownArrow = false;
            this.btnGetImage.Size = new System.Drawing.Size(20, 22);
            this.btnGetImage.Text = "toolStripDropDownButton1";
            this.btnGetImage.Click += new System.EventHandler(this.BtnGetImage_Click);
            // 
            // lblUserStatus
            // 
            this.lblUserStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblUserStatus.Name = "lblUserStatus";
            this.lblUserStatus.Size = new System.Drawing.Size(86, 19);
            this.lblUserStatus.Text = "No Odoo User";
            this.lblUserStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(91, 19);
            this.lblCurrentFile.Text = "No Current File";
            this.lblCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOdooProduct
            // 
            this.lblOdooProduct.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblOdooProduct.Name = "lblOdooProduct";
            this.lblOdooProduct.Size = new System.Drawing.Size(105, 19);
            this.lblOdooProduct.Text = "No Odoo Product";
            // 
            // cboCurrentConfig
            // 
            this.cboCurrentConfig.FormattingEnabled = true;
            this.cboCurrentConfig.Location = new System.Drawing.Point(53, 6);
            this.cboCurrentConfig.Name = "cboCurrentConfig";
            this.cboCurrentConfig.Size = new System.Drawing.Size(201, 21);
            this.cboCurrentConfig.TabIndex = 1;
            this.cboCurrentConfig.SelectedIndexChanged += new System.EventHandler(this.CboCurrentConfig_SelectedIndexChanged);
            // 
            // lblCurrentConfig
            // 
            this.lblCurrentConfig.AutoSize = true;
            this.lblCurrentConfig.Location = new System.Drawing.Point(12, 9);
            this.lblCurrentConfig.Name = "lblCurrentConfig";
            this.lblCurrentConfig.Size = new System.Drawing.Size(37, 13);
            this.lblCurrentConfig.TabIndex = 2;
            this.lblCurrentConfig.Text = "Config";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(623, 480);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnApplyClose
            // 
            this.btnApplyClose.Location = new System.Drawing.Point(542, 480);
            this.btnApplyClose.Name = "btnApplyClose";
            this.btnApplyClose.Size = new System.Drawing.Size(75, 23);
            this.btnApplyClose.TabIndex = 4;
            this.btnApplyClose.Text = "Apply/Close";
            this.btnApplyClose.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(704, 480);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Location = new System.Drawing.Point(275, 14);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(44, 13);
            this.lblProductCode.TabIndex = 7;
            this.lblProductCode.Text = "No P/N";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 530);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApplyClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblCurrentConfig);
            this.Controls.Add(this.cboCurrentConfig);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SW Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton btnSettings;
        private System.Windows.Forms.ToolStripStatusLabel lblUserStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentFile;
        private System.Windows.Forms.ToolStripDropDownButton btnRefresh;
        private System.Windows.Forms.ToolStripDropDownButton btnBomScan;
        private System.Windows.Forms.ToolStripDropDownButton btnGetImage;
        private System.Windows.Forms.ComboBox cboCurrentConfig;
        private System.Windows.Forms.Label lblCurrentConfig;
        private System.Windows.Forms.ToolStripStatusLabel lblOdooProduct;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnApplyClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblProductCode;
    }
}

