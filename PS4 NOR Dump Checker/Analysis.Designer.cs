namespace PS4_NOR_Dump_Checker
{
    partial class Analysis
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
            this.tbPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbSpecific = new System.Windows.Forms.TextBox();
            this.tbNormalized = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOther = new System.Windows.Forms.TextBox();
            this.tb00 = new System.Windows.Forms.TextBox();
            this.tbFF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(29, 17);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(234, 20);
            this.tbPath.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 82);
            this.button1.TabIndex = 1;
            this.button1.Text = "Byte Detail";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbSpecific
            // 
            this.tbSpecific.Location = new System.Drawing.Point(51, 18);
            this.tbSpecific.Name = "tbSpecific";
            this.tbSpecific.Size = new System.Drawing.Size(212, 20);
            this.tbSpecific.TabIndex = 2;
            this.tbSpecific.Visible = false;
            // 
            // tbNormalized
            // 
            this.tbNormalized.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbNormalized.Location = new System.Drawing.Point(85, 21);
            this.tbNormalized.Name = "tbNormalized";
            this.tbNormalized.ReadOnly = true;
            this.tbNormalized.Size = new System.Drawing.Size(132, 20);
            this.tbNormalized.TabIndex = 3;
            this.tbNormalized.TabStop = false;
            this.tbNormalized.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbOther);
            this.groupBox1.Controls.Add(this.tb00);
            this.groupBox1.Controls.Add(this.tbFF);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbNormalized);
            this.groupBox1.Location = new System.Drawing.Point(30, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 133);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dump Statistics";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Other :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "00\'s :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "FF\'s :";
            // 
            // tbOther
            // 
            this.tbOther.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbOther.Location = new System.Drawing.Point(85, 100);
            this.tbOther.Name = "tbOther";
            this.tbOther.ReadOnly = true;
            this.tbOther.Size = new System.Drawing.Size(132, 20);
            this.tbOther.TabIndex = 7;
            this.tbOther.TabStop = false;
            this.tbOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb00
            // 
            this.tb00.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tb00.Location = new System.Drawing.Point(85, 74);
            this.tb00.Name = "tb00";
            this.tb00.ReadOnly = true;
            this.tb00.Size = new System.Drawing.Size(132, 20);
            this.tb00.TabIndex = 6;
            this.tb00.TabStop = false;
            this.tb00.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbFF
            // 
            this.tbFF.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbFF.Location = new System.Drawing.Point(85, 48);
            this.tbFF.Name = "tbFF";
            this.tbFF.ReadOnly = true;
            this.tbFF.Size = new System.Drawing.Size(132, 20);
            this.tbFF.TabIndex = 5;
            this.tbFF.TabStop = false;
            this.tbFF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Entropy :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(269, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 73);
            this.button2.TabIndex = 5;
            this.button2.Text = "Analyze Dump";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 199);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbSpecific);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Analysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dump Analysis";
            this.Load += new System.EventHandler(this.Analysis_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbSpecific;
        private System.Windows.Forms.TextBox tbNormalized;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOther;
        private System.Windows.Forms.TextBox tb00;
        private System.Windows.Forms.TextBox tbFF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}