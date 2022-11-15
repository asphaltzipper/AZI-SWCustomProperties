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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnBomScan = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnGetImage = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblUserStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cboCurrentConfig = new System.Windows.Forms.ComboBox();
            this.lblCurrentConfig = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnApplyClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.RouteTemplate = new System.Windows.Forms.ComboBox();
            this.lblRouteTemplate = new System.Windows.Forms.Label();
            this.MaterialPn = new System.Windows.Forms.ComboBox();
            this.lblMaterialPn = new System.Windows.Forms.Label();
            this.DesignedDate = new System.Windows.Forms.TextBox();
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
            this.lblCoating = new System.Windows.Forms.Label();
            this.lblFinish = new System.Windows.Forms.Label();
            this.Material = new System.Windows.Forms.TextBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblAltQty = new System.Windows.Forms.Label();
            this.AltQty = new System.Windows.Forms.TextBox();
            this.Make = new System.Windows.Forms.ComboBox();
            this.lblMake = new System.Windows.Forms.Label();
            this.lblDrawn = new System.Windows.Forms.Label();
            this.Uom = new System.Windows.Forms.ComboBox();
            this.lblUom = new System.Windows.Forms.Label();
            this.Type = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblInitials = new System.Windows.Forms.Label();
            this.DesignedBy = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.TextBox();
            this.lblPartNum = new System.Windows.Forms.Label();
            this.PartNum = new System.Windows.Forms.TextBox();
            this.NonEcoMod = new System.Windows.Forms.CheckBox();
            this.HoldProduction = new System.Windows.Forms.CheckBox();
            this.HasEtching = new System.Windows.Forms.CheckBox();
            this.BendCount = new System.Windows.Forms.TextBox();
            this.CutOutCount = new System.Windows.Forms.TextBox();
            this.CuttingLengthInner = new System.Windows.Forms.TextBox();
            this.CuttingLengthOuter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblForEffectiveCode = new System.Windows.Forms.Label();
            this.SwProductCode = new System.Windows.Forms.TextBox();
            this.OdooProduct = new System.Windows.Forms.TextBox();
            this.lblOdooProduct = new System.Windows.Forms.Label();
            this.btnErase = new System.Windows.Forms.Button();
            this.DrawnDate = new System.Windows.Forms.TextBox();
            this.lblDesigned = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.DrawnBy = new System.Windows.Forms.TextBox();
            this.lblChildQty = new System.Windows.Forms.Label();
            this.ChildQty = new System.Windows.Forms.TextBox();
            this.Coating = new System.Windows.Forms.ComboBox();
            this.Finish = new System.Windows.Forms.ComboBox();
            this.btnOverwriteEcos = new System.Windows.Forms.Button();
            this.UpdateOdoo = new System.Windows.Forms.Button();
            this.dgEcos = new System.Windows.Forms.DataGridView();
            this.cmsGeneric = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiOdoo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiSw = new System.Windows.Forms.ToolStripMenuItem();
            this.MaterialPnChange = new System.Windows.Forms.Label();
            this.ChildQtyChange = new System.Windows.Forms.Label();
            this.RouteTemplateChange = new System.Windows.Forms.Label();
            this.UomChange = new System.Windows.Forms.Label();
            this.AltQtyValueChange = new System.Windows.Forms.Label();
            this.MakeChange = new System.Windows.Forms.Label();
            this.HasEtchingChange = new System.Windows.Forms.Label();
            this.NonEcoModChange = new System.Windows.Forms.Label();
            this.HoldProductionChange = new System.Windows.Forms.Label();
            this.CutOutCountChange = new System.Windows.Forms.Label();
            this.CuttingLengthInnerChange = new System.Windows.Forms.Label();
            this.CuttingLengthOuterChange = new System.Windows.Forms.Label();
            this.BendCountChange = new System.Windows.Forms.Label();
            this.DescriptionChange = new System.Windows.Forms.Label();
            this.NotesChange = new System.Windows.Forms.Label();
            this.MaterialChange = new System.Windows.Forms.Label();
            this.DesignedByChange = new System.Windows.Forms.Label();
            this.DrawnByChange = new System.Windows.Forms.Label();
            this.FinishChange = new System.Windows.Forms.Label();
            this.CoatingChange = new System.Windows.Forms.Label();
            this.TypeChange = new System.Windows.Forms.Label();
            this.EcosChange = new System.Windows.Forms.Label();
            this.EcoRevsChange = new System.Windows.Forms.Label();
            this.ZoneChange = new System.Windows.Forms.Label();
            this.EcoDescriptionsChange = new System.Windows.Forms.Label();
            this.EcoDatesChange = new System.Windows.Forms.Label();
            this.EcoChksChange = new System.Windows.Forms.Label();
            this.DesignedDateChange = new System.Windows.Forms.Label();
            this.DrawnDateChange = new System.Windows.Forms.Label();
            this.PartNumChange = new System.Windows.Forms.Label();
            this.RevisionChange = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.OdooImage = new System.Windows.Forms.PictureBox();
            this.btnSearchRm = new System.Windows.Forms.Button();
            this.btnCopyFrom = new System.Windows.Forms.Button();
            this.AltQtyValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Thickness = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEcos)).BeginInit();
            this.cmsGeneric.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OdooImage)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSettings,
            this.btnRefresh,
            this.btnBomScan,
            this.btnGetImage,
            this.lblUserStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 790);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(721, 24);
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
            this.btnBomScan.ToolTipText = "BOM Scan";
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
            this.btnGetImage.ToolTipText = "Get Image";
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
            // cboCurrentConfig
            // 
            this.cboCurrentConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCurrentConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrentConfig.FormattingEnabled = true;
            this.cboCurrentConfig.Location = new System.Drawing.Point(53, 6);
            this.cboCurrentConfig.Name = "cboCurrentConfig";
            this.cboCurrentConfig.Size = new System.Drawing.Size(656, 21);
            this.cboCurrentConfig.TabIndex = 1;
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
            this.btnApply.Location = new System.Drawing.Point(462, 764);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(80, 23);
            this.btnApply.TabIndex = 39;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // btnApplyClose
            // 
            this.btnApplyClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyClose.Location = new System.Drawing.Point(377, 764);
            this.btnApplyClose.Name = "btnApplyClose";
            this.btnApplyClose.Size = new System.Drawing.Size(80, 23);
            this.btnApplyClose.TabIndex = 38;
            this.btnApplyClose.TabStop = false;
            this.btnApplyClose.Text = "Apply/Close";
            this.btnApplyClose.UseVisualStyleBackColor = true;
            this.btnApplyClose.Visible = false;
            this.btnApplyClose.Click += new System.EventHandler(this.BtnApplyClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(629, 764);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // RouteTemplate
            // 
            this.RouteTemplate.BackColor = System.Drawing.SystemColors.Window;
            this.RouteTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RouteTemplate.FormattingEnabled = true;
            this.RouteTemplate.Location = new System.Drawing.Point(72, 266);
            this.RouteTemplate.Name = "RouteTemplate";
            this.RouteTemplate.Size = new System.Drawing.Size(186, 21);
            this.RouteTemplate.TabIndex = 17;
            // 
            // lblRouteTemplate
            // 
            this.lblRouteTemplate.AutoSize = true;
            this.lblRouteTemplate.Location = new System.Drawing.Point(22, 269);
            this.lblRouteTemplate.Name = "lblRouteTemplate";
            this.lblRouteTemplate.Size = new System.Drawing.Size(44, 13);
            this.lblRouteTemplate.TabIndex = 42;
            this.lblRouteTemplate.Text = "Routing";
            // 
            // MaterialPn
            // 
            this.MaterialPn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MaterialPn.FormattingEnabled = true;
            this.MaterialPn.Location = new System.Drawing.Point(72, 213);
            this.MaterialPn.Name = "MaterialPn";
            this.MaterialPn.Size = new System.Drawing.Size(376, 21);
            this.MaterialPn.TabIndex = 14;
            this.MaterialPn.SelectedIndexChanged += new System.EventHandler(this.MaterialPn_SelectedIndexChanged);
            // 
            // lblMaterialPn
            // 
            this.lblMaterialPn.AutoSize = true;
            this.lblMaterialPn.Location = new System.Drawing.Point(22, 216);
            this.lblMaterialPn.Name = "lblMaterialPn";
            this.lblMaterialPn.Size = new System.Drawing.Size(44, 13);
            this.lblMaterialPn.TabIndex = 40;
            this.lblMaterialPn.Text = "RawPN";
            // 
            // DesignedDate
            // 
            this.DesignedDate.Location = new System.Drawing.Point(608, 80);
            this.DesignedDate.Name = "DesignedDate";
            this.DesignedDate.Size = new System.Drawing.Size(94, 20);
            this.DesignedDate.TabIndex = 8;
            // 
            // lblEcoChks
            // 
            this.lblEcoChks.AutoSize = true;
            this.lblEcoChks.Location = new System.Drawing.Point(518, 354);
            this.lblEcoChks.Name = "lblEcoChks";
            this.lblEcoChks.Size = new System.Drawing.Size(26, 13);
            this.lblEcoChks.TabIndex = 38;
            this.lblEcoChks.Text = "Chk";
            // 
            // EcoChks
            // 
            this.EcoChks.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EcoChks.Location = new System.Drawing.Point(519, 370);
            this.EcoChks.Multiline = true;
            this.EcoChks.Name = "EcoChks";
            this.EcoChks.Size = new System.Drawing.Size(36, 180);
            this.EcoChks.TabIndex = 34;
            this.EcoChks.Text = "AAA";
            this.EcoChks.WordWrap = false;
            // 
            // lblEcoDates
            // 
            this.lblEcoDates.AutoSize = true;
            this.lblEcoDates.Location = new System.Drawing.Point(449, 354);
            this.lblEcoDates.Name = "lblEcoDates";
            this.lblEcoDates.Size = new System.Drawing.Size(30, 13);
            this.lblEcoDates.TabIndex = 36;
            this.lblEcoDates.Text = "Date";
            // 
            // EcoDates
            // 
            this.EcoDates.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EcoDates.Location = new System.Drawing.Point(450, 370);
            this.EcoDates.Multiline = true;
            this.EcoDates.Name = "EcoDates";
            this.EcoDates.Size = new System.Drawing.Size(70, 180);
            this.EcoDates.TabIndex = 33;
            this.EcoDates.Text = "2020-08-05";
            this.EcoDates.WordWrap = false;
            // 
            // lblEcoDescriptions
            // 
            this.lblEcoDescriptions.AutoSize = true;
            this.lblEcoDescriptions.Location = new System.Drawing.Point(112, 354);
            this.lblEcoDescriptions.Name = "lblEcoDescriptions";
            this.lblEcoDescriptions.Size = new System.Drawing.Size(60, 13);
            this.lblEcoDescriptions.TabIndex = 34;
            this.lblEcoDescriptions.Text = "Description";
            // 
            // EcoDescriptions
            // 
            this.EcoDescriptions.BackColor = System.Drawing.SystemColors.Window;
            this.EcoDescriptions.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EcoDescriptions.Location = new System.Drawing.Point(106, 370);
            this.EcoDescriptions.Multiline = true;
            this.EcoDescriptions.Name = "EcoDescriptions";
            this.EcoDescriptions.Size = new System.Drawing.Size(345, 180);
            this.EcoDescriptions.TabIndex = 32;
            this.EcoDescriptions.Text = "New Rev for X000206, X000207, new hatch lockout, added weld-on";
            this.EcoDescriptions.WordWrap = false;
            this.EcoDescriptions.TextChanged += new System.EventHandler(this.EcoDescriptions_TextChanged);
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.Location = new System.Drawing.Point(79, 354);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(32, 13);
            this.lblZone.TabIndex = 32;
            this.lblZone.Text = "Zone";
            // 
            // Zone
            // 
            this.Zone.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zone.Location = new System.Drawing.Point(78, 370);
            this.Zone.Multiline = true;
            this.Zone.Name = "Zone";
            this.Zone.Size = new System.Drawing.Size(29, 180);
            this.Zone.TabIndex = 31;
            this.Zone.Text = "Z-9";
            this.Zone.WordWrap = false;
            // 
            // lblEcoRevs
            // 
            this.lblEcoRevs.AutoSize = true;
            this.lblEcoRevs.Location = new System.Drawing.Point(53, 354);
            this.lblEcoRevs.Name = "lblEcoRevs";
            this.lblEcoRevs.Size = new System.Drawing.Size(27, 13);
            this.lblEcoRevs.TabIndex = 30;
            this.lblEcoRevs.Text = "Rev";
            // 
            // EcoRevs
            // 
            this.EcoRevs.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EcoRevs.Location = new System.Drawing.Point(54, 370);
            this.EcoRevs.Multiline = true;
            this.EcoRevs.Name = "EcoRevs";
            this.EcoRevs.Size = new System.Drawing.Size(25, 180);
            this.EcoRevs.TabIndex = 30;
            this.EcoRevs.Text = "Z9";
            this.EcoRevs.WordWrap = false;
            // 
            // lblEcos
            // 
            this.lblEcos.AutoSize = true;
            this.lblEcos.Location = new System.Drawing.Point(11, 354);
            this.lblEcos.Name = "lblEcos";
            this.lblEcos.Size = new System.Drawing.Size(29, 13);
            this.lblEcos.TabIndex = 28;
            this.lblEcos.Text = "ECO";
            // 
            // Ecos
            // 
            this.Ecos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ecos.Location = new System.Drawing.Point(13, 370);
            this.Ecos.Multiline = true;
            this.Ecos.Name = "Ecos";
            this.Ecos.Size = new System.Drawing.Size(42, 180);
            this.Ecos.TabIndex = 29;
            this.Ecos.Text = "23456";
            this.Ecos.WordWrap = false;
            // 
            // lblRevision
            // 
            this.lblRevision.AutoSize = true;
            this.lblRevision.Location = new System.Drawing.Point(378, 83);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(64, 13);
            this.lblRevision.TabIndex = 26;
            this.lblRevision.Text = "Current Rev";
            // 
            // Revision
            // 
            this.Revision.Location = new System.Drawing.Point(443, 80);
            this.Revision.Name = "Revision";
            this.Revision.Size = new System.Drawing.Size(39, 20);
            this.Revision.TabIndex = 3;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(22, 135);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 24;
            this.lblNotes.Text = "Notes";
            // 
            // Notes
            // 
            this.Notes.AcceptsReturn = true;
            this.Notes.Location = new System.Drawing.Point(71, 132);
            this.Notes.Multiline = true;
            this.Notes.Name = "Notes";
            this.Notes.Size = new System.Drawing.Size(411, 49);
            this.Notes.TabIndex = 5;
            // 
            // lblCoating
            // 
            this.lblCoating.AutoSize = true;
            this.lblCoating.Location = new System.Drawing.Point(518, 161);
            this.lblCoating.Name = "lblCoating";
            this.lblCoating.Size = new System.Drawing.Size(43, 13);
            this.lblCoating.TabIndex = 21;
            this.lblCoating.Text = "Coating";
            // 
            // lblFinish
            // 
            this.lblFinish.AutoSize = true;
            this.lblFinish.Location = new System.Drawing.Point(518, 135);
            this.lblFinish.Name = "lblFinish";
            this.lblFinish.Size = new System.Drawing.Size(34, 13);
            this.lblFinish.TabIndex = 19;
            this.lblFinish.Text = "Finish";
            // 
            // Material
            // 
            this.Material.Location = new System.Drawing.Point(71, 187);
            this.Material.Name = "Material";
            this.Material.Size = new System.Drawing.Size(411, 20);
            this.Material.TabIndex = 6;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(23, 190);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(44, 13);
            this.lblMaterial.TabIndex = 17;
            this.lblMaterial.Text = "Material";
            // 
            // lblAltQty
            // 
            this.lblAltQty.AutoSize = true;
            this.lblAltQty.Location = new System.Drawing.Point(23, 308);
            this.lblAltQty.Name = "lblAltQty";
            this.lblAltQty.Size = new System.Drawing.Size(38, 13);
            this.lblAltQty.TabIndex = 16;
            this.lblAltQty.Text = "Alt Qty";
            // 
            // AltQty
            // 
            this.AltQty.Location = new System.Drawing.Point(343, 305);
            this.AltQty.Name = "AltQty";
            this.AltQty.ReadOnly = true;
            this.AltQty.Size = new System.Drawing.Size(53, 20);
            this.AltQty.TabIndex = 19;
            this.AltQty.TabStop = false;
            // 
            // Make
            // 
            this.Make.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Make.FormattingEnabled = true;
            this.Make.Location = new System.Drawing.Point(343, 252);
            this.Make.Name = "Make";
            this.Make.Size = new System.Drawing.Size(53, 21);
            this.Make.TabIndex = 18;
            // 
            // lblMake
            // 
            this.lblMake.AutoSize = true;
            this.lblMake.Location = new System.Drawing.Point(302, 255);
            this.lblMake.Name = "lblMake";
            this.lblMake.Size = new System.Drawing.Size(34, 13);
            this.lblMake.TabIndex = 13;
            this.lblMake.Text = "Make";
            // 
            // lblDrawn
            // 
            this.lblDrawn.AutoSize = true;
            this.lblDrawn.Location = new System.Drawing.Point(518, 108);
            this.lblDrawn.Name = "lblDrawn";
            this.lblDrawn.Size = new System.Drawing.Size(38, 13);
            this.lblDrawn.TabIndex = 11;
            this.lblDrawn.Text = "Drawn";
            // 
            // Uom
            // 
            this.Uom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Uom.FormattingEnabled = true;
            this.Uom.Location = new System.Drawing.Point(343, 279);
            this.Uom.Name = "Uom";
            this.Uom.Size = new System.Drawing.Size(53, 21);
            this.Uom.TabIndex = 19;
            // 
            // lblUom
            // 
            this.lblUom.AutoSize = true;
            this.lblUom.Location = new System.Drawing.Point(302, 283);
            this.lblUom.Name = "lblUom";
            this.lblUom.Size = new System.Drawing.Size(32, 13);
            this.lblUom.TabIndex = 9;
            this.lblUom.Text = "UOM";
            // 
            // Type
            // 
            this.Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Type.FormattingEnabled = true;
            this.Type.Location = new System.Drawing.Point(570, 186);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(139, 21);
            this.Type.TabIndex = 13;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(518, 187);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "Type";
            // 
            // lblInitials
            // 
            this.lblInitials.AutoSize = true;
            this.lblInitials.Location = new System.Drawing.Point(571, 64);
            this.lblInitials.Name = "lblInitials";
            this.lblInitials.Size = new System.Drawing.Size(36, 13);
            this.lblInitials.TabIndex = 5;
            this.lblInitials.Text = "Initials";
            // 
            // DesignedBy
            // 
            this.DesignedBy.Location = new System.Drawing.Point(571, 80);
            this.DesignedBy.Name = "DesignedBy";
            this.DesignedBy.Size = new System.Drawing.Size(39, 20);
            this.DesignedBy.TabIndex = 7;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(22, 109);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(32, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Desc";
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(71, 106);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(411, 20);
            this.Description.TabIndex = 4;
            // 
            // lblPartNum
            // 
            this.lblPartNum.AutoSize = true;
            this.lblPartNum.Location = new System.Drawing.Point(22, 83);
            this.lblPartNum.Name = "lblPartNum";
            this.lblPartNum.Size = new System.Drawing.Size(43, 13);
            this.lblPartNum.TabIndex = 1;
            this.lblPartNum.Text = "Part No";
            // 
            // PartNum
            // 
            this.PartNum.Location = new System.Drawing.Point(71, 80);
            this.PartNum.Name = "PartNum";
            this.PartNum.Size = new System.Drawing.Size(283, 20);
            this.PartNum.TabIndex = 2;
            // 
            // NonEcoMod
            // 
            this.NonEcoMod.AutoSize = true;
            this.NonEcoMod.Location = new System.Drawing.Point(441, 282);
            this.NonEcoMod.Name = "NonEcoMod";
            this.NonEcoMod.Size = new System.Drawing.Size(108, 17);
            this.NonEcoMod.TabIndex = 23;
            this.NonEcoMod.Text = "Non-Eco Change";
            this.NonEcoMod.UseVisualStyleBackColor = true;
            // 
            // HoldProduction
            // 
            this.HoldProduction.AutoSize = true;
            this.HoldProduction.Location = new System.Drawing.Point(441, 256);
            this.HoldProduction.Name = "HoldProduction";
            this.HoldProduction.Size = new System.Drawing.Size(102, 17);
            this.HoldProduction.TabIndex = 22;
            this.HoldProduction.Text = "Hold Production";
            this.HoldProduction.UseVisualStyleBackColor = true;
            // 
            // HasEtching
            // 
            this.HasEtching.AutoSize = true;
            this.HasEtching.Location = new System.Drawing.Point(441, 308);
            this.HasEtching.Name = "HasEtching";
            this.HasEtching.Size = new System.Drawing.Size(48, 17);
            this.HasEtching.TabIndex = 24;
            this.HasEtching.Text = "Etch";
            this.HasEtching.UseVisualStyleBackColor = true;
            // 
            // BendCount
            // 
            this.BendCount.Location = new System.Drawing.Point(659, 310);
            this.BendCount.Name = "BendCount";
            this.BendCount.Size = new System.Drawing.Size(50, 20);
            this.BendCount.TabIndex = 28;
            // 
            // CutOutCount
            // 
            this.CutOutCount.Location = new System.Drawing.Point(659, 284);
            this.CutOutCount.Name = "CutOutCount";
            this.CutOutCount.Size = new System.Drawing.Size(50, 20);
            this.CutOutCount.TabIndex = 27;
            // 
            // CuttingLengthInner
            // 
            this.CuttingLengthInner.Location = new System.Drawing.Point(659, 258);
            this.CuttingLengthInner.Name = "CuttingLengthInner";
            this.CuttingLengthInner.Size = new System.Drawing.Size(50, 20);
            this.CuttingLengthInner.TabIndex = 26;
            // 
            // CuttingLengthOuter
            // 
            this.CuttingLengthOuter.Location = new System.Drawing.Point(659, 232);
            this.CuttingLengthOuter.Name = "CuttingLengthOuter";
            this.CuttingLengthOuter.Size = new System.Drawing.Size(50, 20);
            this.CuttingLengthOuter.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(576, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bends";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(576, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cut-Outs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(576, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "In Cut Length";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(576, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Out Cut Length";
            // 
            // lblForEffectiveCode
            // 
            this.lblForEffectiveCode.AutoSize = true;
            this.lblForEffectiveCode.Location = new System.Drawing.Point(12, 36);
            this.lblForEffectiveCode.Name = "lblForEffectiveCode";
            this.lblForEffectiveCode.Size = new System.Drawing.Size(27, 13);
            this.lblForEffectiveCode.TabIndex = 9;
            this.lblForEffectiveCode.Text = "P/N";
            // 
            // SwProductCode
            // 
            this.SwProductCode.Location = new System.Drawing.Point(53, 33);
            this.SwProductCode.Name = "SwProductCode";
            this.SwProductCode.ReadOnly = true;
            this.SwProductCode.Size = new System.Drawing.Size(124, 20);
            this.SwProductCode.TabIndex = 10;
            this.SwProductCode.TabStop = false;
            // 
            // OdooProduct
            // 
            this.OdooProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OdooProduct.Location = new System.Drawing.Point(281, 34);
            this.OdooProduct.Name = "OdooProduct";
            this.OdooProduct.ReadOnly = true;
            this.OdooProduct.Size = new System.Drawing.Size(428, 20);
            this.OdooProduct.TabIndex = 12;
            this.OdooProduct.TabStop = false;
            // 
            // lblOdooProduct
            // 
            this.lblOdooProduct.AutoSize = true;
            this.lblOdooProduct.Location = new System.Drawing.Point(203, 36);
            this.lblOdooProduct.Name = "lblOdooProduct";
            this.lblOdooProduct.Size = new System.Drawing.Size(73, 13);
            this.lblOdooProduct.TabIndex = 11;
            this.lblOdooProduct.Text = "Odoo Product";
            // 
            // btnErase
            // 
            this.btnErase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnErase.Location = new System.Drawing.Point(12, 764);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(75, 23);
            this.btnErase.TabIndex = 36;
            this.btnErase.TabStop = false;
            this.btnErase.Text = "Erase";
            this.btnErase.UseVisualStyleBackColor = true;
            this.btnErase.Click += new System.EventHandler(this.BtnErase_Click);
            // 
            // DrawnDate
            // 
            this.DrawnDate.Location = new System.Drawing.Point(608, 105);
            this.DrawnDate.Name = "DrawnDate";
            this.DrawnDate.Size = new System.Drawing.Size(94, 20);
            this.DrawnDate.TabIndex = 10;
            // 
            // lblDesigned
            // 
            this.lblDesigned.AutoSize = true;
            this.lblDesigned.Location = new System.Drawing.Point(518, 83);
            this.lblDesigned.Name = "lblDesigned";
            this.lblDesigned.Size = new System.Drawing.Size(52, 13);
            this.lblDesigned.TabIndex = 44;
            this.lblDesigned.Text = "Designed";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(634, 64);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 45;
            this.lblDate.Text = "Date";
            // 
            // DrawnBy
            // 
            this.DrawnBy.Location = new System.Drawing.Point(571, 105);
            this.DrawnBy.Name = "DrawnBy";
            this.DrawnBy.Size = new System.Drawing.Size(39, 20);
            this.DrawnBy.TabIndex = 9;
            // 
            // lblChildQty
            // 
            this.lblChildQty.AutoSize = true;
            this.lblChildQty.Location = new System.Drawing.Point(22, 243);
            this.lblChildQty.Name = "lblChildQty";
            this.lblChildQty.Size = new System.Drawing.Size(49, 13);
            this.lblChildQty.TabIndex = 48;
            this.lblChildQty.Text = "Child Qty";
            // 
            // ChildQty
            // 
            this.ChildQty.Location = new System.Drawing.Point(72, 240);
            this.ChildQty.Name = "ChildQty";
            this.ChildQty.Size = new System.Drawing.Size(39, 20);
            this.ChildQty.TabIndex = 16;
            // 
            // Coating
            // 
            this.Coating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Coating.FormattingEnabled = true;
            this.Coating.Location = new System.Drawing.Point(571, 159);
            this.Coating.Name = "Coating";
            this.Coating.Size = new System.Drawing.Size(138, 21);
            this.Coating.TabIndex = 12;
            // 
            // Finish
            // 
            this.Finish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Finish.FormattingEnabled = true;
            this.Finish.Location = new System.Drawing.Point(571, 132);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(138, 21);
            this.Finish.TabIndex = 11;
            // 
            // btnOverwriteEcos
            // 
            this.btnOverwriteEcos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOverwriteEcos.Location = new System.Drawing.Point(562, 527);
            this.btnOverwriteEcos.Name = "btnOverwriteEcos";
            this.btnOverwriteEcos.Size = new System.Drawing.Size(147, 23);
            this.btnOverwriteEcos.TabIndex = 35;
            this.btnOverwriteEcos.Text = "Write ECOs to Cust Props";
            this.btnOverwriteEcos.UseVisualStyleBackColor = true;
            this.btnOverwriteEcos.Click += new System.EventHandler(this.btnOverwriteEcos_Click);
            // 
            // UpdateOdoo
            // 
            this.UpdateOdoo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateOdoo.Location = new System.Drawing.Point(546, 764);
            this.UpdateOdoo.Name = "UpdateOdoo";
            this.UpdateOdoo.Size = new System.Drawing.Size(79, 23);
            this.UpdateOdoo.TabIndex = 37;
            this.UpdateOdoo.Text = "Update Odoo";
            this.UpdateOdoo.UseVisualStyleBackColor = true;
            this.UpdateOdoo.Click += new System.EventHandler(this.UpdateOdoo_Click);
            // 
            // dgEcos
            // 
            this.dgEcos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgEcos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgEcos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgEcos.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgEcos.Location = new System.Drawing.Point(12, 556);
            this.dgEcos.Name = "dgEcos";
            this.dgEcos.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgEcos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgEcos.Size = new System.Drawing.Size(697, 202);
            this.dgEcos.TabIndex = 65;
            // 
            // cmsGeneric
            // 
            this.cmsGeneric.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiOdoo,
            this.cmiSw});
            this.cmsGeneric.Name = "cmsGeneric";
            this.cmsGeneric.ShowImageMargin = false;
            this.cmsGeneric.Size = new System.Drawing.Size(86, 48);
            // 
            // cmiOdoo
            // 
            this.cmiOdoo.Name = "cmiOdoo";
            this.cmiOdoo.Size = new System.Drawing.Size(85, 22);
            this.cmiOdoo.Text = "Odoo: ";
            // 
            // cmiSw
            // 
            this.cmiSw.Name = "cmiSw";
            this.cmiSw.Size = new System.Drawing.Size(85, 22);
            this.cmiSw.Text = "SW: ";
            // 
            // MaterialPnChange
            // 
            this.MaterialPnChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaterialPnChange.ForeColor = System.Drawing.Color.Red;
            this.MaterialPnChange.Location = new System.Drawing.Point(3, 216);
            this.MaterialPnChange.Margin = new System.Windows.Forms.Padding(0);
            this.MaterialPnChange.Name = "MaterialPnChange";
            this.MaterialPnChange.Size = new System.Drawing.Size(22, 14);
            this.MaterialPnChange.TabIndex = 70;
            this.MaterialPnChange.Text = "OS";
            this.MaterialPnChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChildQtyChange
            // 
            this.ChildQtyChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChildQtyChange.ForeColor = System.Drawing.Color.Red;
            this.ChildQtyChange.Location = new System.Drawing.Point(2, 243);
            this.ChildQtyChange.Margin = new System.Windows.Forms.Padding(0);
            this.ChildQtyChange.Name = "ChildQtyChange";
            this.ChildQtyChange.Size = new System.Drawing.Size(22, 14);
            this.ChildQtyChange.TabIndex = 71;
            this.ChildQtyChange.Text = "OS";
            this.ChildQtyChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RouteTemplateChange
            // 
            this.RouteTemplateChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RouteTemplateChange.ForeColor = System.Drawing.Color.Red;
            this.RouteTemplateChange.Location = new System.Drawing.Point(2, 269);
            this.RouteTemplateChange.Margin = new System.Windows.Forms.Padding(0);
            this.RouteTemplateChange.Name = "RouteTemplateChange";
            this.RouteTemplateChange.Size = new System.Drawing.Size(22, 14);
            this.RouteTemplateChange.TabIndex = 72;
            this.RouteTemplateChange.Text = "OS";
            this.RouteTemplateChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UomChange
            // 
            this.UomChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UomChange.ForeColor = System.Drawing.Color.Red;
            this.UomChange.Location = new System.Drawing.Point(281, 283);
            this.UomChange.Margin = new System.Windows.Forms.Padding(0);
            this.UomChange.Name = "UomChange";
            this.UomChange.Size = new System.Drawing.Size(22, 14);
            this.UomChange.TabIndex = 73;
            this.UomChange.Text = "OS";
            this.UomChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AltQtyValueChange
            // 
            this.AltQtyValueChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AltQtyValueChange.ForeColor = System.Drawing.Color.Red;
            this.AltQtyValueChange.Location = new System.Drawing.Point(2, 308);
            this.AltQtyValueChange.Margin = new System.Windows.Forms.Padding(0);
            this.AltQtyValueChange.Name = "AltQtyValueChange";
            this.AltQtyValueChange.Size = new System.Drawing.Size(22, 14);
            this.AltQtyValueChange.TabIndex = 74;
            this.AltQtyValueChange.Text = "OS";
            this.AltQtyValueChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MakeChange
            // 
            this.MakeChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MakeChange.ForeColor = System.Drawing.Color.Red;
            this.MakeChange.Location = new System.Drawing.Point(281, 255);
            this.MakeChange.Margin = new System.Windows.Forms.Padding(0);
            this.MakeChange.Name = "MakeChange";
            this.MakeChange.Size = new System.Drawing.Size(22, 14);
            this.MakeChange.TabIndex = 75;
            this.MakeChange.Text = "OS";
            this.MakeChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HasEtchingChange
            // 
            this.HasEtchingChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HasEtchingChange.ForeColor = System.Drawing.Color.Red;
            this.HasEtchingChange.Location = new System.Drawing.Point(417, 308);
            this.HasEtchingChange.Margin = new System.Windows.Forms.Padding(0);
            this.HasEtchingChange.Name = "HasEtchingChange";
            this.HasEtchingChange.Size = new System.Drawing.Size(22, 14);
            this.HasEtchingChange.TabIndex = 78;
            this.HasEtchingChange.Text = "OS";
            this.HasEtchingChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NonEcoModChange
            // 
            this.NonEcoModChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NonEcoModChange.ForeColor = System.Drawing.Color.Red;
            this.NonEcoModChange.Location = new System.Drawing.Point(417, 282);
            this.NonEcoModChange.Margin = new System.Windows.Forms.Padding(0);
            this.NonEcoModChange.Name = "NonEcoModChange";
            this.NonEcoModChange.Size = new System.Drawing.Size(22, 14);
            this.NonEcoModChange.TabIndex = 77;
            this.NonEcoModChange.Text = "OS";
            this.NonEcoModChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HoldProductionChange
            // 
            this.HoldProductionChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoldProductionChange.ForeColor = System.Drawing.Color.Red;
            this.HoldProductionChange.Location = new System.Drawing.Point(417, 256);
            this.HoldProductionChange.Margin = new System.Windows.Forms.Padding(0);
            this.HoldProductionChange.Name = "HoldProductionChange";
            this.HoldProductionChange.Size = new System.Drawing.Size(22, 14);
            this.HoldProductionChange.TabIndex = 76;
            this.HoldProductionChange.Text = "OS";
            this.HoldProductionChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CutOutCountChange
            // 
            this.CutOutCountChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CutOutCountChange.ForeColor = System.Drawing.Color.Red;
            this.CutOutCountChange.Location = new System.Drawing.Point(554, 286);
            this.CutOutCountChange.Margin = new System.Windows.Forms.Padding(0);
            this.CutOutCountChange.Name = "CutOutCountChange";
            this.CutOutCountChange.Size = new System.Drawing.Size(22, 14);
            this.CutOutCountChange.TabIndex = 81;
            this.CutOutCountChange.Text = "OS";
            this.CutOutCountChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CuttingLengthInnerChange
            // 
            this.CuttingLengthInnerChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CuttingLengthInnerChange.ForeColor = System.Drawing.Color.Red;
            this.CuttingLengthInnerChange.Location = new System.Drawing.Point(554, 261);
            this.CuttingLengthInnerChange.Margin = new System.Windows.Forms.Padding(0);
            this.CuttingLengthInnerChange.Name = "CuttingLengthInnerChange";
            this.CuttingLengthInnerChange.Size = new System.Drawing.Size(22, 14);
            this.CuttingLengthInnerChange.TabIndex = 80;
            this.CuttingLengthInnerChange.Text = "OS";
            this.CuttingLengthInnerChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CuttingLengthOuterChange
            // 
            this.CuttingLengthOuterChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CuttingLengthOuterChange.ForeColor = System.Drawing.Color.Red;
            this.CuttingLengthOuterChange.Location = new System.Drawing.Point(554, 235);
            this.CuttingLengthOuterChange.Margin = new System.Windows.Forms.Padding(0);
            this.CuttingLengthOuterChange.Name = "CuttingLengthOuterChange";
            this.CuttingLengthOuterChange.Size = new System.Drawing.Size(22, 14);
            this.CuttingLengthOuterChange.TabIndex = 79;
            this.CuttingLengthOuterChange.Text = "OS";
            this.CuttingLengthOuterChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BendCountChange
            // 
            this.BendCountChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BendCountChange.ForeColor = System.Drawing.Color.Red;
            this.BendCountChange.Location = new System.Drawing.Point(554, 310);
            this.BendCountChange.Margin = new System.Windows.Forms.Padding(0);
            this.BendCountChange.Name = "BendCountChange";
            this.BendCountChange.Size = new System.Drawing.Size(22, 14);
            this.BendCountChange.TabIndex = 82;
            this.BendCountChange.Text = "OS";
            this.BendCountChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DescriptionChange
            // 
            this.DescriptionChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionChange.ForeColor = System.Drawing.Color.Red;
            this.DescriptionChange.Location = new System.Drawing.Point(4, 109);
            this.DescriptionChange.Margin = new System.Windows.Forms.Padding(0);
            this.DescriptionChange.Name = "DescriptionChange";
            this.DescriptionChange.Size = new System.Drawing.Size(22, 14);
            this.DescriptionChange.TabIndex = 84;
            this.DescriptionChange.Text = "OS";
            this.DescriptionChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NotesChange
            // 
            this.NotesChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotesChange.ForeColor = System.Drawing.Color.Red;
            this.NotesChange.Location = new System.Drawing.Point(4, 135);
            this.NotesChange.Margin = new System.Windows.Forms.Padding(0);
            this.NotesChange.Name = "NotesChange";
            this.NotesChange.Size = new System.Drawing.Size(22, 14);
            this.NotesChange.TabIndex = 85;
            this.NotesChange.Text = "OS";
            this.NotesChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MaterialChange
            // 
            this.MaterialChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaterialChange.ForeColor = System.Drawing.Color.Red;
            this.MaterialChange.Location = new System.Drawing.Point(4, 190);
            this.MaterialChange.Margin = new System.Windows.Forms.Padding(0);
            this.MaterialChange.Name = "MaterialChange";
            this.MaterialChange.Size = new System.Drawing.Size(22, 14);
            this.MaterialChange.TabIndex = 86;
            this.MaterialChange.Text = "OS";
            this.MaterialChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DesignedByChange
            // 
            this.DesignedByChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesignedByChange.ForeColor = System.Drawing.Color.Red;
            this.DesignedByChange.Location = new System.Drawing.Point(499, 83);
            this.DesignedByChange.Margin = new System.Windows.Forms.Padding(0);
            this.DesignedByChange.Name = "DesignedByChange";
            this.DesignedByChange.Size = new System.Drawing.Size(22, 14);
            this.DesignedByChange.TabIndex = 88;
            this.DesignedByChange.Text = "OS";
            this.DesignedByChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DrawnByChange
            // 
            this.DrawnByChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawnByChange.ForeColor = System.Drawing.Color.Red;
            this.DrawnByChange.Location = new System.Drawing.Point(499, 108);
            this.DrawnByChange.Margin = new System.Windows.Forms.Padding(0);
            this.DrawnByChange.Name = "DrawnByChange";
            this.DrawnByChange.Size = new System.Drawing.Size(22, 14);
            this.DrawnByChange.TabIndex = 89;
            this.DrawnByChange.Text = "OS";
            this.DrawnByChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FinishChange
            // 
            this.FinishChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinishChange.ForeColor = System.Drawing.Color.Red;
            this.FinishChange.Location = new System.Drawing.Point(499, 135);
            this.FinishChange.Margin = new System.Windows.Forms.Padding(0);
            this.FinishChange.Name = "FinishChange";
            this.FinishChange.Size = new System.Drawing.Size(22, 14);
            this.FinishChange.TabIndex = 90;
            this.FinishChange.Text = "OS";
            this.FinishChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CoatingChange
            // 
            this.CoatingChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoatingChange.ForeColor = System.Drawing.Color.Red;
            this.CoatingChange.Location = new System.Drawing.Point(499, 161);
            this.CoatingChange.Margin = new System.Windows.Forms.Padding(0);
            this.CoatingChange.Name = "CoatingChange";
            this.CoatingChange.Size = new System.Drawing.Size(22, 14);
            this.CoatingChange.TabIndex = 91;
            this.CoatingChange.Text = "OS";
            this.CoatingChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TypeChange
            // 
            this.TypeChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeChange.ForeColor = System.Drawing.Color.Red;
            this.TypeChange.Location = new System.Drawing.Point(499, 187);
            this.TypeChange.Margin = new System.Windows.Forms.Padding(0);
            this.TypeChange.Name = "TypeChange";
            this.TypeChange.Size = new System.Drawing.Size(22, 14);
            this.TypeChange.TabIndex = 92;
            this.TypeChange.Text = "OS";
            this.TypeChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EcosChange
            // 
            this.EcosChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EcosChange.ForeColor = System.Drawing.Color.Red;
            this.EcosChange.Location = new System.Drawing.Point(12, 341);
            this.EcosChange.Margin = new System.Windows.Forms.Padding(0);
            this.EcosChange.Name = "EcosChange";
            this.EcosChange.Size = new System.Drawing.Size(22, 14);
            this.EcosChange.TabIndex = 93;
            this.EcosChange.Text = "OS";
            this.EcosChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EcoRevsChange
            // 
            this.EcoRevsChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EcoRevsChange.ForeColor = System.Drawing.Color.Red;
            this.EcoRevsChange.Location = new System.Drawing.Point(54, 341);
            this.EcoRevsChange.Margin = new System.Windows.Forms.Padding(0);
            this.EcoRevsChange.Name = "EcoRevsChange";
            this.EcoRevsChange.Size = new System.Drawing.Size(22, 14);
            this.EcoRevsChange.TabIndex = 94;
            this.EcoRevsChange.Text = "OS";
            this.EcoRevsChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ZoneChange
            // 
            this.ZoneChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoneChange.ForeColor = System.Drawing.Color.Red;
            this.ZoneChange.Location = new System.Drawing.Point(79, 341);
            this.ZoneChange.Margin = new System.Windows.Forms.Padding(0);
            this.ZoneChange.Name = "ZoneChange";
            this.ZoneChange.Size = new System.Drawing.Size(22, 14);
            this.ZoneChange.TabIndex = 95;
            this.ZoneChange.Text = "OS";
            this.ZoneChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EcoDescriptionsChange
            // 
            this.EcoDescriptionsChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EcoDescriptionsChange.ForeColor = System.Drawing.Color.Red;
            this.EcoDescriptionsChange.Location = new System.Drawing.Point(112, 341);
            this.EcoDescriptionsChange.Margin = new System.Windows.Forms.Padding(0);
            this.EcoDescriptionsChange.Name = "EcoDescriptionsChange";
            this.EcoDescriptionsChange.Size = new System.Drawing.Size(22, 14);
            this.EcoDescriptionsChange.TabIndex = 96;
            this.EcoDescriptionsChange.Text = "OS";
            this.EcoDescriptionsChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EcoDatesChange
            // 
            this.EcoDatesChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EcoDatesChange.ForeColor = System.Drawing.Color.Red;
            this.EcoDatesChange.Location = new System.Drawing.Point(449, 340);
            this.EcoDatesChange.Margin = new System.Windows.Forms.Padding(0);
            this.EcoDatesChange.Name = "EcoDatesChange";
            this.EcoDatesChange.Size = new System.Drawing.Size(22, 14);
            this.EcoDatesChange.TabIndex = 97;
            this.EcoDatesChange.Text = "OS";
            this.EcoDatesChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EcoChksChange
            // 
            this.EcoChksChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EcoChksChange.ForeColor = System.Drawing.Color.Red;
            this.EcoChksChange.Location = new System.Drawing.Point(518, 340);
            this.EcoChksChange.Margin = new System.Windows.Forms.Padding(0);
            this.EcoChksChange.Name = "EcoChksChange";
            this.EcoChksChange.Size = new System.Drawing.Size(22, 14);
            this.EcoChksChange.TabIndex = 98;
            this.EcoChksChange.Text = "OS";
            this.EcoChksChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DesignedDateChange
            // 
            this.DesignedDateChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesignedDateChange.ForeColor = System.Drawing.Color.Red;
            this.DesignedDateChange.Location = new System.Drawing.Point(700, 82);
            this.DesignedDateChange.Margin = new System.Windows.Forms.Padding(0);
            this.DesignedDateChange.Name = "DesignedDateChange";
            this.DesignedDateChange.Size = new System.Drawing.Size(22, 14);
            this.DesignedDateChange.TabIndex = 99;
            this.DesignedDateChange.Text = "OS";
            this.DesignedDateChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DrawnDateChange
            // 
            this.DrawnDateChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawnDateChange.ForeColor = System.Drawing.Color.Red;
            this.DrawnDateChange.Location = new System.Drawing.Point(700, 107);
            this.DrawnDateChange.Margin = new System.Windows.Forms.Padding(0);
            this.DrawnDateChange.Name = "DrawnDateChange";
            this.DrawnDateChange.Size = new System.Drawing.Size(22, 14);
            this.DrawnDateChange.TabIndex = 100;
            this.DrawnDateChange.Text = "OS";
            this.DrawnDateChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PartNumChange
            // 
            this.PartNumChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartNumChange.ForeColor = System.Drawing.Color.Red;
            this.PartNumChange.Location = new System.Drawing.Point(4, 83);
            this.PartNumChange.Margin = new System.Windows.Forms.Padding(0);
            this.PartNumChange.Name = "PartNumChange";
            this.PartNumChange.Size = new System.Drawing.Size(22, 14);
            this.PartNumChange.TabIndex = 83;
            this.PartNumChange.Text = "OS";
            this.PartNumChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RevisionChange
            // 
            this.RevisionChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RevisionChange.ForeColor = System.Drawing.Color.Red;
            this.RevisionChange.Location = new System.Drawing.Point(359, 83);
            this.RevisionChange.Margin = new System.Windows.Forms.Padding(0);
            this.RevisionChange.Name = "RevisionChange";
            this.RevisionChange.Size = new System.Drawing.Size(22, 14);
            this.RevisionChange.TabIndex = 87;
            this.RevisionChange.Text = "OS";
            this.RevisionChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 50;
            this.toolTip1.AutoPopDelay = 5000000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 10;
            // 
            // OdooImage
            // 
            this.OdooImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OdooImage.Image = ((System.Drawing.Image)(resources.GetObject("OdooImage.Image")));
            this.OdooImage.Location = new System.Drawing.Point(561, 370);
            this.OdooImage.Name = "OdooImage";
            this.OdooImage.Size = new System.Drawing.Size(148, 148);
            this.OdooImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OdooImage.TabIndex = 68;
            this.OdooImage.TabStop = false;
            this.OdooImage.Click += new System.EventHandler(this.BtnGetImage_Click);
            // 
            // btnSearchRm
            // 
            this.btnSearchRm.Image = global::AZI_SWCustomProperties.Properties.Resources.Search_16x;
            this.btnSearchRm.Location = new System.Drawing.Point(454, 213);
            this.btnSearchRm.Name = "btnSearchRm";
            this.btnSearchRm.Size = new System.Drawing.Size(26, 21);
            this.btnSearchRm.TabIndex = 15;
            this.btnSearchRm.UseVisualStyleBackColor = true;
            this.btnSearchRm.Click += new System.EventHandler(this.BtnSearchRm_Click);
            // 
            // btnCopyFrom
            // 
            this.btnCopyFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyFrom.Location = new System.Drawing.Point(93, 764);
            this.btnCopyFrom.Name = "btnCopyFrom";
            this.btnCopyFrom.Size = new System.Drawing.Size(75, 23);
            this.btnCopyFrom.TabIndex = 101;
            this.btnCopyFrom.TabStop = false;
            this.btnCopyFrom.Text = "Copy From";
            this.btnCopyFrom.UseVisualStyleBackColor = true;
            this.btnCopyFrom.Click += new System.EventHandler(this.BtnCopyFrom_Click);
            // 
            // AltQtyValue
            // 
            this.AltQtyValue.Location = new System.Drawing.Point(65, 305);
            this.AltQtyValue.Name = "AltQtyValue";
            this.AltQtyValue.Size = new System.Drawing.Size(259, 20);
            this.AltQtyValue.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 103;
            this.label5.Text = "=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(182, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 105;
            this.label6.Text = "T =";
            // 
            // Thickness
            // 
            this.Thickness.Location = new System.Drawing.Point(205, 240);
            this.Thickness.Name = "Thickness";
            this.Thickness.ReadOnly = true;
            this.Thickness.Size = new System.Drawing.Size(53, 20);
            this.Thickness.TabIndex = 104;
            this.Thickness.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(721, 814);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Thickness);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AltQtyValue);
            this.Controls.Add(this.btnCopyFrom);
            this.Controls.Add(this.DrawnDateChange);
            this.Controls.Add(this.DesignedDateChange);
            this.Controls.Add(this.EcoChksChange);
            this.Controls.Add(this.EcoDatesChange);
            this.Controls.Add(this.EcoDescriptionsChange);
            this.Controls.Add(this.ZoneChange);
            this.Controls.Add(this.EcoRevsChange);
            this.Controls.Add(this.EcosChange);
            this.Controls.Add(this.TypeChange);
            this.Controls.Add(this.CoatingChange);
            this.Controls.Add(this.FinishChange);
            this.Controls.Add(this.DrawnByChange);
            this.Controls.Add(this.DesignedByChange);
            this.Controls.Add(this.RevisionChange);
            this.Controls.Add(this.MaterialChange);
            this.Controls.Add(this.NotesChange);
            this.Controls.Add(this.DescriptionChange);
            this.Controls.Add(this.PartNumChange);
            this.Controls.Add(this.BendCountChange);
            this.Controls.Add(this.CutOutCountChange);
            this.Controls.Add(this.CuttingLengthInnerChange);
            this.Controls.Add(this.CuttingLengthOuterChange);
            this.Controls.Add(this.HasEtchingChange);
            this.Controls.Add(this.NonEcoModChange);
            this.Controls.Add(this.HoldProductionChange);
            this.Controls.Add(this.MakeChange);
            this.Controls.Add(this.AltQtyValueChange);
            this.Controls.Add(this.UomChange);
            this.Controls.Add(this.RouteTemplateChange);
            this.Controls.Add(this.ChildQtyChange);
            this.Controls.Add(this.MaterialPnChange);
            this.Controls.Add(this.OdooImage);
            this.Controls.Add(this.Coating);
            this.Controls.Add(this.UpdateOdoo);
            this.Controls.Add(this.btnOverwriteEcos);
            this.Controls.Add(this.btnSearchRm);
            this.Controls.Add(this.HasEtching);
            this.Controls.Add(this.HoldProduction);
            this.Controls.Add(this.NonEcoMod);
            this.Controls.Add(this.Finish);
            this.Controls.Add(this.dgEcos);
            this.Controls.Add(this.CuttingLengthOuter);
            this.Controls.Add(this.btnErase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMaterialPn);
            this.Controls.Add(this.SwProductCode);
            this.Controls.Add(this.BendCount);
            this.Controls.Add(this.DrawnBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblForEffectiveCode);
            this.Controls.Add(this.lblChildQty);
            this.Controls.Add(this.CutOutCount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEcoChks);
            this.Controls.Add(this.CuttingLengthInner);
            this.Controls.Add(this.btnApplyClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.Uom);
            this.Controls.Add(this.lblCurrentConfig);
            this.Controls.Add(this.EcoChks);
            this.Controls.Add(this.OdooProduct);
            this.Controls.Add(this.DrawnDate);
            this.Controls.Add(this.lblOdooProduct);
            this.Controls.Add(this.lblEcoDates);
            this.Controls.Add(this.cboCurrentConfig);
            this.Controls.Add(this.ChildQty);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblDesigned);
            this.Controls.Add(this.PartNum);
            this.Controls.Add(this.EcoDates);
            this.Controls.Add(this.lblDrawn);
            this.Controls.Add(this.lblUom);
            this.Controls.Add(this.lblInitials);
            this.Controls.Add(this.RouteTemplate);
            this.Controls.Add(this.DesignedBy);
            this.Controls.Add(this.lblEcoDescriptions);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.Type);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.lblRouteTemplate);
            this.Controls.Add(this.lblPartNum);
            this.Controls.Add(this.EcoDescriptions);
            this.Controls.Add(this.lblCoating);
            this.Controls.Add(this.DesignedDate);
            this.Controls.Add(this.lblFinish);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.Notes);
            this.Controls.Add(this.lblZone);
            this.Controls.Add(this.lblMake);
            this.Controls.Add(this.AltQty);
            this.Controls.Add(this.Make);
            this.Controls.Add(this.lblRevision);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.Zone);
            this.Controls.Add(this.Ecos);
            this.Controls.Add(this.lblAltQty);
            this.Controls.Add(this.MaterialPn);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.lblEcos);
            this.Controls.Add(this.lblEcoRevs);
            this.Controls.Add(this.Material);
            this.Controls.Add(this.Revision);
            this.Controls.Add(this.EcoRevs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "SW Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEcos)).EndInit();
            this.cmsGeneric.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OdooImage)).EndInit();
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
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnApplyClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblForEffectiveCode;
        private System.Windows.Forms.TextBox SwProductCode;
        private System.Windows.Forms.Label lblPartNum;
        private System.Windows.Forms.TextBox PartNum;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.ComboBox Make;
        private System.Windows.Forms.Label lblMake;
        private System.Windows.Forms.Label lblDrawn;
        private System.Windows.Forms.ComboBox Uom;
        private System.Windows.Forms.Label lblUom;
        private System.Windows.Forms.ComboBox Type;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblInitials;
        private System.Windows.Forms.TextBox DesignedBy;
        private System.Windows.Forms.Label lblAltQty;
        private System.Windows.Forms.TextBox AltQty;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox Notes;
        private System.Windows.Forms.Label lblCoating;
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
        private System.Windows.Forms.TextBox DesignedDate;
        private System.Windows.Forms.ComboBox MaterialPn;
        private System.Windows.Forms.Label lblMaterialPn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RouteTemplate;
        private System.Windows.Forms.Label lblRouteTemplate;
        private System.Windows.Forms.TextBox OdooProduct;
        private System.Windows.Forms.Label lblOdooProduct;
        private System.Windows.Forms.TextBox BendCount;
        private System.Windows.Forms.TextBox CutOutCount;
        private System.Windows.Forms.TextBox CuttingLengthInner;
        private System.Windows.Forms.TextBox CuttingLengthOuter;
        private System.Windows.Forms.CheckBox NonEcoMod;
        private System.Windows.Forms.CheckBox HoldProduction;
        private System.Windows.Forms.CheckBox HasEtching;
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.TextBox DrawnDate;
        private System.Windows.Forms.Label lblDesigned;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox DrawnBy;
        private System.Windows.Forms.Label lblChildQty;
        private System.Windows.Forms.TextBox ChildQty;
        private System.Windows.Forms.ComboBox Finish;
        private System.Windows.Forms.ComboBox Coating;
        private System.Windows.Forms.DataGridView dgEcos;
        private System.Windows.Forms.Button btnSearchRm;
        private System.Windows.Forms.Button UpdateOdoo;
        private System.Windows.Forms.Button btnOverwriteEcos;
        private System.Windows.Forms.PictureBox OdooImage;
        private System.Windows.Forms.ContextMenuStrip cmsGeneric;
        private System.Windows.Forms.ToolStripMenuItem cmiOdoo;
        private System.Windows.Forms.ToolStripMenuItem cmiSw;
        private System.Windows.Forms.Label MaterialPnChange;
        private System.Windows.Forms.Label ChildQtyChange;
        private System.Windows.Forms.Label RouteTemplateChange;
        private System.Windows.Forms.Label UomChange;
        private System.Windows.Forms.Label AltQtyValueChange;
        private System.Windows.Forms.Label MakeChange;
        private System.Windows.Forms.Label HasEtchingChange;
        private System.Windows.Forms.Label NonEcoModChange;
        private System.Windows.Forms.Label HoldProductionChange;
        private System.Windows.Forms.Label CutOutCountChange;
        private System.Windows.Forms.Label CuttingLengthInnerChange;
        private System.Windows.Forms.Label CuttingLengthOuterChange;
        private System.Windows.Forms.Label BendCountChange;
        private System.Windows.Forms.Label DescriptionChange;
        private System.Windows.Forms.Label NotesChange;
        private System.Windows.Forms.Label MaterialChange;
        private System.Windows.Forms.Label DesignedByChange;
        private System.Windows.Forms.Label DrawnByChange;
        private System.Windows.Forms.Label FinishChange;
        private System.Windows.Forms.Label CoatingChange;
        private System.Windows.Forms.Label TypeChange;
        private System.Windows.Forms.Label EcosChange;
        private System.Windows.Forms.Label EcoRevsChange;
        private System.Windows.Forms.Label ZoneChange;
        private System.Windows.Forms.Label EcoDescriptionsChange;
        private System.Windows.Forms.Label EcoDatesChange;
        private System.Windows.Forms.Label EcoChksChange;
        private System.Windows.Forms.Label DesignedDateChange;
        private System.Windows.Forms.Label DrawnDateChange;
        private System.Windows.Forms.Label PartNumChange;
        private System.Windows.Forms.Label RevisionChange;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnCopyFrom;
        private System.Windows.Forms.TextBox AltQtyValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Thickness;
    }
}

