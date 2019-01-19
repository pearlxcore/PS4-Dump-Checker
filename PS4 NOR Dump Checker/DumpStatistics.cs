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

namespace PS4_NOR_Dump_Checker
{
    public partial class DumpStatistics : Form
    {

        public string Filename { get; set; }
        private FileInfo currentFile;


        DevBoard dv;
        public DumpStatistics(DevBoard dev)
        {
            InitializeComponent();
            this.dv = dev;


        }
        

        private void DumpStatistics_Load(object sender, EventArgs e)
        {
            tbOpen.Text = dv.textOpen.Text.ToString();
            FileInfo file = new FileInfo(Filename);

        }



    }
}
