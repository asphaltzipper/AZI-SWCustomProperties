using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sw_BOM_Scan
{
    public partial class AppendOverwriteBox : Form
    {
        public AppendOverwriteBox()
        {
            InitializeComponent();
            this.Icon = SystemIcons.Warning;
            pictureBox1.Image = SystemIcons.Warning.ToBitmap();
        }

        // This doesn't work
        //public static DialogResult Show(IWin32Window owner, string fileName)
        //{
        //    AppendOverwriteBox me = new AppendOverwriteBox();
        //    me.label1.Text += fileName;
        //    return me.ShowDialog(owner);
        //}

    }
}
