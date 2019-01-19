using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.IO;

namespace PS4_NOR_Dump_Checker
{
    public partial class Hex_Viewer : Form
    {
        DevBoard dv;

        public Hex_Viewer(DevBoard dev)
        {
            InitializeComponent();
            this.dv = dev;
        }

        private void Hex_Viewer_Load(object sender, EventArgs e)
        {
            HEXtextBox1.Enabled = false;
            HEXtextBox1.Text = dv.textOpen.Text;

            ByteViewer bv = new ByteViewer();
            bv.SetFile(HEXtextBox1.Text); // or SetBytes
            Controls.Add(bv);
        }
    }
}
