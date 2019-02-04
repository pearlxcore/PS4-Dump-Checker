using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.ComponentModel.Design;

namespace PS4_NOR_Dump_Checker
{
    public partial class DevBoard : Form
    {
        #region 
        byte[] FF_32 = Enumerable.Repeat((byte)0xFF, 32).ToArray();

        byte[] FF_96 = Enumerable.Repeat((byte)0xFF, 96).ToArray();

        byte[] FF_2 = Enumerable.Repeat((byte)0xFF, 2).ToArray();

        byte[] FF_1 = Enumerable.Repeat((byte)0xFF, 1).ToArray();

        byte[] FF_4 = Enumerable.Repeat((byte)0xFF, 4).ToArray();

        byte[] FF_6 = Enumerable.Repeat((byte)0xFF, 6).ToArray();

        byte[] FF_7 = Enumerable.Repeat((byte)0xFF, 7).ToArray();

        byte[] FF_8 = Enumerable.Repeat((byte)0xFF, 8).ToArray();

        byte[] FF_10 = Enumerable.Repeat((byte)0xFF, 10).ToArray();

        byte[] FF_15 = Enumerable.Repeat((byte)0xFF, 15).ToArray();

        byte[] FF_16 = Enumerable.Repeat((byte)0xFF, 16).ToArray();

        byte[] FF_21 = Enumerable.Repeat((byte)0xFF, 21).ToArray();

        byte[] FF_512 = Enumerable.Repeat((byte)0xFF, 512).ToArray();

        static byte[] SKUretail = new byte[4]
        {
            0x76, 0xB3, 0x80, 0x02,
        };

        static byte[] SKUdevtest = new byte[4]
        {
            0x77, 0xB3, 0xC0, 0x02,
        };

        static byte[] Torus1Static = new byte[10]
        {
            0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04,
        };

        static byte[] Torus2Static = new byte[10]
        {
            0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x08, 0x00, 0x08, 0x00,
        };

        static byte[] C0018001Magic = new byte[8]
        {
            0x43, 0x30, 0x30, 0x31, 0x38, 0x30, 0x30, 0x31,
        };
        
        static byte[] eap_kblMagic = new byte[7]
        {
            0x65, 0x61, 0x70, 0x5F, 0x6B, 0x62, 0x6C,
        };

        static byte[] eap_kbl_alt = new byte[8]
        {
            0x43, 0x30, 0x30, 0x31, 0x38, 0x30, 0x30, 0x31,
        };

        #endregion

        #region Vars
        static int flag = 0;
        private string pathonly;
        static string filepath, region;
        public double countff, count00, countother;
        byte[] dump;
        public static string ffresult;
        static int s, r;
        static string bufferString;
        public static string overLoad = "";
        static byte[] bufferEAP = new byte[0];
        static byte[] bufferC0018001 = new byte[0];
        static byte[] bufferC0018001_2nd = new byte[0];
        static byte[] bufferA = new byte[0];
        static byte[] bufferB = new byte[0];
        static byte[] bufferC = new byte[0];
        static byte[] bufferD = new byte[0];
        static byte[] bufferE = new byte[0];
        static byte[] bufferZ = new byte[0];
        #endregion Vars

        public static long gilo = 0x000000;
        
