namespace financeApp
{
    partial class frmProfileDetails
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssProfileViewStatus = new System.Windows.Forms.StatusStrip();
            this.tsslProfileDetailStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.ssProfileViewStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(577, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "msProfileDetails";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.profileToolStripMenuItem.Text = "Profile";
            // 
            // ssProfileViewStatus
            // 
            this.ssProfileViewStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslProfileDetailStatus});
            this.ssProfileViewStatus.Location = new System.Drawing.Point(0, 338);
            this.ssProfileViewStatus.Name = "ssProfileViewStatus";
            this.ssProfileViewStatus.Size = new System.Drawing.Size(577, 22);
            this.ssProfileViewStatus.TabIndex = 1;
            this.ssProfileViewStatus.Text = "statusStrip1";
            // 
            // tsslProfileDetailStatus
            // 
            this.tsslProfileDetailStatus.Name = "tsslProfileDetailStatus";
            this.tsslProfileDetailStatus.Size = new System.Drawing.Size(46, 17);
            this.tsslProfileDetailStatus.Text = "[status]";
            // 
            // frmProfileDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 360);
            this.Controls.Add(this.ssProfileViewStatus);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProfileDetails";
            this.Text = "frmProfileDetails";
            this.Load += new System.EventHandler(this.frmProfileDetails_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ssProfileViewStatus.ResumeLayout(false);
            this.ssProfileViewStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip ssProfileViewStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslProfileDetailStatus;
    }
}