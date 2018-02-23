namespace financeApp
{
    partial class frmAccountDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.ssAccountViewStatus = new System.Windows.Forms.StatusStrip();
            this.tsslAccountStats = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbProfiles = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.msAccountDetails = new System.Windows.Forms.MenuStrip();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssAccountViewStatus.SuspendLayout();
            this.msAccountDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Name:";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(99, 26);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(184, 20);
            this.txtAccountName.TabIndex = 1;
            // 
            // ssAccountViewStatus
            // 
            this.ssAccountViewStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslAccountStats});
            this.ssAccountViewStatus.Location = new System.Drawing.Point(0, 305);
            this.ssAccountViewStatus.Name = "ssAccountViewStatus";
            this.ssAccountViewStatus.Size = new System.Drawing.Size(481, 22);
            this.ssAccountViewStatus.TabIndex = 4;
            this.ssAccountViewStatus.Text = "statusStrip1";
            // 
            // tsslAccountStats
            // 
            this.tsslAccountStats.Name = "tsslAccountStats";
            this.tsslAccountStats.Size = new System.Drawing.Size(118, 17);
            this.tsslAccountStats.Text = "toolStripStatusLabel1";
            // 
            // lbProfiles
            // 
            this.lbProfiles.FormattingEnabled = true;
            this.lbProfiles.Location = new System.Drawing.Point(15, 207);
            this.lbProfiles.Name = "lbProfiles";
            this.lbProfiles.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbProfiles.Size = new System.Drawing.Size(268, 95);
            this.lbProfiles.Sorted = true;
            this.lbProfiles.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Profiles:";
            // 
            // msAccountDetails
            // 
            this.msAccountDetails.AllowMerge = false;
            this.msAccountDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem});
            this.msAccountDetails.Location = new System.Drawing.Point(0, 0);
            this.msAccountDetails.Name = "msAccountDetails";
            this.msAccountDetails.Size = new System.Drawing.Size(481, 24);
            this.msAccountDetails.TabIndex = 7;
            this.msAccountDetails.Text = "menuStrip1";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewProfileToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // addNewProfileToolStripMenuItem
            // 
            this.addNewProfileToolStripMenuItem.Name = "addNewProfileToolStripMenuItem";
            this.addNewProfileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addNewProfileToolStripMenuItem.Text = "Add New Profile";
            this.addNewProfileToolStripMenuItem.Click += new System.EventHandler(this.addNewProfileToolStripMenuItem_Click);
            // 
            // frmAccountDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 327);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbProfiles);
            this.Controls.Add(this.ssAccountViewStatus);
            this.Controls.Add(this.msAccountDetails);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msAccountDetails;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAccountDetails";
            this.ShowInTaskbar = false;
            this.Text = "frmAccountDetails";
            this.Load += new System.EventHandler(this.frmAccountDetails_Load);
            this.ssAccountViewStatus.ResumeLayout(false);
            this.ssAccountViewStatus.PerformLayout();
            this.msAccountDetails.ResumeLayout(false);
            this.msAccountDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.StatusStrip ssAccountViewStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslAccountStats;
        private System.Windows.Forms.ListBox lbProfiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip msAccountDetails;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewProfileToolStripMenuItem;
    }
}