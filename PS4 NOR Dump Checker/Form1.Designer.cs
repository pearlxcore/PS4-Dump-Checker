namespace PS4_NOR_Dump_Checker
{
    partial class DevBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevBoard));
            this.openDump = new System.Windows.Forms.OpenFileDialog();
            this.Open = new System.Windows.Forms.Button();
            this.textOpen = new System.Windows.Forms.TextBox();
            this.textMAC = new System.Windows.Forms.TextBox();
            this.groupCI = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxRegion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TorusSoCtextBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SKUVERtextBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.HDDSNtextBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TORUStxtbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mobotextBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textCID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtboxfilename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelSHA1 = new System.Windows.Forms.Label();
            this.labelFWV = new System.Windows.Forms.Label();
            this.textSHA1 = new System.Windows.Forms.TextBox();
            this.textFWV = new System.Windows.Forms.TextBox();
            this.labelSKU = new System.Windows.Forms.Label();
            this.textSKU = new System.Windows.Forms.TextBox();
            this.labelMAC = new System.Windows.Forms.Label();
            this.textHDD = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.hexViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupCI.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openDump
            // 
            this.openDump.FileName = "PS4NORDUMP";
            this.openDump.Filter = "|*.BIN";
            this.openDump.Title = "Open PS4 NOR Dump";
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(287, 34);
            this.Open.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(50, 26);
            this.Open.TabIndex = 21;
            this.Open.Text = "Open";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // textOpen
            // 
            this.textOpen.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textOpen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOpen.Location = new System.Drawing.Point(32, 36);
            this.textOpen.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textOpen.Multiline = true;
            this.textOpen.Name = "textOpen";
            this.textOpen.ReadOnly = true;
            this.textOpen.Size = new System.Drawing.Size(251, 21);
            this.textOpen.TabIndex = 20;
            this.textOpen.Text = "Select NOR dump";
            // 
            // textMAC
            // 
            this.textMAC.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textMAC.Location = new System.Drawing.Point(109, 133);
            this.textMAC.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textMAC.Name = "textMAC";
            this.textMAC.ReadOnly = true;
            this.textMAC.Size = new System.Drawing.Size(177, 20);
            this.textMAC.TabIndex = 16;
            // 
            // groupCI
            // 
            this.groupCI.Controls.Add(this.label13);
            this.groupCI.Controls.Add(this.textBoxRegion);
            this.groupCI.Controls.Add(this.label11);
            this.groupCI.Controls.Add(this.TorusSoCtextBox1);
            this.groupCI.Controls.Add(this.label9);
            this.groupCI.Controls.Add(this.SKUVERtextBox2);
            this.groupCI.Controls.Add(this.label8);
            this.groupCI.Controls.Add(this.HDDSNtextBox1);
            this.groupCI.Controls.Add(this.label7);
            this.groupCI.Controls.Add(this.TORUStxtbox);
            this.groupCI.Controls.Add(this.label4);
            this.groupCI.Controls.Add(this.mobotextBox1);
            this.groupCI.Controls.Add(this.label2);
            this.groupCI.Controls.Add(this.textCID);
            this.groupCI.Controls.Add(this.label1);
            this.groupCI.Controls.Add(this.txtboxfilename);
            this.groupCI.Controls.Add(this.label3);
            this.groupCI.Controls.Add(this.labelSHA1);
            this.groupCI.Controls.Add(this.labelFWV);
            this.groupCI.Controls.Add(this.textSHA1);
            this.groupCI.Controls.Add(this.textFWV);
            this.groupCI.Controls.Add(this.labelSKU);
            this.groupCI.Controls.Add(this.textSKU);
            this.groupCI.Controls.Add(this.labelMAC);
            this.groupCI.Controls.Add(this.textMAC);
            this.groupCI.Controls.Add(this.textHDD);
            this.groupCI.Location = new System.Drawing.Point(32, 68);
            this.groupCI.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupCI.MinimumSize = new System.Drawing.Size(276, 239);
            this.groupCI.Name = "groupCI";
            this.groupCI.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupCI.Size = new System.Drawing.Size(305, 487);
            this.groupCI.TabIndex = 22;
            this.groupCI.TabStop = false;
            this.groupCI.Text = "Console Information";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 202);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 14);
            this.label13.TabIndex = 42;
            this.label13.Text = "SKU Region :";
            // 
            // textBoxRegion
            // 
            this.textBoxRegion.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxRegion.Location = new System.Drawing.Point(109, 201);
            this.textBoxRegion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxRegion.Name = "textBoxRegion";
            this.textBoxRegion.ReadOnly = true;
            this.textBoxRegion.Size = new System.Drawing.Size(177, 20);
            this.textBoxRegion.TabIndex = 43;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 440);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 14);
            this.label11.TabIndex = 41;
            this.label11.Text = " WLAN/BT SoC :";
            // 
            // TorusSoCtextBox1
            // 
            this.TorusSoCtextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TorusSoCtextBox1.Location = new System.Drawing.Point(110, 439);
            this.TorusSoCtextBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TorusSoCtextBox1.Name = "TorusSoCtextBox1";
            this.TorusSoCtextBox1.ReadOnly = true;
            this.TorusSoCtextBox1.Size = new System.Drawing.Size(176, 20);
            this.TorusSoCtextBox1.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 236);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 14);
            this.label9.TabIndex = 39;
            this.label9.Text = "SKU Version :";
            // 
            // SKUVERtextBox2
            // 
            this.SKUVERtextBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SKUVERtextBox2.Location = new System.Drawing.Point(109, 235);
            this.SKUVERtextBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SKUVERtextBox2.Name = "SKUVERtextBox2";
            this.SKUVERtextBox2.ReadOnly = true;
            this.SKUVERtextBox2.Size = new System.Drawing.Size(177, 20);
            this.SKUVERtextBox2.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 372);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 14);
            this.label8.TabIndex = 37;
            this.label8.Text = "Hardisk Serial :";
            // 
            // HDDSNtextBox1
            // 
            this.HDDSNtextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.HDDSNtextBox1.Location = new System.Drawing.Point(110, 371);
            this.HDDSNtextBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.HDDSNtextBox1.Name = "HDDSNtextBox1";
            this.HDDSNtextBox1.ReadOnly = true;
            this.HDDSNtextBox1.Size = new System.Drawing.Size(176, 20);
            this.HDDSNtextBox1.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 406);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 14);
            this.label7.TabIndex = 35;
            this.label7.Text = "Wifi/BT Version :";
            // 
            // TORUStxtbox
            // 
            this.TORUStxtbox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TORUStxtbox.Location = new System.Drawing.Point(110, 405);
            this.TORUStxtbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TORUStxtbox.Name = "TORUStxtbox";
            this.TORUStxtbox.ReadOnly = true;
            this.TORUStxtbox.Size = new System.Drawing.Size(176, 20);
            this.TORUStxtbox.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 304);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 14);
            this.label4.TabIndex = 33;
            this.label4.Text = "Mobo Serial :";
            // 
            // mobotextBox1
            // 
            this.mobotextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mobotextBox1.Location = new System.Drawing.Point(109, 303);
            this.mobotextBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mobotextBox1.Name = "mobotextBox1";
            this.mobotextBox1.ReadOnly = true;
            this.mobotextBox1.Size = new System.Drawing.Size(177, 20);
            this.mobotextBox1.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 270);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 31;
            this.label2.Text = "Console Serial :";
            // 
            // textCID
            // 
            this.textCID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textCID.Location = new System.Drawing.Point(109, 269);
            this.textCID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textCID.Name = "textCID";
            this.textCID.ReadOnly = true;
            this.textCID.Size = new System.Drawing.Size(177, 20);
            this.textCID.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 29;
            this.label1.Text = "Filename :";
            // 
            // txtboxfilename
            // 
            this.txtboxfilename.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtboxfilename.Location = new System.Drawing.Point(109, 31);
            this.txtboxfilename.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtboxfilename.Name = "txtboxfilename";
            this.txtboxfilename.ReadOnly = true;
            this.txtboxfilename.Size = new System.Drawing.Size(177, 20);
            this.txtboxfilename.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 338);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "Hardisk Info :";
            // 
            // labelSHA1
            // 
            this.labelSHA1.AutoSize = true;
            this.labelSHA1.Location = new System.Drawing.Point(10, 66);
            this.labelSHA1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSHA1.Name = "labelSHA1";
            this.labelSHA1.Size = new System.Drawing.Size(41, 14);
            this.labelSHA1.TabIndex = 25;
            this.labelSHA1.Text = "SHA1 :";
            // 
            // labelFWV
            // 
            this.labelFWV.AutoSize = true;
            this.labelFWV.Location = new System.Drawing.Point(10, 100);
            this.labelFWV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFWV.Name = "labelFWV";
            this.labelFWV.Size = new System.Drawing.Size(99, 14);
            this.labelFWV.TabIndex = 23;
            this.labelFWV.Text = "Firmware Version :";
            // 
            // textSHA1
            // 
            this.textSHA1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textSHA1.Location = new System.Drawing.Point(109, 65);
            this.textSHA1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textSHA1.Name = "textSHA1";
            this.textSHA1.ReadOnly = true;
            this.textSHA1.Size = new System.Drawing.Size(177, 20);
            this.textSHA1.TabIndex = 24;
            // 
            // textFWV
            // 
            this.textFWV.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textFWV.Location = new System.Drawing.Point(109, 99);
            this.textFWV.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textFWV.Name = "textFWV";
            this.textFWV.ReadOnly = true;
            this.textFWV.Size = new System.Drawing.Size(177, 20);
            this.textFWV.TabIndex = 22;
            // 
            // labelSKU
            // 
            this.labelSKU.AutoSize = true;
            this.labelSKU.Location = new System.Drawing.Point(10, 168);
            this.labelSKU.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSKU.Name = "labelSKU";
            this.labelSKU.Size = new System.Drawing.Size(65, 14);
            this.labelSKU.TabIndex = 20;
            this.labelSKU.Text = "SKU Model :";
            // 
            // textSKU
            // 
            this.textSKU.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textSKU.Location = new System.Drawing.Point(109, 167);
            this.textSKU.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textSKU.Name = "textSKU";
            this.textSKU.ReadOnly = true;
            this.textSKU.Size = new System.Drawing.Size(177, 20);
            this.textSKU.TabIndex = 21;
            // 
            // labelMAC
            // 
            this.labelMAC.AutoSize = true;
            this.labelMAC.Location = new System.Drawing.Point(10, 134);
            this.labelMAC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMAC.Name = "labelMAC";
            this.labelMAC.Size = new System.Drawing.Size(80, 14);
            this.labelMAC.TabIndex = 19;
            this.labelMAC.Text = "MAC Address :";
            // 
            // textHDD
            // 
            this.textHDD.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textHDD.Location = new System.Drawing.Point(109, 337);
            this.textHDD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textHDD.Name = "textHDD";
            this.textHDD.ReadOnly = true;
            this.textHDD.Size = new System.Drawing.Size(177, 20);
            this.textHDD.TabIndex = 26;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.richTextBox1.MaximumSize = new System.Drawing.Size(1000, 933);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(529, 492);
            this.richTextBox1.TabIndex = 25;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(940, 25);
            this.toolStrip1.TabIndex = 41;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLogToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            this.toolStripDropDownButton1.ToolTipText = "File";
            // 
            // saveLogToolStripMenuItem
            // 
            this.saveLogToolStripMenuItem.Enabled = false;
            this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
            this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveLogToolStripMenuItem.Text = "Save Log";
            this.saveLogToolStripMenuItem.Click += new System.EventHandler(this.saveLogToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hexViewerToolStripMenuItem,
            this.dumpAnalysisToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(48, 22);
            this.toolStripDropDownButton3.Text = "Tools";
            // 
            // hexViewerToolStripMenuItem
            // 
            this.hexViewerToolStripMenuItem.Enabled = false;
            this.hexViewerToolStripMenuItem.Name = "hexViewerToolStripMenuItem";
            this.hexViewerToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.hexViewerToolStripMenuItem.Text = "Hex Viewer";
            this.hexViewerToolStripMenuItem.Click += new System.EventHandler(this.hexViewerToolStripMenuItem_Click);
            // 
            // dumpAnalysisToolStripMenuItem
            // 
            this.dumpAnalysisToolStripMenuItem.Enabled = false;
            this.dumpAnalysisToolStripMenuItem.Name = "dumpAnalysisToolStripMenuItem";
            this.dumpAnalysisToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.dumpAnalysisToolStripMenuItem.Text = "Dump Analysis";
            this.dumpAnalysisToolStripMenuItem.Click += new System.EventHandler(this.dumpAnalysisToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton2.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(371, 36);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.MaximumSize = new System.Drawing.Size(1000, 933);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(539, 519);
            this.tabControl1.TabIndex = 43;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Size = new System.Drawing.Size(531, 492);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Static Section";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.AutoArrange = false;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listView1.MaximumSize = new System.Drawing.Size(858, 861);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(531, 492);
            this.listView1.TabIndex = 44;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Function";
            this.columnHeader1.Width = 304;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 2;
            this.columnHeader2.Text = "Status";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 1;
            this.columnHeader3.Text = "Location";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 106;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(531, 492);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dynamic Section";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.AutoArrange = false;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView2.GridLines = true;
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView2.LabelWrap = false;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listView2.MaximumSize = new System.Drawing.Size(858, 861);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(531, 492);
            this.listView2.TabIndex = 45;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Function";
            this.columnHeader4.Width = 304;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 2;
            this.columnHeader5.Text = "Value";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 1;
            this.columnHeader6.Text = "Location";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 106;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Size = new System.Drawing.Size(531, 492);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // DevBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 584);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.textOpen);
            this.Controls.Add(this.groupCI);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "DevBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PS4 Dump Checker";
            this.groupCI.ResumeLayout(false);
            this.groupCI.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openDump;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.TextBox textMAC;
        private System.Windows.Forms.GroupBox groupCI;
        private System.Windows.Forms.Label labelSHA1;
        private System.Windows.Forms.Label labelFWV;
        private System.Windows.Forms.TextBox textSHA1;
        private System.Windows.Forms.TextBox textFWV;
        private System.Windows.Forms.Label labelSKU;
        private System.Windows.Forms.TextBox textSKU;
        private System.Windows.Forms.Label labelMAC;
        private System.Windows.Forms.TextBox textHDD;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.TextBox textOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtboxfilename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCID;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem hexViewerToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mobotextBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TORUStxtbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SKUVERtextBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox HDDSNtextBox1;
        private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
        public System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.ColumnHeader columnHeader5;
        public System.Windows.Forms.ColumnHeader columnHeader6;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TorusSoCtextBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxRegion;
        private System.Windows.Forms.ToolStripMenuItem dumpAnalysisToolStripMenuItem;
    }
}

