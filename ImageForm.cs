using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swdocumentmgr;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using SwApiWrapper;
using OdooClient;

namespace ImageForm
{
    public partial class ImageForm : Form
    {

        private SwModelWrapper swMod;
        private OdooProduct oProd;
        private int viewInt = 7;

        public ImageForm(SwModelWrapper swMod, OdooProduct oProd)
        {
            InitializeComponent();
            this.swMod = swMod;
            this.oProd = oProd;
            GetOdooImage();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                switch (radioButton.Name)
                {
                    case "rdbIso":
                        // swIsometricView = 7
                        viewInt = 7;
                        break;
                    case "rdbTri":
                        // swTrimetricView = 8
                        viewInt = 8;
                        break;
                    case "rdbDi":
                        // swDimetricView = 9
                        viewInt = 9;
                        break;
                    case "rdbCurrent":
                        viewInt = 0;
                        break;
                    case "rdbNamed":
                        viewInt = -1;
                        if (rdbNamed.Checked)
                        {
                            txtNamed.Enabled = true;
                        }
                        else
                        {
                            txtNamed.Enabled = false;
                        }
                        break;
                }
            }
        }

        private void GetOdooImage()
        {
            if (this.oProd != null && this.oProd.TemplateRecord["image"] != null)
            {
                byte[] bytes = Convert.FromBase64String((string)this.oProd.TemplateRecord["image"]);
                pbOdooImage.Image = SwCustProp.ByteArrayToImage(bytes);
                cmdUpload.Text = "Replace";
            }
        }

        private void CmdGetImage_Click(object sender, EventArgs e)
        {
            // get the image and populate the form picturebox
            if (rdbCurrent.Checked)
            {
                pbModelImage.Image = swMod.GetCurrentImage();
            }
            else if (rdbNamed.Checked)
            {
                string viewName = txtNamed.Text;
                if (viewName == null | viewName == "")
                {
                    MessageBox.Show("A view name is reqired");
                    return;
                }
                pbModelImage.Image = swMod.GetNamedImage(viewName);
            }
            else
            {
                pbModelImage.Image = swMod.GetStandardImage(viewInt);
            }
        }

        private void CmdUpload_Click(object sender, EventArgs e)
        {
            if (oProd == null)
                MessageBox.Show("No Odoo product has been loaded");
                return;
            byte[] byteArray = SwCustProp.ImageToByteArray((Bitmap)pbModelImage.Image);
            string base64String = Convert.ToBase64String(byteArray);
            Dictionary<string, Object> values = new Dictionary<string, Object>()
            {
                { "image", base64String },
            };
            oProd.Write(values);
            GetOdooImage();
        }

        private void CopyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage((Bitmap)pbModelImage.Image);
            MessageBox.Show("Image copied to clipboard");
        }
    }
}
