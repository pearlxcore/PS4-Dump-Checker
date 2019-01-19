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
using System.Diagnostics;

namespace PS4_NOR_Dump_Checker
{
    public partial class Analysis : Form
    {
        private DataEntropy currentEntropy;
        static string dir;
        private FileInfo currentFile;
        private string pathonly;
        static string filepath, region;
        public double countff, count00, countother;
        byte[] dump;
        DevBoard dv;

        public Analysis(DevBoard dev)
        {
            InitializeComponent();
            this.dv = dev;
        }

        private void Analysis_Load(object sender, EventArgs e)
        {
            tbPath.Enabled = false;
            tbPath.Text = dv.textOpen.Text;
            button1.Enabled = false;
        }

        public void LoadFile(FileInfo fi)
        {
            currentFile = fi;
            tbPath.Text = fi.FullName;

            currentEntropy = new DataEntropy(fi);
            tbSpecific.Text = currentEntropy.ShannonSpecificEntropy.ToString("0.##");
            tbNormalized.Text = ((double.Parse(tbSpecific.Text) / 8) * 100).ToString("0.##") + "%";

            button2.Enabled = false;
            button1.Enabled = true;
            stat(fi);
        }

        public void stat(FileInfo fi)
        {
            FileInfo stat = new FileInfo(tbPath.Text);
            long filelength = fi.Length;

            switch (filelength)
            {
                case 33554432:
                    
                    dump = File.ReadAllBytes(tbPath.Text);
                    calc(dump);
                    countff = countff / (double)dump.Length * 100.0;
                    count00 = count00 / (double)dump.Length * 100.0;
                    countother = countother / 254.0 / (double)dump.Length * 100.0;
                    if (dump.Length < 17000000)
                    {
                        if (countff < 10.415 || countff > 10.48)
                            tbFF.ForeColor = Color.Black;
                        tbFF.Text = countff.ToString("0.00") + "%";
                        if (count00 < 18.38 || count00 > 29.01)
                            tb00.ForeColor = Color.Black;
                        tb00.Text = count00.ToString("0.00") + "%";
                        if (countother > 0.5)
                            tbOther.ForeColor = Color.Black;
                        tbOther.Text = countother.ToString("0.00") + "%";
                    }
                    if (dump.Length > 17000000)
                    {
                        if (countff < 18.25 || countff > 24.54)
                            tbFF.ForeColor = Color.Black;
                        tbFF.Text = countff.ToString("0.00") + "%";
                        if (count00 < 1.43 || count00 > 2.68)
                            tb00.ForeColor = Color.Black;
                        tb00.Text = count00.ToString("0.00") + "%";
                        if (countother > 0.5)
                            tbOther.ForeColor = Color.Black;
                        tbOther.Text = countother.ToString("0.00") + "%";
                    }
                    
                    break;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int num = (int)new Filedetails(currentEntropy).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(tbPath.Text);
            dir = fi.Directory.FullName;
            LoadFile(fi);
        }

        public void calc(byte[] Source)
        {
            countff = 0.0;
            count00 = 0.0;
            countother = 0.0;
            for (int index = 0; index < dump.Length; ++index)
            {
                if (dump[index] == byte.MaxValue)
                    ++countff;
                else if (dump[index] == (byte)0)
                    ++count00;
                else if (dump[index] != (byte)0 || dump[index] != byte.MaxValue)
                    ++countother;
            }
        }
        
    }
}
