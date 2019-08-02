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
            this.lblOdooProduct = new System.Windows.Forms.ToolStripStatusLabel();
            this.cboCurrentConfig = new System.Windows.Forms.ComboBox();
            this.lblCurrentConfig = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnApplyClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblEcoChks = new System.Windows.Forms.Label();
            this.EcoChks = new System.Windows.Forms.TextBox();
            this.lblEcoDates = new System.Windows.Forms.Label();
            this.EcoDates = new System.Windows.Forms.TextBox();
            this.lblEcoDescriptions = new System.Windows.Forms.Label();
            this.EcoDescriptions = new System.Windows.Forms.TextBox();
            this.lblZone = new System.Windows.Forms.Label();
            this.Zone = new System.Windows.Forms.TextBox();
            this.lblEcoRevs = new System.Windows.Forms.Label();
            this.EcoRevs = new System.Windows.Forms.TextBox();
            this.lblEcos = new System.Windows.Forms.Label();
            this.Ecos = new System.Windows.Forms.TextBox();
            this.lblRevision = new System.Windows.Forms.Label();
            this.Revision = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.Notes = new System.Windows.Forms.TextBox();
            this.Coating = new System.Windows.Forms.TextBox();
            this.lblCoating = new System.Windows.Forms.Label();
            this.Finish = new System.Windows.Forms.TextBox();
            this.lblFinish = new System.Windows.Forms.Label();
            this.Material = new System.Windows.Forms.TextBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblAltQty = new System.Windows.Forms.Label();
            this.AltQty = new System.Windows.Forms.TextBox();
            this.Catalog = new System.Windows.Forms.ComboBox();
            this.lblCatalog = new System.Windows.Forms.Label();
            this.lblDrawDate = new System.Windows.Forms.Label();
            this.Uom = new System.Windows.Forms.ComboBox();
            this.lblUom = new System.Windows.Forms.Label();
            this.Type = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDesignedBy = new System.Windows.Forms.Label();
            this.DesignedBy = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.TextBox();
            this.lblPartNum = new System.Windows.Forms.Label();
            this.PartNum = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblForEffectiveCode = new System.Windows.Forms.Label();
            this.txtEffectiveCode = new System.Windows.Forms.TextBox();
            this.DrawDate = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSettings,
            this.btnRefresh,
            this.btnBomScan,
            this.btnGetImage,
            this.lblUserStatus,
            this.lblOdooProduct});
            this.statusStrip1.Location = new System.Drawing.Point(0, 506);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(670, 24);
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
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(494, 480);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(80, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // btnApplyClose
            // 
            this.btnApplyClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyClose.Location = new System.Drawing.Point(411, 480);
            this.btnApplyClose.Name = "btnApplyClose";
            this.btnApplyClose.Size = new System.Drawing.Size(80, 23);
            this.btnApplyClose.TabIndex = 4;
            this.btnApplyClose.Text = "Apply/Close";
            this.btnApplyClose.UseVisualStyleBackColor = true;
            this.btnApplyClose.Click += new System.EventHandler(this.BtnApplyClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(578, 480);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(646, 441);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DrawDate);
            this.tabPage1.Controls.Add(this.lblEcoChks);
            this.tabPage1.Controls.Add(this.EcoChks);
            this.tabPage1.Controls.Add(this.lblEcoDates);
            this.tabPage1.Controls.Add(this.EcoDates);
            this.tabPage1.Controls.Add(this.lblEcoDescriptions);
            this.tabPage1.Controls.Add(this.EcoDescriptions);
            this.tabPage1.Controls.Add(this.lblZone);
            this.tabPage1.Controls.Add(this.Zone);
            this.tabPage1.Controls.Add(this.lblEcoRevs);
            this.tabPage1.Controls.Add(this.EcoRevs);
            this.tabPage1.Controls.Add(this.lblEcos);
            this.tabPage1.Controls.Add(this.Ecos);
            this.tabPage1.Controls.Add(this.lblRevision);
            this.tabPage1.Controls.Add(this.Revision);
            this.tabPage1.Controls.Add(this.lblNotes);
            this.tabPage1.Controls.Add(this.Notes);
            this.tabPage1.Controls.Add(this.Coating);
            this.tabPage1.Controls.Add(this.lblCoating);
            this.tabPage1.Controls.Add(this.Finish);
            this.tabPage1.Controls.Add(this.lblFinish);
            this.tabPage1.Controls.Add(this.Material);
            this.tabPage1.Controls.Add(this.lblMaterial);
            this.tabPage1.Controls.Add(this.lblAltQty);
            this.tabPage1.Controls.Add(this.AltQty);
            this.tabPage1.Controls.Add(this.Catalog);
            this.tabPage1.Controls.Add(this.lblCatalog);
            this.tabPage1.Controls.Add(this.lblDrawDate);
            this.tabPage1.Controls.Add(this.Uom);
            this.tabPage1.Controls.Add(this.lblUom);
            this.tabPage1.Controls.Add(this.Type);
            this.tabPage1.Controls.Add(this.lblType);
            this.tabPage1.Controls.Add(this.lblDesignedBy);
            this.tabPage1.Controls.Add(this.DesignedBy);
            this.tabPage1.Controls.Add(this.lblDescription);
            this.tabPage1.Controls.Add(this.Description);
            this.tabPage1.Controls.Add(this.lblPartNum);
            this.tabPage1.Controls.Add(this.PartNum);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(638, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblEcoChks
            // 
            this.lblEcoChks.AutoSize = true;
            this.lblEcoChks.Location = new System.Drawing.Point(579, 146);
            this.lblEcoChks.Name = "lblEcoChks";
            this.lblEcoChks.Size = new System.Drawing.Size(26, 13);
            this.lblEcoChks.TabIndex = 38;
            this.lblEcoChks.Text = "Chk";
            // 
            // EcoChks
            // 
            this.EcoChks.Location = new System.Drawing.Point(582, 162);
            this.EcoChks.Multiline = true;
            this.EcoChks.Name = "EcoChks";
            this.EcoChks.Size = new System.Drawing.Size(48, 94);
            this.EcoChks.TabIndex = 37;
            // 
            // lblEcoDates
            // 
            this.lblEcoDates.AutoSize = true;
            this.lblEcoDates.Location = new System.Drawing.Point(525, 146);
            this.lblEcoDates.Name = "lblEcoDates";
            this.lblEcoDates.Size = new System.Drawing.Size(30, 13);
            this.lblEcoDates.TabIndex = 36;
            this.lblEcoDates.Text = "Date";
            // 
            // EcoDates
            // 
            this.EcoDates.Location = new System.Drawing.Point(528, 162);
            this.EcoDates.Multiline = true;
            this.EcoDates.Name = "EcoDates";
            this.EcoDates.Size = new System.Drawing.Size(48, 94);
            this.EcoDates.TabIndex = 35;
            // 
            // lblEcoDescriptions
            // 
            this.lblEcoDescriptions.AutoSize = true;
            this.lblEcoDescriptions.Location = new System.Drawing.Point(139, 146);
            this.lblEcoDescriptions.Name = "lblEcoDescriptions";
            this.lblEcoDescriptions.Size = new System.Drawing.Size(60, 13);
            this.lblEcoDescriptions.TabIndex = 34;
            this.lblEcoDescriptions.Text = "Description";
            // 
            // EcoDescriptions
            // 
            this.EcoDescriptions.Location = new System.Drawing.Point(142, 162);
            this.EcoDescriptions.Multiline = true;
            this.EcoDescriptions.Name = "EcoDescriptions";
            this.EcoDescriptions.Size = new System.Drawing.Size(380, 94);
            this.EcoDescriptions.TabIndex = 33;
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.Location = new System.Drawing.Point(101, 146);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(32, 13);
            this.lblZone.TabIndex = 32;
            this.lblZone.Text = "Zone";
            // 
            // Zone
            // 
            this.Zone.Location = new System.Drawing.Point(104, 162);
            this.Zone.Multiline = true;
            this.Zone.Name = "Zone";
            this.Zone.Size = new System.Drawing.Size(32, 94);
            this.Zone.TabIndex = 31;
            // 
            // lblEcoRevs
            // 
            this.lblEcoRevs.AutoSize = true;
            this.lblEcoRevs.Location = new System.Drawing.Point(63, 146);
            this.lblEcoRevs.Name = "lblEcoRevs";
            this.lblEcoRevs.Size = new System.Drawing.Size(27, 13);
            this.lblEcoRevs.TabIndex = 30;
            this.lblEcoRevs.Text = "Rev";
            // 
            // EcoRevs
            // 
            this.EcoRevs.Location = new System.Drawing.Point(66, 162);
            this.EcoRevs.Multiline = true;
            this.EcoRevs.Name = "EcoRevs";
            this.EcoRevs.Size = new System.Drawing.Size(32, 94);
            this.EcoRevs.TabIndex = 29;
            // 
            // lblEcos
            // 
            this.lblEcos.AutoSize = true;
            this.lblEcos.Location = new System.Drawing.Point(3, 146);
            this.lblEcos.Name = "lblEcos";
            this.lblEcos.Size = new System.Drawing.Size(39, 13);
            this.lblEcos.TabIndex = 28;
            this.lblEcos.Text = "ECO #";
            // 
            // Ecos
            // 
            this.Ecos.Location = new System.Drawing.Point(6, 162);
            this.Ecos.Multiline = true;
            this.Ecos.Name = "Ecos";
            this.Ecos.Size = new System.Drawing.Size(54, 94);
            this.Ecos.TabIndex = 27;
            // 
            // lblRevision
            // 
            this.lblRevision.AutoSize = true;
            this.lblRevision.Location = new System.Drawing.Point(312, 9);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(64, 13);
            this.lblRevision.TabIndex = 26;
            this.lblRevision.Text = "Current Rev";
            // 
            // Revision
            // 
            this.Revision.Location = new System.Drawing.Point(384, 6);
            this.Revision.Name = "Revision";
            this.Revision.Size = new System.Drawing.Size(39, 20);
            this.Revision.TabIndex = 25;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(6, 61);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 24;
            this.lblNotes.Text = "Notes";
            // 
            // Notes
            // 
            this.Notes.AcceptsReturn = true;
            this.Notes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Notes.Location = new System.Drawing.Point(55, 58);
            this.Notes.Multiline = true;
            this.Notes.Name = "Notes";
            this.Notes.Size = new System.Drawing.Size(577, 63);
            this.Notes.TabIndex = 23;
            // 
            // Coating
            // 
            this.Coating.Location = new System.Drawing.Point(503, 389);
            this.Coating.Name = "Coating";
            this.Coating.Size = new System.Drawing.Size(127, 20);
            this.Coating.TabIndex = 22;
            // 
            // lblCoating
            // 
            this.lblCoating.AutoSize = true;
            this.lblCoating.Location = new System.Drawing.Point(439, 392);
            this.lblCoating.Name = "lblCoating";
            this.lblCoating.Size = new System.Drawing.Size(43, 13);
            this.lblCoating.TabIndex = 21;
            this.lblCoating.Text = "Coating";
            // 
            // Finish
            // 
            this.Finish.Location = new System.Drawing.Point(503, 363);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(127, 20);
            this.Finish.TabIndex = 20;
            // 
            // lblFinish
            // 
            this.lblFinish.AutoSize = true;
            this.lblFinish.Location = new System.Drawing.Point(439, 366);
            this.lblFinish.Name = "lblFinish";
            this.lblFinish.Size = new System.Drawing.Size(34, 13);
            this.lblFinish.TabIndex = 19;
            this.lblFinish.Text = "Finish";
            // 
            // Material
            // 
            this.Material.Location = new System.Drawing.Point(503, 337);
            this.Material.Name = "Material";
            this.Material.Size = new System.Drawing.Size(127, 20);
            this.Material.TabIndex = 18;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(439, 340);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(44, 13);
            this.lblMaterial.TabIndex = 17;
            this.lblMaterial.Text = "Material";
            // 
            // lblAltQty
            // 
            this.lblAltQty.AutoSize = true;
            this.lblAltQty.Location = new System.Drawing.Point(288, 366);
            this.lblAltQty.Name = "lblAltQty";
            this.lblAltQty.Size = new System.Drawing.Size(38, 13);
            this.lblAltQty.TabIndex = 16;
            this.lblAltQty.Text = "Alt Qty";
            // 
            // AltQty
            // 
            this.AltQty.Location = new System.Drawing.Point(352, 363);
            this.AltQty.Name = "AltQty";
            this.AltQty.Size = new System.Drawing.Size(53, 20);
            this.AltQty.TabIndex = 15;
            // 
            // Catalog
            // 
            this.Catalog.FormattingEnabled = true;
            this.Catalog.Items.AddRange(new object[] {
            "P",
            "M"});
            this.Catalog.Location = new System.Drawing.Point(70, 360);
            this.Catalog.Name = "Catalog";
            this.Catalog.Size = new System.Drawing.Size(53, 21);
            this.Catalog.TabIndex = 14;
            // 
            // lblCatalog
            // 
            this.lblCatalog.AutoSize = true;
            this.lblCatalog.Location = new System.Drawing.Point(6, 363);
            this.lblCatalog.Name = "lblCatalog";
            this.lblCatalog.Size = new System.Drawing.Size(43, 13);
            this.lblCatalog.TabIndex = 13;
            this.lblCatalog.Text = "Catalog";
            // 
            // lblDrawDate
            // 
            this.lblDrawDate.AutoSize = true;
            this.lblDrawDate.Location = new System.Drawing.Point(475, 9);
            this.lblDrawDate.Name = "lblDrawDate";
            this.lblDrawDate.Size = new System.Drawing.Size(58, 13);
            this.lblDrawDate.TabIndex = 11;
            this.lblDrawDate.Text = "Draw Date";
            // 
            // Uom
            // 
            this.Uom.FormattingEnabled = true;
            this.Uom.Items.AddRange(new object[] {
            "P",
            "M"});
            this.Uom.Location = new System.Drawing.Point(352, 336);
            this.Uom.Name = "Uom";
            this.Uom.Size = new System.Drawing.Size(53, 21);
            this.Uom.TabIndex = 10;
            // 
            // lblUom
            // 
            this.lblUom.AutoSize = true;
            this.lblUom.Location = new System.Drawing.Point(288, 339);
            this.lblUom.Name = "lblUom";
            this.lblUom.Size = new System.Drawing.Size(32, 13);
            this.lblUom.TabIndex = 9;
            this.lblUom.Text = "UOM";
            // 
            // Type
            // 
            this.Type.FormattingEnabled = true;
            this.Type.Items.AddRange(new object[] {
            "P",
            "W",
            "A",
            "H",
            "K",
            "S"});
            this.Type.Location = new System.Drawing.Point(207, 337);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(53, 21);
            this.Type.TabIndex = 8;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(143, 340);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "Type";
            // 
            // lblDesignedBy
            // 
            this.lblDesignedBy.AutoSize = true;
            this.lblDesignedBy.Location = new System.Drawing.Point(6, 337);
            this.lblDesignedBy.Name = "lblDesignedBy";
            this.lblDesignedBy.Size = new System.Drawing.Size(49, 13);
            this.lblDesignedBy.TabIndex = 5;
            this.lblDesignedBy.Text = "Designer";
            // 
            // DesignedBy
            // 
            this.DesignedBy.Location = new System.Drawing.Point(70, 334);
            this.DesignedBy.Name = "DesignedBy";
            this.DesignedBy.Size = new System.Drawing.Size(39, 20);
            this.DesignedBy.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 35);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(32, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Desc";
            // 
            // Description
            // 
            this.Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Description.Location = new System.Drawing.Point(55, 32);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(577, 20);
            this.Description.TabIndex = 2;
            // 
            // lblPartNum
            // 
            this.lblPartNum.AutoSize = true;
            this.lblPartNum.Location = new System.Drawing.Point(6, 9);
            this.lblPartNum.Name = "lblPartNum";
            this.lblPartNum.Size = new System.Drawing.Size(43, 13);
            this.lblPartNum.TabIndex = 1;
            this.lblPartNum.Text = "Part No";
            // 
            // PartNum
            // 
            this.PartNum.Location = new System.Drawing.Point(55, 6);
            this.PartNum.Name = "PartNum";
            this.PartNum.Size = new System.Drawing.Size(205, 20);
            this.PartNum.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(759, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblForEffectiveCode
            // 
            this.lblForEffectiveCode.AutoSize = true;
            this.lblForEffectiveCode.Location = new System.Drawing.Point(289, 9);
            this.lblForEffectiveCode.Name = "lblForEffectiveCode";
            this.lblForEffectiveCode.Size = new System.Drawing.Size(72, 13);
            this.lblForEffectiveCode.TabIndex = 9;
            this.lblForEffectiveCode.Text = "Effective P/N";
            // 
            // txtEffectiveCode
            // 
            this.txtEffectiveCode.Location = new System.Drawing.Point(367, 7);
            this.txtEffectiveCode.Name = "txtEffectiveCode";
            this.txtEffectiveCode.ReadOnly = true;
            this.txtEffectiveCode.Size = new System.Drawing.Size(124, 20);
            this.txtEffectiveCode.TabIndex = 10;
            // 
            // DrawDate
            // 
            this.DrawDate.Location = new System.Drawing.Point(538, 6);
            this.DrawDate.Name = "DrawDate";
            this.DrawDate.Size = new System.Drawing.Size(94, 20);
            this.DrawDate.TabIndex = 39;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 530);
            this.Controls.Add(this.txtEffectiveCode);
            this.Controls.Add(this.lblForEffectiveCode);
            this.Controls.Add(this.tabControl1);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton btnSettings;
        private System.Windows.Forms.ToolStripStatusLabel lblUserStatus;
        private System.Windows.Forms.ToolStripDropDownButton btnRefresh;
        private System.Windows.Forms.ToolStripDropDownButton btnBomScan;
        private System.Windows.Forms.ToolStripDropDownButton btnGetImage;
        private System.Windows.Forms.ComboBox cboCurrentConfig;
        private System.Windows.Forms.Label lblCurrentConfig;
        private System.Windows.Forms.ToolStripStatusLabel lblOdooProduct;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnApplyClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblForEffectiveCode;
        private System.Windows.Forms.TextBox txtEffectiveCode;
        private System.Windows.Forms.Label lblPartNum;
        private System.Windows.Forms.TextBox PartNum;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.ComboBox Catalog;
        private System.Windows.Forms.Label lblCatalog;
        private System.Windows.Forms.Label lblDrawDate;
        private System.Windows.Forms.ComboBox Uom;
        private System.Windows.Forms.Label lblUom;
        private System.Windows.Forms.ComboBox Type;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblDesignedBy;
        private System.Windows.Forms.TextBox DesignedBy;
        private System.Windows.Forms.Label lblAltQty;
        private System.Windows.Forms.TextBox AltQty;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox Notes;
        private System.Windows.Forms.TextBox Coating;
        private System.Windows.Forms.Label lblCoating;
        private System.Windows.Forms.TextBox Finish;
        private System.Windows.Forms.Label lblFinish;
        private System.Windows.Forms.TextBox Material;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblEcoChks;
        private System.Windows.Forms.TextBox EcoChks;
        private System.Windows.Forms.Label lblEcoDates;
        private System.Windows.Forms.TextBox EcoDates;
        private System.Windows.Forms.Label lblEcoDescriptions;
        private System.Windows.Forms.TextBox EcoDescriptions;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.TextBox Zone;
        private System.Windows.Forms.Label lblEcoRevs;
        private System.Windows.Forms.TextBox EcoRevs;
        private System.Windows.Forms.Label lblEcos;
        private System.Windows.Forms.TextBox Ecos;
        private System.Windows.Forms.Label lblRevision;
        private System.Windows.Forms.TextBox Revision;
        private System.Windows.Forms.TextBox DrawDate;
    }
}

