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
            this.msProfileDetails = new System.Windows.Forms.MenuStrip();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameSelectedProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCashFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEditSelectedCashFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedCashFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssProfileViewStatus = new System.Windows.Forms.StatusStrip();
            this.tsslProfileDetailStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlProfiles = new System.Windows.Forms.Panel();
            this.lbProfiles = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProfiles = new System.Windows.Forms.Label();
            this.pnlCashFlows = new System.Windows.Forms.Panel();
            this.lbCashFlows = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCashFlows = new System.Windows.Forms.Label();
            this.importCashFlowsFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msProfileDetails.SuspendLayout();
            this.ssProfileViewStatus.SuspendLayout();
            this.pnlProfiles.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlCashFlows.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // msProfileDetails
            // 
            this.msProfileDetails.AllowMerge = false;
            this.msProfileDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem,
            this.cashFlowToolStripMenuItem});
            this.msProfileDetails.Location = new System.Drawing.Point(0, 0);
            this.msProfileDetails.Name = "msProfileDetails";
            this.msProfileDetails.Size = new System.Drawing.Size(577, 24);
            this.msProfileDetails.TabIndex = 0;
            this.msProfileDetails.Text = "msProfileDetails";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewProfileToolStripMenuItem,
            this.renameSelectedProfileToolStripMenuItem,
            this.deleteSelectedProfileToolStripMenuItem});
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.profileToolStripMenuItem.Text = "Profile";
            // 
            // addNewProfileToolStripMenuItem
            // 
            this.addNewProfileToolStripMenuItem.Name = "addNewProfileToolStripMenuItem";
            this.addNewProfileToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.addNewProfileToolStripMenuItem.Text = "Add New Profile";
            this.addNewProfileToolStripMenuItem.Click += new System.EventHandler(this.addNewProfileToolStripMenuItem_Click);
            // 
            // renameSelectedProfileToolStripMenuItem
            // 
            this.renameSelectedProfileToolStripMenuItem.Name = "renameSelectedProfileToolStripMenuItem";
            this.renameSelectedProfileToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.renameSelectedProfileToolStripMenuItem.Text = "Rename Selected Profile";
            this.renameSelectedProfileToolStripMenuItem.Click += new System.EventHandler(this.renameSelectedProfileToolStripMenuItem_Click);
            // 
            // deleteSelectedProfileToolStripMenuItem
            // 
            this.deleteSelectedProfileToolStripMenuItem.Name = "deleteSelectedProfileToolStripMenuItem";
            this.deleteSelectedProfileToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.deleteSelectedProfileToolStripMenuItem.Text = "Delete Selected Profile";
            this.deleteSelectedProfileToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedProfileToolStripMenuItem_Click);
            // 
            // cashFlowToolStripMenuItem
            // 
            this.cashFlowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewCashFlowToolStripMenuItem,
            this.viewEditSelectedCashFlowToolStripMenuItem,
            this.deleteSelectedCashFlowToolStripMenuItem,
            this.importCashFlowsFromFileToolStripMenuItem});
            this.cashFlowToolStripMenuItem.Name = "cashFlowToolStripMenuItem";
            this.cashFlowToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.cashFlowToolStripMenuItem.Text = "Cash Flow";
            // 
            // addNewCashFlowToolStripMenuItem
            // 
            this.addNewCashFlowToolStripMenuItem.Name = "addNewCashFlowToolStripMenuItem";
            this.addNewCashFlowToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.addNewCashFlowToolStripMenuItem.Text = "Add New Cash Flow";
            this.addNewCashFlowToolStripMenuItem.Click += new System.EventHandler(this.addNewCashFlowToolStripMenuItem_Click);
            // 
            // viewEditSelectedCashFlowToolStripMenuItem
            // 
            this.viewEditSelectedCashFlowToolStripMenuItem.Name = "viewEditSelectedCashFlowToolStripMenuItem";
            this.viewEditSelectedCashFlowToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.viewEditSelectedCashFlowToolStripMenuItem.Text = "View/Edit Selected Cash Flow";
            this.viewEditSelectedCashFlowToolStripMenuItem.Click += new System.EventHandler(this.viewEditSelectedCashFlowToolStripMenuItem_Click);
            // 
            // deleteSelectedCashFlowToolStripMenuItem
            // 
            this.deleteSelectedCashFlowToolStripMenuItem.Name = "deleteSelectedCashFlowToolStripMenuItem";
            this.deleteSelectedCashFlowToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.deleteSelectedCashFlowToolStripMenuItem.Text = "Delete Selected Cash Flow";
            this.deleteSelectedCashFlowToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedCashFlowToolStripMenuItem_Click);
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
            // pnlProfiles
            // 
            this.pnlProfiles.Controls.Add(this.lbProfiles);
            this.pnlProfiles.Controls.Add(this.panel1);
            this.pnlProfiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProfiles.Location = new System.Drawing.Point(0, 24);
            this.pnlProfiles.Name = "pnlProfiles";
            this.pnlProfiles.Padding = new System.Windows.Forms.Padding(5);
            this.pnlProfiles.Size = new System.Drawing.Size(288, 314);
            this.pnlProfiles.TabIndex = 2;
            // 
            // lbProfiles
            // 
            this.lbProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbProfiles.FormattingEnabled = true;
            this.lbProfiles.Location = new System.Drawing.Point(5, 31);
            this.lbProfiles.Name = "lbProfiles";
            this.lbProfiles.Size = new System.Drawing.Size(278, 278);
            this.lbProfiles.TabIndex = 0;
            this.lbProfiles.SelectedIndexChanged += new System.EventHandler(this.lbProfiles_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblProfiles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 26);
            this.panel1.TabIndex = 1;
            // 
            // lblProfiles
            // 
            this.lblProfiles.AutoSize = true;
            this.lblProfiles.Location = new System.Drawing.Point(86, 8);
            this.lblProfiles.Name = "lblProfiles";
            this.lblProfiles.Size = new System.Drawing.Size(82, 13);
            this.lblProfiles.TabIndex = 0;
            this.lblProfiles.Text = "Funding Profiles";
            // 
            // pnlCashFlows
            // 
            this.pnlCashFlows.Controls.Add(this.lbCashFlows);
            this.pnlCashFlows.Controls.Add(this.panel2);
            this.pnlCashFlows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCashFlows.Location = new System.Drawing.Point(288, 24);
            this.pnlCashFlows.Name = "pnlCashFlows";
            this.pnlCashFlows.Padding = new System.Windows.Forms.Padding(5);
            this.pnlCashFlows.Size = new System.Drawing.Size(289, 314);
            this.pnlCashFlows.TabIndex = 3;
            // 
            // lbCashFlows
            // 
            this.lbCashFlows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCashFlows.FormattingEnabled = true;
            this.lbCashFlows.Location = new System.Drawing.Point(5, 31);
            this.lbCashFlows.Name = "lbCashFlows";
            this.lbCashFlows.Size = new System.Drawing.Size(279, 278);
            this.lbCashFlows.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblCashFlows);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 26);
            this.panel2.TabIndex = 2;
            // 
            // lblCashFlows
            // 
            this.lblCashFlows.AutoSize = true;
            this.lblCashFlows.Location = new System.Drawing.Point(105, 8);
            this.lblCashFlows.Name = "lblCashFlows";
            this.lblCashFlows.Size = new System.Drawing.Size(61, 13);
            this.lblCashFlows.TabIndex = 3;
            this.lblCashFlows.Text = "Cash Flows";
            // 
            // importCashFlowsFromFileToolStripMenuItem
            // 
            this.importCashFlowsFromFileToolStripMenuItem.Name = "importCashFlowsFromFileToolStripMenuItem";
            this.importCashFlowsFromFileToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.importCashFlowsFromFileToolStripMenuItem.Text = "Import Cash Flows From File";
            this.importCashFlowsFromFileToolStripMenuItem.Click += new System.EventHandler(this.importCashFlowsFromFileToolStripMenuItem_Click);
            // 
            // frmProfileDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 360);
            this.Controls.Add(this.pnlCashFlows);
            this.Controls.Add(this.pnlProfiles);
            this.Controls.Add(this.ssProfileViewStatus);
            this.Controls.Add(this.msProfileDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msProfileDetails;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProfileDetails";
            this.Text = "frmProfileDetails";
            this.Load += new System.EventHandler(this.frmProfileDetails_Load);
            this.msProfileDetails.ResumeLayout(false);
            this.msProfileDetails.PerformLayout();
            this.ssProfileViewStatus.ResumeLayout(false);
            this.ssProfileViewStatus.PerformLayout();
            this.pnlProfiles.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlCashFlows.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msProfileDetails;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip ssProfileViewStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslProfileDetailStatus;
        private System.Windows.Forms.Panel pnlProfiles;
        private System.Windows.Forms.ListBox lbProfiles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProfiles;
        private System.Windows.Forms.Panel pnlCashFlows;
        private System.Windows.Forms.ListBox lbCashFlows;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCashFlows;
        private System.Windows.Forms.ToolStripMenuItem cashFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameSelectedProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewCashFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedCashFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEditSelectedCashFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCashFlowsFromFileToolStripMenuItem;
    }
}