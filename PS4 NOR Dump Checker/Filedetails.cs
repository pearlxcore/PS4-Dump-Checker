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
    public partial class Filedetails : Form
    {
        private DataEntropy currentEntropy;

        public Filedetails(DataEntropy entropy)
        {
            InitializeComponent();
            currentEntropy = entropy;
        }

        private void Filedetails_Shown(object sender, EventArgs e)
        {
            int num1 = 1;
            List<Tuple<int, byte>> tupleList = new List<Tuple<int, byte>>();
            foreach (KeyValuePair<byte, int> keyValuePair in currentEntropy.DistributionDict)
                tupleList.Add(new Tuple<int, byte>(keyValuePair.Value, keyValuePair.Key));
                tupleList.Sort();
                tupleList.Reverse();
            foreach (Tuple<int, byte> tuple in tupleList)
            {
                int num2 = (int)tuple.Item2;
                string str1 = tuple.Item2.ToString("X");
                string str2 = Encoding.UTF8.GetString(new byte[1]
                {
                    tuple.Item2
                });
                int num3 = tuple.Item1;
                string str3 = currentEntropy.ProbabilityDict[tuple.Item2].ToString("##0.######");
                dataGridView1.Rows.Add((object)num1, (object)num2, (object)str1, (object)str2, (object)num3, (object)str3);
                ++num1;
            }
        }
    }
}
