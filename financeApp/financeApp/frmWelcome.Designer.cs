namespace financeApp
{
    partial class frmWelcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWelcome));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlLinks = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.llblAbout = new System.Windows.Forms.LinkLabel();
            this.llblRunReports = new System.Windows.Forms.LinkLabel();
            this.llblViewProfiles = new System.Windows.Forms.LinkLabel();
            this.llblViewAccount = new System.Windows.Forms.LinkLabel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlLeft.SuspendLayout();
            this.pnlLinks.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlLinks);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(163, 333);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlLinks
            // 
            this.pnlLinks.Controls.Add(this.label1);
            this.pnlLinks.Controls.Add(this.llblAbout);
            this.pnlLinks.Controls.Add(this.llblRunReports);
            this.pnlLinks.Controls.Add(this.llblViewProfiles);
            this.pnlLinks.Controls.Add(this.llblViewAccount);
            this.pnlLinks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLinks.Location = new System.Drawing.Point(0, 146);
            this.pnlLinks.Name = "pnlLinks";
            this.pnlLinks.Size = new System.Drawing.Size(163, 187);
            this.pnlLinks.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quick Links";
            // 
            // llblAbout
            // 
            this.llblAbout.AutoSize = true;
            this.llblAbout.Location = new System.Drawing.Point(12, 107);
            this.llblAbout.Name = "llblAbout";
            this.llblAbout.Size = new System.Drawing.Size(82, 13);
            this.llblAbout.TabIndex = 3;
            this.llblAbout.TabStop = true;
            this.llblAbout.Text = "View About Info";
            this.llblAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblAbout_LinkClicked);
            // 
            // llblRunReports
            // 
            this.llblRunReports.AutoSize = true;
            this.llblRunReports.Location = new System.Drawing.Point(11, 84);
            this.llblRunReports.Name = "llblRunReports";
            this.llblRunReports.Size = new System.Drawing.Size(67, 13);
            this.llblRunReports.TabIndex = 2;
            this.llblRunReports.TabStop = true;
            this.llblRunReports.Text = "Run Reports";
            this.llblRunReports.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRunReports_LinkClicked);
            // 
            // llblViewProfiles
            // 
            this.llblViewProfiles.AutoSize = true;
            this.llblViewProfiles.Location = new System.Drawing.Point(11, 61);
            this.llblViewProfiles.Name = "llblViewProfiles";
            this.llblViewProfiles.Size = new System.Drawing.Size(122, 13);
            this.llblViewProfiles.TabIndex = 1;
            this.llblViewProfiles.TabStop = true;
            this.llblViewProfiles.Text = "Add Profiles/Cash Flows";
            this.llblViewProfiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblViewProfiles_LinkClicked);
            // 
            // llblViewAccount
            // 
            this.llblViewAccount.AutoSize = true;
            this.llblViewAccount.Location = new System.Drawing.Point(12, 38);
            this.llblViewAccount.Name = "llblViewAccount";
            this.llblViewAccount.Size = new System.Drawing.Size(73, 13);
            this.llblViewAccount.TabIndex = 0;
            this.llblViewAccount.TabStop = true;
            this.llblViewAccount.Text = "View Account";
            this.llblViewAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblViewAccount_LinkClicked);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.label2);
            this.pnlRight.Controls.Add(this.lblHeader);
            this.pnlRight.Controls.Add(this.btnClose);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(163, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(404, 333);
            this.pnlRight.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 234);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(6, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(154, 13);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Welcome to <Application Title>";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(317, 298);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 333);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWelcome";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmWelcome";
            this.Load += new System.EventHandler(this.frmWelcome_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLinks.ResumeLayout(false);
            this.pnlLinks.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlLinks;
        private System.Windows.Forms.LinkLabel llblViewProfiles;
        private System.Windows.Forms.LinkLabel llblViewAccount;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel llblAbout;
        private System.Windows.Forms.LinkLabel llblRunReports;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}