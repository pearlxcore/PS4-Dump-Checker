namespace PS4_NOR_Dump_Checker
{
    partial class Hex_Viewer
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
            this.HEXtextBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // HEXtextBox1
            // 
            this.HEXtextBox1.Location = new System.Drawing.Point(74, 61);
            this.HEXtextBox1.Name = "HEXtextBox1";
            this.HEXtextBox1.Size = new System.Drawing.Size(100, 20);
            this.HEXtextBox1.TabIndex = 0;
            this.HEXtextBox1.Visible = false;
            // 
            // Hex_Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(634, 536);
            this.Controls.Add(this.HEXtextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Hex_Viewer";
            this.Text = "Hex Viewer";
            this.Load += new System.EventHandler(this.Hex_Viewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox HEXtextBox1;
    }
}