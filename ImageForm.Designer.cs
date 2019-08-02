namespace ImageForm
{
    partial class ImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageForm));
            this.pbModelImage = new System.Windows.Forms.PictureBox();
            this.cmdGetImage = new System.Windows.Forms.Button();
            this.cmdUpload = new System.Windows.Forms.Button();
            this.gbxViews = new System.Windows.Forms.GroupBox();
            this.txtNamed = new System.Windows.Forms.TextBox();
            this.rdbNamed = new System.Windows.Forms.RadioButton();
            this.rdbTri = new System.Windows.Forms.RadioButton();
            this.rdbDi = new System.Windows.Forms.RadioButton();
            this.rdbIso = new System.Windows.Forms.RadioButton();
            this.rdbCurrent = new System.Windows.Forms.RadioButton();
            this.pbOdooImage = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbModelImage)).BeginInit();
            this.gbxViews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOdooImage)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbModelImage
            // 
            this.pbModelImage.ContextMenuStrip = this.contextMenuStrip1;
            this.pbModelImage.Location = new System.Drawing.Point(12, 14);
            this.pbModelImage.Name = "pbModelImage";
            this.pbModelImage.Size = new System.Drawing.Size(320, 320);
            this.pbModelImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbModelImage.TabIndex = 0;
            this.pbModelImage.TabStop = false;
            // 
            // cmdGetImage
            // 
            this.cmdGetImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGetImage.Location = new System.Drawing.Point(356, 180);
            this.cmdGetImage.Name = "cmdGetImage";
            this.cmdGetImage.Size = new System.Drawing.Size(101, 23);
            this.cmdGetImage.TabIndex = 1;
            this.cmdGetImage.Text = "Get Image";
            this.cmdGetImage.UseVisualStyleBackColor = true;
            this.cmdGetImage.Click += new System.EventHandler(this.CmdGetImage_Click);
            // 
            // cmdUpload
            // 
            this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpload.Location = new System.Drawing.Point(356, 316);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(101, 23);
            this.cmdUpload.TabIndex = 2;
            this.cmdUpload.Text = "Upload";
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.CmdUpload_Click);
            // 
            // gbxViews
            // 
            this.gbxViews.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxViews.Controls.Add(this.txtNamed);
            this.gbxViews.Controls.Add(this.rdbNamed);
            this.gbxViews.Controls.Add(this.rdbTri);
            this.gbxViews.Controls.Add(this.rdbDi);
            this.gbxViews.Controls.Add(this.rdbIso);
            this.gbxViews.Controls.Add(this.rdbCurrent);
            this.gbxViews.Location = new System.Drawing.Point(356, 12);
            this.gbxViews.Name = "gbxViews";
            this.gbxViews.Size = new System.Drawing.Size(101, 162);
            this.gbxViews.TabIndex = 7;
            this.gbxViews.TabStop = false;
            this.gbxViews.Text = "Views";
            // 
            // txtNamed
            // 
            this.txtNamed.Enabled = false;
            this.txtNamed.Location = new System.Drawing.Point(6, 134);
            this.txtNamed.Name = "txtNamed";
            this.txtNamed.Size = new System.Drawing.Size(89, 20);
            this.txtNamed.TabIndex = 5;
            // 
            // rdbNamed
            // 
            this.rdbNamed.AutoSize = true;
            this.rdbNamed.Location = new System.Drawing.Point(6, 111);
            this.rdbNamed.Name = "rdbNamed";
            this.rdbNamed.Size = new System.Drawing.Size(59, 17);
            this.rdbNamed.TabIndex = 4;
            this.rdbNamed.Text = "Named";
            this.rdbNamed.UseVisualStyleBackColor = true;
            this.rdbNamed.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rdbTri
            // 
            this.rdbTri.AutoSize = true;
            this.rdbTri.Location = new System.Drawing.Point(6, 42);
            this.rdbTri.Name = "rdbTri";
            this.rdbTri.Size = new System.Drawing.Size(65, 17);
            this.rdbTri.TabIndex = 3;
            this.rdbTri.Tag = "9";
            this.rdbTri.Text = "Trimetric";
            this.rdbTri.UseVisualStyleBackColor = true;
            this.rdbTri.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rdbDi
            // 
            this.rdbDi.AutoSize = true;
            this.rdbDi.Location = new System.Drawing.Point(6, 65);
            this.rdbDi.Name = "rdbDi";
            this.rdbDi.Size = new System.Drawing.Size(63, 17);
            this.rdbDi.TabIndex = 2;
            this.rdbDi.Tag = "8";
            this.rdbDi.Text = "Dimetric";
            this.rdbDi.UseVisualStyleBackColor = true;
            this.rdbDi.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rdbIso
            // 
            this.rdbIso.AutoSize = true;
            this.rdbIso.Checked = true;
            this.rdbIso.Location = new System.Drawing.Point(6, 19);
            this.rdbIso.Name = "rdbIso";
            this.rdbIso.Size = new System.Drawing.Size(67, 17);
            this.rdbIso.TabIndex = 1;
            this.rdbIso.TabStop = true;
            this.rdbIso.Tag = "7";
            this.rdbIso.Text = "Isometric";
            this.rdbIso.UseVisualStyleBackColor = true;
            this.rdbIso.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rdbCurrent
            // 
            this.rdbCurrent.AutoSize = true;
            this.rdbCurrent.Location = new System.Drawing.Point(6, 88);
            this.rdbCurrent.Name = "rdbCurrent";
            this.rdbCurrent.Size = new System.Drawing.Size(59, 17);
            this.rdbCurrent.TabIndex = 0;
            this.rdbCurrent.Text = "Current";
            this.rdbCurrent.UseVisualStyleBackColor = true;
            this.rdbCurrent.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // pbOdooImage
            // 
            this.pbOdooImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbOdooImage.Location = new System.Drawing.Point(356, 209);
            this.pbOdooImage.Name = "pbOdooImage";
            this.pbOdooImage.Size = new System.Drawing.Size(101, 101);
            this.pbOdooImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOdooImage.TabIndex = 8;
            this.pbOdooImage.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 26);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to Clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopyToClipboardToolStripMenuItem_Click);
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 345);
            this.Controls.Add(this.pbOdooImage);
            this.Controls.Add(this.gbxViews);
            this.Controls.Add(this.cmdUpload);
            this.Controls.Add(this.cmdGetImage);
            this.Controls.Add(this.pbModelImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageForm";
            this.Text = "Images";
            ((System.ComponentModel.ISupportInitialize)(this.pbModelImage)).EndInit();
            this.gbxViews.ResumeLayout(false);
            this.gbxViews.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOdooImage)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbModelImage;
        private System.Windows.Forms.Button cmdGetImage;
        private System.Windows.Forms.Button cmdUpload;
        private System.Windows.Forms.GroupBox gbxViews;
        private System.Windows.Forms.TextBox txtNamed;
        private System.Windows.Forms.RadioButton rdbNamed;
        private System.Windows.Forms.RadioButton rdbTri;
        private System.Windows.Forms.RadioButton rdbDi;
        private System.Windows.Forms.RadioButton rdbIso;
        private System.Windows.Forms.RadioButton rdbCurrent;
        private System.Windows.Forms.PictureBox pbOdooImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
    }
}