        private void CheckDumpPS4(string str)
        {
            saveLogToolStripMenuItem.Enabled = true;
            hexViewerToolStripMenuItem.Enabled = true;
            dumpAnalysisToolStripMenuItem.Enabled = true;

            listView1.Items.Clear();
            listView2.Items.Clear();
            richTextBox1.Clear();
            
            if (str == "s")
            {

            }
            else if (str == "o")
            {
                bufferString = textOpen.Text;
            }

            ASCIIEncoding encode = new ASCIIEncoding();
            PS4NOR.CheckDumpFull(bufferString);

            #region CheckingResult

            string Good = ": OK! ";
            string Bad = ": BAD! ";
            string Static = DateTime.Now.ToString("hh:mm:ss  ") + "Static Section                              ";
            string Static00 = DateTime.Now.ToString("hh:mm:ss  ") + "Static Section (00 filled)                  ";
            string StaticFF = DateTime.Now.ToString("hh:mm:ss  ") + "Static Section (FF filled)                ";
            string Dynamic = DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section                             ";
            string Staticmc1 = DateTime.Now.ToString("hh:mm:ss  ") + "[MC1] Static Section                        ";
            string Staticmc2 = DateTime.Now.ToString("hh:mm:ss  ") + "[MC2] Static Section                        ";
            string StaticEAP = DateTime.Now.ToString("hh:mm:ss  ") + "[EAP_KBL] Static Section                    ";
            string Staticmwifibt = DateTime.Now.ToString("hh:mm:ss  ") + "[WIFI/BT] Static Section                    ";
            string StaticVTRMR0 = DateTime.Now.ToString("hh:mm:ss  ") + "[Region 0] Static Section                   ";
            string StaticVTRMR1 = DateTime.Now.ToString("hh:mm:ss  ") + "[Region 1] Static Section                   ";
            string StaticVTRMR000 = DateTime.Now.ToString("hh:mm:ss  ") + "[Region 0] Static Section (00 filled)       ";
            string StaticVTRMR0FF = DateTime.Now.ToString("hh:mm:ss  ") + "[Region 0] Static Section (FF filled)       ";
            string StaticVTRMR100 = DateTime.Now.ToString("hh:mm:ss  ") + "[Region 1] Static Section (00 filled)       ";
            string StaticVTRMR1FF = DateTime.Now.ToString("hh:mm:ss  ") + "[Region 1] Static Section (FF filled)       ";

            #region SCE

            //SCE Headers
            richTextBox1.Text += Environment.NewLine + "//SCE Header Section" + Environment.NewLine + Environment.NewLine;

            if (PS4NOR._sceBigMagic == true)
            {
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x000000");
                listView1.Items.Add(lvi);
                s++;
                //get SCE string
                bufferA = PS4NOR.GetSCE1(textOpen.Text);
                richTextBox1.Text += Static + Good + encode.GetString(bufferA) + Environment.NewLine;
            }
            else
            {
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x000000");
                listView1.Items.Add(lvi);
                r++;
                richTextBox1.Text += Static + Bad + Environment.NewLine;
            }
            if (PS4NOR._StaticSection1 == true)
            {
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x000020");
                listView1.Items.Add(lvi);
                s++;
                richTextBox1.Text += Static + Good + Environment.NewLine;
            }
            else
            {
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x000020");
                listView1.Items.Add(lvi);
                r++;
                richTextBox1.Text += Static + Bad + Environment.NewLine;
            }
            if (PS4NOR._StaticSection2 == true)
            {
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x000040");
                listView1.Items.Add(lvi);
                s++;
                richTextBox1.Text += Static00 + Good + Environment.NewLine;
            }
            else
            {
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x000040");
                listView1.Items.Add(lvi);
                r++;
                richTextBox1.Text += Static00 + Bad + Environment.NewLine;
            }
            bufferA = PS4NOR.GetDynamicSection1(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_1) == true)
            {
                ListViewItem lvi = new ListViewItem("SCE Dynamic Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x001000");
                listView2.Items.Add(lvi);
                r++;
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                ListViewItem lvi = new ListViewItem("SCE Dynamic Section");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", " "));
                lvi.SubItems.Add("0x001000");
                listView2.Items.Add(lvi);
                s++;
                richTextBox1.Text += Dynamic + Good + BitConverter.ToString(bufferA).Replace("-", " ") + Environment.NewLine;
            }
            if (PS4NOR._StaticSection3 == true)
            {
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x001010");
                listView1.Items.Add(lvi);
                s++;
                richTextBox1.Text += Static00 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                richTextBox1.Text += Static00 + Bad + Environment.NewLine;
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x001010");
                listView1.Items.Add(lvi);
            }
            if (PS4NOR._sceSmallMagic1 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x002000");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetSCE2(textOpen.Text);
                richTextBox1.Text += Static + Good + encode.GetString(bufferA) + Environment.NewLine;
             
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x002000");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Static + Bad + Environment.NewLine;
            }
            if (PS4NOR._StaticSection4 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x0020B0");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Static00 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x0020B0");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Static00 + Bad + Environment.NewLine;
            }
            if (PS4NOR._sceSmallMagic2 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x003000");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetSCE3(textOpen.Text);
                richTextBox1.Text += Static + Good + encode.GetString(bufferA) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x003000");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Static + Bad + Environment.NewLine;
            }
            if (PS4NOR._StaticSection5 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x0030B0");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Static00 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCE Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x0030B0");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Static00 + Bad + Environment.NewLine;
            }

            #endregion SCE

            #region SLB2
            ///SLB2 Section/////////
            richTextBox1.Text += Environment.NewLine + "//SLB2 SECTION" + Environment.NewLine + Environment.NewLine;

            if (PS4NOR._slb2Magic1 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 1) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x004000");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetSLB_MC1(textOpen.Text);
                richTextBox1.Text += Staticmc1 + Good + encode.GetString(bufferA) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 1) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x004000");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Staticmc1 + Bad + Environment.NewLine;
            }
            if (PS4NOR._C0000001Magic1 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 1) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x004030");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetMC1C0000001(textOpen.Text);
                richTextBox1.Text += Staticmc1 + Good + encode.GetString(bufferA) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 1) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x004030");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Staticmc1 + Bad + Environment.NewLine;
            }
            if (PS4NOR._C0008001Magic1 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 1) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x004060");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetMC1C0008001(textOpen.Text);
                richTextBox1.Text += Staticmc1 + Good + encode.GetString(bufferA) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 1) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x004060");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Staticmc1 + Bad + Environment.NewLine;
            }
            if (PS4NOR._StaticSection7 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 1) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x064070");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetMC1C0008001(textOpen.Text);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "[MC1] Static Section (0x00 filled)          : OK!" + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 1) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x064070");
                listView1.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "[MC1] Static Section (0x00 filled)          : BAD!" + Environment.NewLine;
            }
            if (PS4NOR._dbcbMagic1 == true)
            {
                s++;
                bufferA = PS4NOR.GetDBCB1(textOpen.Text); ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 1) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x004218");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Staticmc1 + Good + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 1) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x004218");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Staticmc1 + Bad + Environment.NewLine;
            }

            //MEDIACON 2
            if (PS4NOR._slb2Magic2 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 2) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x064000");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetSLB_MC2(textOpen.Text);
                richTextBox1.Text += Environment.NewLine + Staticmc2 + Good + encode.GetString(bufferA) + "" + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 2) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x064000");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Environment.NewLine + Staticmc2 + Bad + Environment.NewLine;
            }
            if (PS4NOR._C0000001Magic2 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 2) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x064030");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetMC2C0000001(textOpen.Text);
                richTextBox1.Text += Staticmc2 + Good + encode.GetString(bufferA) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 2) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x064030");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Staticmc2 + Bad + Environment.NewLine;
            }
            if (PS4NOR._C0008001Magic2 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 2) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x064060");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetMC2C0008001(textOpen.Text);
                richTextBox1.Text += Staticmc2 + Good + encode.GetString(bufferA) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 2) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x064060");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Staticmc2 + Bad + Environment.NewLine;
            }
            if (PS4NOR._StaticSection7 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 2) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x064070");
                listView1.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "[MC2] Static Section (0x00 filled)          : OK!" + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 2) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x064070");
                listView1.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "[MC2] Static Section (0x00 filled)          : BAD!" + Environment.NewLine;
            }
            if (PS4NOR._dbcbMagic2 == true)
            {
                s++;
                bufferA = PS4NOR.GetDBCB2(textOpen.Text);
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 2) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x064218");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Staticmc2 + Good + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
                            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (MediaCon 2) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x064218");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Staticmc2 + Bad + Environment.NewLine + Environment.NewLine;
            }

            ///SLB2 EAP_KBL
            if (PS4NOR._slb2Magic3 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (EAP_KBL) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x0C4000");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetSLB_EAPKBL(textOpen.Text);
                richTextBox1.Text += Environment.NewLine + StaticEAP + Good + encode.GetString(bufferA) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (EAP_KBL) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x0C4000");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticEAP + Bad + Environment.NewLine;
            }
            if (PS4NOR._C0010001Magic == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (EAP_KBL) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x0C4030");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetEAP_KBL_C0010001(textOpen.Text);
                richTextBox1.Text += StaticEAP + Good + encode.GetString(bufferA) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (EAP_KBL) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x0C4030");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticEAP + Bad + Environment.NewLine;
            }
            bufferEAP = PS4NOR.GetEAP_KBL_eap_kbl(textOpen.Text);
            if (Tool.CompareBytes(bufferEAP, eap_kblMagic) == false && Tool.CompareBytes(bufferEAP, FF_7) == false && Tool.CompareBytes(bufferEAP, eap_kbl_alt) == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (EAP_KBL) Static Section");
                lvi.SubItems.Add("SKIPPED");
                lvi.SubItems.Add("0x0C4060");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticEAP + Good + ": Skipped. Dump does not contain 'eap_kbl'" + Environment.NewLine;
            }
            else if (Tool.CompareBytes(bufferEAP, eap_kblMagic) == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (EAP_KBL) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x0C4060");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticEAP + Good + encode.GetString(bufferEAP) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (EAP_KBL) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x0C4060");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticEAP + Bad + Environment.NewLine;
            }
            bufferC0018001 = PS4NOR.GetEAP_KBL_C0018001(textOpen.Text);
            bufferC0018001_2nd = PS4NOR.GetEAP_KBL_eap_kbl(textOpen.Text);
            if (Tool.CompareBytes(bufferC0018001, C0018001Magic) == false && Tool.CompareBytes(bufferC0018001, FF_8) == false && Tool.CompareBytes(bufferC0018001_2nd, C0018001Magic) == true)
            {
                s++;
                richTextBox1.Text += StaticEAP + Good + ": 'C0018001' located at 0xC4072" + Environment.NewLine;
                ListViewItem lvi = new ListViewItem("SLB2 (EAP_KBL) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x0C4090");
                listView1.Items.Add(lvi);
            }
            else if (Tool.CompareBytes(bufferC0018001, C0018001Magic) == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (EAP_KBL) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x0C4090");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticEAP + Good + encode.GetString(bufferC0018001) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (EAP_KBL) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x0C4090");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticEAP + Bad + Environment.NewLine;
            }
            if (PS4NOR._StaticSection8)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (EAP_KBL) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x0C40A0");
                listView1.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "[EAP_KBL] Static Section (0x00 filled)      : OK!" + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (EAP_KBL) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x0C40A0");
                listView1.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "[EAP_KBL] Static Section (0x00 filled)      : BAD!" + Environment.NewLine;
            }
            if (PS4NOR._dbcbMagic3 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (EAP_KBL) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x0C4218");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetDBCB3(textOpen.Text);
                richTextBox1.Text += StaticEAP + Good + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (EAP_KBL) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x0C4218");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticEAP + Bad + Environment.NewLine + Environment.NewLine;
            }

            ///slb2 wifi/bt
            if (PS4NOR._slb2Magic4 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (WIFI/BT) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x144000");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetSLB_WIFIBT(textOpen.Text);
                richTextBox1.Text += Staticmwifibt + Good + encode.GetString(bufferA) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (WIFI/BT) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x144000");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Staticmwifibt + Bad + Environment.NewLine;
            }
            if (PS4NOR._C0020001Magic == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (WIFI/BT) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x144030");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetWIFIBT_C0020001(textOpen.Text);
                richTextBox1.Text += Staticmwifibt + Good + encode.GetString(bufferA) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (WIFI/BT) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x144030");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetWIFIBT_C0020001(textOpen.Text);
                richTextBox1.Text += Staticmwifibt + Bad + Environment.NewLine;
            }
            if (PS4NOR._C0028001Magic == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SLB2 (WIFI/BT) Static Section");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x144060");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.GetWIFIBT_C0028001(textOpen.Text);
                richTextBox1.Text += Staticmwifibt + Good + encode.GetString(bufferA) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SLB2 (WIFI/BT) Static Section");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x144060");
                listView1.Items.Add(lvi);
                richTextBox1.Text += Staticmwifibt + Bad + Environment.NewLine;
            }

            #endregion SLB2

            #region MAIN INFO

            //display main console info
            //if ff, then display "BAD!"

            richTextBox1.Text += Environment.NewLine + "//CONSOLE MAIN INFO SECTION" + Environment.NewLine + Environment.NewLine;

            bufferA = PS4NOR.GetMAINCONSOLEINFO1(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_16) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("Console Main Informations");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x1C4000");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section                             : " + "BAD!" + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("Console Main Informations");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x1C4000");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section                             : " + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            bufferA = PS4NOR.GetMAINCONSOLEINFO3(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_16) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("Console Main Informations");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x1C8060");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section                             : " + "BAD!" + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("Console Main Informations");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x1C8060");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section                             : " + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            bufferA = PS4NOR.GetMAINCONSOLEINFO2(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_16) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("Console Main Informations");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x1C8010");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section                             : " + "BAD!" + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("Console Main Informations");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x1C8010");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section                             : " + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            bufferA = PS4NOR.GetMAINCONSOLEINFO4(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_16) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("Console Main Informations");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x1C87D0");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section                             : " + "BAD!" + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("Console Main Informations");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x1C87D0");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section                             : " + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            bufferA = PS4NOR.GetMAINCONSOLEINFO5(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_1) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("Console Main Informations (Region Byte)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x1CA5D0");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section                             : " + "BAD!" + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("Console Main Informations (Region Byte)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x1CA5D0");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section (Region Byte)               : " + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            bufferA = PS4NOR.GetMAINCONSOLEINFO6(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_1) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("Console Main Informations (SKU Byte)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x1CA5D1");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section                             : " + "BAD!" + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("Console Main Informations (SKU Byte)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x1CA5D1");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section (Region Byte)               : " + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            bufferA = PS4NOR.GetMAINCONSOLEINFO7(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_6) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("Console Main Informations (SKU Related)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x1CA5D2");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section                             : " + "BAD!" + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("Console Main Informations (SKU Related)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x1CA5D2");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section (Region Byte)               : " + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }


            bufferA = PS4NOR.GetMAINCONSOLEINFO8(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_4) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("Console Main Informations (BIOS Related)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x1CA5D9");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section                             : " + "BAD!" + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("Console Main Informations (BIOS Related)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x1CA5D9");
                listView2.Items.Add(lvi);
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Dynamic Section (Region Byte)               : " + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }

            #endregion MAIN INFO

            #region SCEVTRM

            //SCEVTRM
            richTextBox1.Text += Environment.NewLine + "//SCEVTRM SECTION" + Environment.NewLine + Environment.NewLine;

            #region R0

            if (PS4NOR._scevtrm0Static8 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x380000");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR000 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380000");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR000 + Bad + Environment.NewLine;
            }
            if (PS4NOR._scevtrm0Static9 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x380040");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR0 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380040");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR0 + Bad + Environment.NewLine;
            }
            if (PS4NOR._scevtrm0Static1 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x380044");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR0FF + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380044");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR0FF + Bad + Environment.NewLine;
            }
            if (PS4NOR._scevtrmMagic1 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x380048");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.Getvtrm1(textOpen.Text);
                richTextBox1.Text += StaticVTRMR0 + Good + encode.GetString(bufferA) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380048");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR0 + Bad + Environment.NewLine;
            }
            //dynamic #1
            bufferA = PS4NOR.GetDynamic1vtrm0(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_4) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x38004F");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x38004F");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            if (PS4NOR._scevtrm0Static2 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x380051");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR000 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380051");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR000 + Bad + Environment.NewLine;

            }
            //dynamic 2 byte 380057 disini
            bufferA = PS4NOR.GetDynamic2vtrm0(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_2) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380057");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x380057");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            if (PS4NOR._scevtrm0Static3 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x380059");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR0 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380059");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR0 + Bad + Environment.NewLine;
            }
            //dynamic(2 byte) 380060 disini
            bufferA = PS4NOR.GetDynamic3vtrm0(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_2) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380060");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x380060");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            if (PS4NOR._scevtrm0Static4 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x380062");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR000 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380062");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR000 + Bad + Environment.NewLine;
            }
            //dynamic (2 byte) 380067 disni
            bufferA = PS4NOR.GetDynamic4vtrm0(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_2) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380067");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x380067");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }

            if (PS4NOR._scevtrm0Static5 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x380069");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR000 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380069");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR000 + Bad + Environment.NewLine;
            }
            if (PS4NOR._scevtrm0Static6 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x380070");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR0FF + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380070");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR0FF + Bad + Environment.NewLine;
            }
            //dynamic (1 byte) 380078
            bufferA = PS4NOR.GetDynamic5vtrm0(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_1) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380078");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x380078");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            if (PS4NOR._scevtrm0Static7 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x380079");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR0FF + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380079");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR0FF + Bad + Environment.NewLine;
            }
            //dynamic perconsole (32 byte) 380178
            bufferA = PS4NOR.GetDynamic6vtrm0(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_32) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380178");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x380178");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + Environment.NewLine;
            }
            //dynamic perconsole (32 byte) 382000
            bufferA = PS4NOR.GetDynamic7vtrm0(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_32) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD");
                lvi.SubItems.Add("0x382000");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x382000");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + Environment.NewLine;
            }
            if (PS4NOR._scevtrmFF1 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x380004");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR0FF + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 0)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x380004");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR0FF + Bad + Environment.NewLine;
            }

            #endregion R0

            #region R1

            richTextBox1.Text += Environment.NewLine + Environment.NewLine;

            if (PS4NOR._scevtrm1Static8 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x3A0000");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR100 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0000");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR100 + Bad + Environment.NewLine;
            }
            if (PS4NOR._scevtrm1Static9 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x3A0040");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR1 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0040");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR1 + Bad + Environment.NewLine;
            }
            if (PS4NOR._scevtrm1Static1 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x3A0044");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR1FF + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0044");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR1FF + Bad + Environment.NewLine;
            }
            if (PS4NOR._scevtrmMagic2 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x3A0048");
                listView1.Items.Add(lvi);
                bufferA = PS4NOR.Getvtrm1(textOpen.Text);
                richTextBox1.Text += StaticVTRMR1 + Good + encode.GetString(bufferA) + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0048");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR1 + Bad + Environment.NewLine;
            }
            //dynamic #1
            bufferA = PS4NOR.GetDynamic1vtrm1(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_4) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A004F");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x3A004F");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            if (PS4NOR._scevtrm1Static2 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x3A0051");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR100 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0051");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR100 + Bad + Environment.NewLine;
            }
            //dynamic 2 byte 380057 disini
            bufferA = PS4NOR.GetDynamic2vtrm1(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_2) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0057");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x3A0057");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            if (PS4NOR._scevtrm1Static3 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x3A0059");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR1 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0059");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR1 + Bad + Environment.NewLine;
            }
            //dynamic(2 byte) 380060 disini
            bufferA = PS4NOR.GetDynamic3vtrm1(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_2) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0060");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x3A0060");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            if (PS4NOR._scevtrm1Static4 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x3A0062");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR100 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0062");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR100 + Bad + Environment.NewLine;
            }
            //dynamic (2 byte) 380067 disni
            bufferA = PS4NOR.GetDynamic4vtrm1(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_2) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0067");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x3A0067");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            if (PS4NOR._scevtrm1Static5 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x3A0069");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR100 + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0069");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR100 + Bad + Environment.NewLine;
            }
            if (PS4NOR._scevtrm1Static6 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x3A0070");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR1FF + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0070");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR1FF + Bad + Environment.NewLine;
            }
            //dynamic (1 byte) 380078
            bufferA = PS4NOR.GetDynamic5vtrm1(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_1) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0078");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x3A0078");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + BitConverter.ToString(bufferA).Replace("-", "") + Environment.NewLine;
            }
            if (PS4NOR._scevtrm1Static7 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x3A0079");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR1FF + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0079");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR1FF + Bad + Environment.NewLine;
            }
            //dynamic perconsole (32 byte) 380178
            bufferA = PS4NOR.GetDynamic6vtrm1(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_32) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0178");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x3A0178");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + Environment.NewLine;
            }
            //dynamic perconsole (32 byte) 3A2000
            bufferA = PS4NOR.GetDynamic7vtrm1(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_32) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A2000");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x3A2000");
                listView2.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + Environment.NewLine;
            }
            if (PS4NOR._scevtrmFF2 == true)
            {
                s++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("OK!");
                lvi.SubItems.Add("0x3A0004");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR1FF + Good + Environment.NewLine;
            }
            else
            {
                r++;
                ListViewItem lvi = new ListViewItem("SCEVTRM (Region 1)");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x3A0004");
                listView1.Items.Add(lvi);
                richTextBox1.Text += StaticVTRMR1FF + Bad + Environment.NewLine;
            }

            #endregion R1

            #endregion SCEVTRM

            richTextBox1.Text += Environment.NewLine + Environment.NewLine;

            #region PERCONSOLE_BLOCK

            /*
            bufferA = PS4NOR.GetPerconsole1(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_512) == true)
            {
                r++;
                ListViewItem lvi = new ListViewItem("PerConsole Dynamic");
                lvi.SubItems.Add("BAD!");
                lvi.SubItems.Add("0x2000000");
                listView4.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Bad + Environment.NewLine;
            }
            else
            {
                s++;
                ListViewItem lvi = new ListViewItem("PerConsole Dynamic");
                lvi.SubItems.Add(BitConverter.ToString(bufferA).Replace("-", ""));
                lvi.SubItems.Add("0x2000000");
                listView4.Items.Add(lvi);
                richTextBox1.Text += Dynamic + Good + Environment.NewLine;
            }


            
            if (PS4NOR._blobMagic1 == true)
            {
                s++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x200000) :  OK!" + Environment.NewLine;
            }
            else
            {
                r++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x200000) : BAD!" + Environment.NewLine;
            }
            if (PS4NOR._blobMagic2 == true)
            {
                s++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x201000) :  OK!" + Environment.NewLine;
            }
            else
            {
                r++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x201000) : BAD!" + Environment.NewLine;
            }
            if (PS4NOR._blobMagic3 == true)
            {
                s++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x202000) :  OK!" + Environment.NewLine;
            }
            else
            {
                r++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x202000) : BAD!" + Environment.NewLine;
            }
            if (PS4NOR._blobMagic4 == true)
            {
                s++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x203000) :  OK!" + Environment.NewLine;
            }
            else
            {
                r++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x203000) : BAD!" + Environment.NewLine;
            }
            if (PS4NOR._blobMagic5 == true)
            {
                s++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x290800) :  OK!" + Environment.NewLine;
            }
            else
            {
                r++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x290800) : BAD!" + Environment.NewLine;
            }
            if (PS4NOR._blobMagic6 == true)
            {
                s++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x290A00) :  OK!" + Environment.NewLine;
            }
            else
            {
                r++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x290A00) : BAD!" + Environment.NewLine;
            }
            if (PS4NOR._blobMagic7 == true)
            {
                s++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x290B00) :  OK!" + Environment.NewLine;
            }
            else
            {
                r++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x290B00) : BAD!" + Environment.NewLine;
            }
            if (PS4NOR._blobMagic8 == true)
            {
                s++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x290C00) :  OK!" + Environment.NewLine;
            }
            else
            {
                r++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "PerConsole (0x290C00) : BAD!" + Environment.NewLine;
            }

            */

            #endregion PERCONSOLE_BLOCK


            /*
            if (PS4NOR._c01A == true)
            {
                s++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Checking 'C0000001' size (MC1 & MC2) " + Good + Environment.NewLine;
            }
            else
            {
                r++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Checking 'C0000001' size (MC1 & MC2) " + Bad + Environment.NewLine;
            }
            if (PS4NOR._c01B == true)
            {
                s++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Checking 'C0008001' size (MC1 & MC2) " + Good + Environment.NewLine;
            }
            else
            {
                r++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Checking 'C0008001' size (MC1 & MC2) " + Bad + Environment.NewLine;
            }
            if (PS4NOR._slb2NR3Checksum == true)
            {
                s++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Checksum Region of SLB2 #3 :  OK!" + Environment.NewLine;
            }
            else
            {
                r++;
                richTextBox1.Text += DateTime.Now.ToString("hh:mm:ss  ") + "Checksum Region of SLB2 #3 : BAD!" + Environment.NewLine;

            }*/
            #endregion CheckingResult

            #region GetCID
            //get dump sha1
            SHA1 sha = new SHA1CryptoServiceProvider();
            bufferB = sha.ComputeHash(Tool.readBuffer);
            textSHA1.Text = BitConverter.ToString(bufferB).Replace("-", "");

            //Checking MAC Address and Display it in the GUI
            bufferA = PS4NOR.GetMAC(textOpen.Text);
            if (Tool.CompareBytes(bufferA, PS4NOR.ffMAC) == true)
            {
                r++;
                textMAC.Text = "N/A";
            }
            else
            {
                s++;
                textMAC.Text = BitConverter.ToString(bufferA).Replace("-", ":");
            }
            bufferA = null;

            // Checking SKU model and Display it in the GUI
            bufferA = PS4NOR.GetSKU(textOpen.Text);
            if (Tool.CompareBytes(bufferA, PS4NOR.ffSKU) == true)
            {
                r++;
                textSKU.Text = "N/A";
            }
            else
            {
                s++;
                textSKU.Text = encode.GetString(bufferA).Replace(@"?", "").Replace(@"-", " ");
            }
            bufferA = null;

            if (SKUVERtextBox2.Text == "RETAIL")
            {
                string region = textSKU.Text;
                if (region.Contains("0A") == true)
                {
                    textBoxRegion.Text = "JAPAN";
                }
                else if (region.Contains("1A") == true || (region.Contains("15A") == true))
                {
                    textBoxRegion.Text = "US / CANADA (NORTH AMERICA)";
                }
                else if (region.Contains("2A") == true)
                {
                    textBoxRegion.Text = "AUSTRALIA / NEW ZEALAND (OCEANIA)";
                }
                else if (region.Contains("3A") == true)
                {
                    textBoxRegion.Text = "UK / IRELAND";
                }
                else if (region.Contains("4A") == true || (region.Contains("16A") == true))
                {
                    textBoxRegion.Text = "EUROPE / MIDDLE EAST / AFRICA";
                }
                else if (region.Contains("5A") == true)
                {
                    textBoxRegion.Text = "KOREA (SOUTH KOREA)";
                }
                else if (region.Contains("6A") == true)
                {
                    textBoxRegion.Text = "SOUTHEAST ASIA (MALAYSIA / INDONESIA / PHILLIPINES / SINGAPORE / THAILAND / HONGKONG)";
                }
                else if (region.Contains("7A") == true)
                {
                    textBoxRegion.Text = "TAIWAN";
                }
                else if (region.Contains("8A") == true)
                {
                    textBoxRegion.Text = "RUSSIA / UKRAINE / INDIA / CENTRAL ASIA";
                }
                else if (region.Contains("9A") == true)
                {
                    textBoxRegion.Text = "MAINLAND CHINA";
                }
                else if (region.Contains("11A") == true || (region.Contains("14A") == true))
                {
                    textBoxRegion.Text = "MEXICO / CENTRAL AMERICA / SOUTH AMERICA";
                }
            }
            else
            {
                textBoxRegion.Text = "N/A";
            }

            // Checking SKU retail or devtest and Display it in the GUI
            bufferA = PS4NOR.GetSKUVersion(textOpen.Text);
            if (Tool.CompareBytes(bufferA, SKUretail) == true && Tool.CompareBytes(bufferA, SKUdevtest) == false && Tool.CompareBytes(bufferA, FF_4) == false)
            {
                s++;
                SKUVERtextBox2.Text = "RETAIL";
            }
            else if (Tool.CompareBytes(bufferA, SKUretail) == false && Tool.CompareBytes(bufferA, SKUdevtest) == true && Tool.CompareBytes(bufferA, FF_4) == false)
            {
                s++;
                SKUVERtextBox2.Text = "DEVKIT/TESTKIT";
            }
            else
            {
                r++;
                SKUVERtextBox2.Text = "N/A";
            }
            bufferA = null;

            if (SKUVERtextBox2.Text == "RETAIL")
            {
                string region = textSKU.Text;
                if (region.Contains("0A") == true || (region.Contains("0B") == true))
                {
                    textBoxRegion.Text = "JAPAN";
                }
                else if (region.Contains("1A") == true || (region.Contains("15A") == true || (region.Contains("1B") == true || (region.Contains("15B") == true))))
                {
                    textBoxRegion.Text = "US / CANADA (NORTH AMERICA)";
                }
                else if (region.Contains("2A") == true || (region.Contains("2B") == true))
                {
                    textBoxRegion.Text = "AUSTRALIA / NEW ZEALAND (OCEANIA)";
                }
                else if (region.Contains("3A") == true || (region.Contains("3B") == true))
                {
                    textBoxRegion.Text = "UK / IRELAND";
                }
                else if (region.Contains("4A") == true || (region.Contains("16A") == true || (region.Contains("4B") == true || (region.Contains("16B") == true))))
                {
                    textBoxRegion.Text = "EUROPE / MIDDLE EAST / AFRICA";
                }
                else if (region.Contains("5A") == true || (region.Contains("5B") == true))
                {
                    textBoxRegion.Text = "KOREA (SOUTH KOREA)";
                }
                else if (region.Contains("6A") == true || (region.Contains("6B") == true))
                {
                    textBoxRegion.Text = "SOUTHEAST ASIA (MALAYSIA / INDONESIA / PHILLIPINES / SINGAPORE / THAILAND / HONGKONG)";
                }
                else if (region.Contains("7A") == true || (region.Contains("7B") == true))
                {
                    textBoxRegion.Text = "TAIWAN";
                }
                else if (region.Contains("8A") == true || (region.Contains("8B") == true))
                {
                    textBoxRegion.Text = "RUSSIA / UKRAINE / INDIA / CENTRAL ASIA";
                }
                else if (region.Contains("9A") == true || (region.Contains("9B") == true))
                {
                    textBoxRegion.Text = "MAINLAND CHINA";
                }
                else if (region.Contains("11A") == true || (region.Contains("14A") == true || (region.Contains("11B") == true || (region.Contains("14B") == true))))
                {
                    textBoxRegion.Text = "MEXICO / CENTRAL AMERICA / SOUTH AMERICA";
                }
            }
            else
            {
                textBoxRegion.Text = "N/A";
            }

            // checking hdd info
            bufferA = PS4NOR.GetHDD(textOpen.Text);
            if (Tool.CompareBytes(bufferA, PS4NOR.ffhdd) == true)
            {
                r++;
                textHDD.Text = "N/A";
            }
            else
            {
                s++;
                //swap string from BADCFEHG to ABCDEFGH
                string input = encode.GetString(bufferA);
                StringBuilder output = new StringBuilder();

                char[] characters = input.ToCharArray();

                for (int i = 0; i < characters.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        if ((i + 1) < characters.Length)
                        {
                            output.Append(characters[i + 1]);
                        }
                        output.Append(characters[i]);
                    }
                }
                textHDD.Text = output.ToString();
            }
            bufferA = null;

            // checking hdd SN info
            bufferA = PS4NOR.GetHDDSN(textOpen.Text);
            if (Tool.CompareBytes(bufferA, PS4NOR.FF_21) == true)
            {
                r++;
                HDDSNtextBox1.Text = "N/A";
            }
            else
            {
                s++;
                //swap character from BADCFEHG to ABCDEFGH
                string input = encode.GetString(bufferA);
                StringBuilder output = new StringBuilder();

                char[] characters = input.ToCharArray();

                for (int i = 0; i < characters.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        if ((i + 1) < characters.Length)
                        {
                            output.Append(characters[i + 1]);
                        }
                        output.Append(characters[i]);
                    }
                }
                HDDSNtextBox1.Text = output.ToString().Replace(@" ", "");
            }
            bufferA = null;

            // checking CID
            bufferA = PS4NOR.GetCID(textOpen.Text);
            if (Tool.CompareBytes(bufferA, PS4NOR.ffCID) == true)
            {
                r++;
                textCID.Text = "N/A";
            }
            else
            {
                s++;
                textCID.Text = encode.GetString(bufferA);
            }
            bufferA = null;

            // checking mobo serial
            bufferA = PS4NOR.GetMobo(textOpen.Text);
            if (Tool.CompareBytes(bufferA, FF_16) == true)
            {
                r++;
                mobotextBox1.Text = "N/A";
            }
            else
            {
                s++;
                mobotextBox1.Text = encode.GetString(bufferA);
            }
            bufferA = null;

            // Checking FirmWare Version and Display it in the GUI
            bufferA = PS4NOR.GetFWV(textOpen.Text);
            if (Tool.CompareBytes(bufferA, PS4NOR.ffMAC) == true)
            {
                r++;
                textFWV.Text = "N/A";
            }
            else
            {
                s++;
                bufferString = BitConverter.ToString(bufferA).Replace("-", "");
                textFWV.Text = bufferString.Insert(2, ".").Replace("01.", "1.").Replace("02.", "2.").Replace("03.", "3.").Replace("04.", "4.").Replace("05.", "5.").Replace("06.", "6.").Replace("07.", "7.").Replace("08.", "8.").Replace("09.", "9.").Insert(4, ".");
            }
            bufferA = null;

            //get torus version
            bufferA = PS4NOR.GetTorus(textOpen.Text);
            bufferB = PS4NOR.GetTorusSize(textOpen.Text);
            bufferString = BitConverter.ToString(bufferB).Replace("-", "");
            int decValue = Convert.ToInt32(bufferString, 16);
            if (Tool.CompareBytes(bufferA, Torus1Static) == true && Tool.CompareBytes(bufferA, Torus2Static) == false && Tool.CompareBytes(bufferA, FF_10) == false)
            {
                s++;
                TORUStxtbox.Text = "TORUS 1 " + "(" + decValue + " Bytes)";
                TorusSoCtextBox1.Text = "MARVELL AVASTAR 88W8797";
            }
            else if (Tool.CompareBytes(bufferA, Torus1Static) == false && Tool.CompareBytes(bufferA, Torus2Static) == true && Tool.CompareBytes(bufferA, FF_10) == false)
            {
                s++;
                TORUStxtbox.Text = "TORUS 2 " + "(" + decValue + " Bytes)";
                TorusSoCtextBox1.Text = "MARVELL AVASTAR 88W8897";
            }
            else
            {
                r++;
                TORUStxtbox.Text = "N/A";
            }

            #endregion CheckingCID

            string p = textOpen.Text;
            var filename = Path.GetFileName(p);
            txtboxfilename.Text = filename;
            if (SKUVERtextBox2.Text == "RETAIL")
            {
                MessageBox.Show("Pass : " + s.ToString() + "\nFail : " + r.ToString(), "Checking result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Devkit/Testkit dump detected. Validation may be wrong as this program only compatible with retail NOR dump.", "Checking result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            s = 0;
            r = 0;
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length / 2;
            byte[] bytes = new byte[NumberChars];
            using (var sr = new StringReader(hex))
            {
                for (int i = 0; i < NumberChars; i++)
                    bytes[i] = Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
            }
            return bytes;
        }
        
        public DevBoard()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (openDump.ShowDialog() == DialogResult.OK)
            {
                textOpen.Text = openDump.FileName;
                string p = textOpen.Text;
                s = textOpen.Text.Length;
                bufferString = textOpen.Text.Replace(" ", "");
                r = bufferString.Length;

                if (PS4NOR.CheckHeader(textOpen.Text) == true)
                {
                        bufferB = new byte[20];
                        Tool.readBuffer = null;
                        Tool.ReadWriteData(textOpen.Text, null, "r");
                        
                        s = 0; r = 0;
                    
                        CheckDumpPS4("o");
                }
                else
                {
                    MessageBox.Show("Invalid file or corrupt flash dump.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textOpen.Text = "Select NOR dump";
                }
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About About = new About();
            About.ShowDialog();
        }

        private void hexViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hex_Viewer hex = new Hex_Viewer(this);
            hex.ShowDialog();
        }

        private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("No logs saved");
            }
            else
            {
                SaveFile();
            }
        }

        public void SaveFile()
        {
            string p = textOpen.Text;
            var filename = Path.GetFileNameWithoutExtension(p);
            string path = Environment.CurrentDirectory;
            richTextBox1.SaveFile(path + "\\" + filename + ".txt", RichTextBoxStreamType.PlainText);
            MessageBox.Show("Saved to " + filename + ".txt", "Saved Log File", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
        }

        private void dumpAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analysis anal = new Analysis(this);
            anal.ShowDialog();
        }

        private void CopySelectedValuesToClipboard()
        {
            var builder = new StringBuilder();
            foreach (ListViewItem item in listView1.SelectedItems)
            builder.AppendLine(item.SubItems[2].Text);
            Clipboard.SetText(builder.ToString());
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender != listView1)
                return;

            if (e.Control && e.KeyCode == Keys.C)
                CopySelectedValuesToClipboard();
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
