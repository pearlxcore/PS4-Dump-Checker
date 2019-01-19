using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS4_NOR_Dump_Checker
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DevBoard DevBoard = new DevBoard();
            DevBoard.ShowDialog();

            if (DevBoard.DialogResult == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }
    }
}
