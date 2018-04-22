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
            this.saveChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTotals = new System.Windows.Forms.Label();
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
            this.ssAccountViewStatus.Location = new System.Drawing.Point(0, 306);
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
            this.lbProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.accountToolStripMenuItem,
            this.profilesToolStripMenuItem});
            this.msAccountDetails.Location = new System.Drawing.Point(0, 0);
            this.msAccountDetails.Name = "msAccountDetails";
            this.msAccountDetails.Size = new System.Drawing.Size(481, 24);
            this.msAccountDetails.TabIndex = 7;
            this.msAccountDetails.Text = "menuStrip1";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveChangesToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteAccountToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // saveChangesToolStripMenuItem
            // 
            this.saveChangesToolStripMenuItem.Name = "saveChangesToolStripMenuItem";
            this.saveChangesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveChangesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveChangesToolStripMenuItem.Text = "Save Changes";
            this.saveChangesToolStripMenuItem.Click += new System.EventHandler(this.saveChangesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // deleteAccountToolStripMenuItem
            // 
            this.deleteAccountToolStripMenuItem.Name = "deleteAccountToolStripMenuItem";
            this.deleteAccountToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.deleteAccountToolStripMenuItem.Text = "Delete Account";
            this.deleteAccountToolStripMenuItem.Click += new System.EventHandler(this.deleteAccountToolStripMenuItem_Click);
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewProfileToolStripMenuItem});
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.profilesToolStripMenuItem.Text = "Profiles";
            this.profilesToolStripMenuItem.Visible = false;
            // 
            // addNewProfileToolStripMenuItem
            // 
            this.addNewProfileToolStripMenuItem.Name = "addNewProfileToolStripMenuItem";
            this.addNewProfileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addNewProfileToolStripMenuItem.Text = "Add New Profile";
            this.addNewProfileToolStripMenuItem.Click += new System.EventHandler(this.addNewProfileToolStripMenuItem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(289, 24);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTotals
            // 
            this.lblTotals.AutoSize = true;
            this.lblTotals.Location = new System.Drawing.Point(12, 67);
            this.lblTotals.Name = "lblTotals";
            this.lblTotals.Size = new System.Drawing.Size(36, 13);
            this.lblTotals.TabIndex = 9;
            this.lblTotals.Text = "Totals";
            // 
            // frmAccountDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 328);
            this.Controls.Add(this.lblTotals);
            this.Controls.Add(this.btnSave);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveChangesToolStripMenuItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTotals;
    }
}