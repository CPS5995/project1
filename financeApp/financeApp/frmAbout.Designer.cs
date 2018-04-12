namespace financeApp
{
    partial class frmAbout
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
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblAboutText = new System.Windows.Forms.Label();
            this.llblContribute = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Location = new System.Drawing.Point(77, 9);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(90, 13);
            this.lblApplicationName.TabIndex = 0;
            this.lblApplicationName.Text = "Application Name";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(86, 28);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(72, 13);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version: 1.0.0";
            // 
            // lblAboutText
            // 
            this.lblAboutText.AutoSize = true;
            this.lblAboutText.Location = new System.Drawing.Point(29, 60);
            this.lblAboutText.Name = "lblAboutText";
            this.lblAboutText.Size = new System.Drawing.Size(194, 13);
            this.lblAboutText.TabIndex = 2;
            this.lblAboutText.Text = "Created for KEAN University, CPS 5995";
            // 
            // llblContribute
            // 
            this.llblContribute.AutoSize = true;
            this.llblContribute.LinkArea = new System.Windows.Forms.LinkArea(0, 10);
            this.llblContribute.Location = new System.Drawing.Point(37, 109);
            this.llblContribute.Name = "llblContribute";
            this.llblContribute.Size = new System.Drawing.Size(182, 17);
            this.llblContribute.TabIndex = 3;
            this.llblContribute.TabStop = true;
            this.llblContribute.Text = "Contribute to the project on GitHub!";
            this.llblContribute.UseCompatibleTextRendering = true;
            this.llblContribute.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblContribute_LinkClicked);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 132);
            this.Controls.Add(this.llblContribute);
            this.Controls.Add(this.lblAboutText);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblApplicationName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAbout";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblAboutText;
        private System.Windows.Forms.LinkLabel llblContribute;
    }
}