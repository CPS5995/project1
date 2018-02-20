namespace financeApp
{
    partial class frmReporting
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chrtReportChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.clbReportProfiles = new System.Windows.Forms.CheckedListBox();
            this.msMenuStrip = new System.Windows.Forms.MenuStrip();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlReportPanel = new System.Windows.Forms.Panel();
            this.ssReportStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslReportInfo = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chrtReportChart)).BeginInit();
            this.msMenuStrip.SuspendLayout();
            this.pnlReportPanel.SuspendLayout();
            this.ssReportStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // chrtReportChart
            // 
            chartArea1.Name = "ChartArea1";
            this.chrtReportChart.ChartAreas.Add(chartArea1);
            this.chrtReportChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chrtReportChart.Legends.Add(legend1);
            this.chrtReportChart.Location = new System.Drawing.Point(0, 0);
            this.chrtReportChart.Name = "chrtReportChart";
            this.chrtReportChart.Size = new System.Drawing.Size(441, 350);
            this.chrtReportChart.TabIndex = 0;
            this.chrtReportChart.Text = "chart1";
            // 
            // clbReportProfiles
            // 
            this.clbReportProfiles.CheckOnClick = true;
            this.clbReportProfiles.Dock = System.Windows.Forms.DockStyle.Right;
            this.clbReportProfiles.FormattingEnabled = true;
            this.clbReportProfiles.Location = new System.Drawing.Point(441, 24);
            this.clbReportProfiles.Name = "clbReportProfiles";
            this.clbReportProfiles.Size = new System.Drawing.Size(172, 350);
            this.clbReportProfiles.Sorted = true;
            this.clbReportProfiles.TabIndex = 2;
            // 
            // msMenuStrip
            // 
            this.msMenuStrip.AllowMerge = false;
            this.msMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportToolStripMenuItem,
            this.filtersToolStripMenuItem});
            this.msMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.msMenuStrip.Name = "msMenuStrip";
            this.msMenuStrip.Size = new System.Drawing.Size(613, 24);
            this.msMenuStrip.TabIndex = 3;
            this.msMenuStrip.Text = "menuStrip1";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runReportToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // runReportToolStripMenuItem
            // 
            this.runReportToolStripMenuItem.Name = "runReportToolStripMenuItem";
            this.runReportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.runReportToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.runReportToolStripMenuItem.Text = "Run Report";
            this.runReportToolStripMenuItem.Click += new System.EventHandler(this.runReportToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // pnlReportPanel
            // 
            this.pnlReportPanel.Controls.Add(this.chrtReportChart);
            this.pnlReportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReportPanel.Location = new System.Drawing.Point(0, 24);
            this.pnlReportPanel.Name = "pnlReportPanel";
            this.pnlReportPanel.Size = new System.Drawing.Size(441, 350);
            this.pnlReportPanel.TabIndex = 4;
            // 
            // ssReportStatusStrip
            // 
            this.ssReportStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslReportInfo});
            this.ssReportStatusStrip.Location = new System.Drawing.Point(0, 374);
            this.ssReportStatusStrip.Name = "ssReportStatusStrip";
            this.ssReportStatusStrip.Size = new System.Drawing.Size(613, 22);
            this.ssReportStatusStrip.TabIndex = 1;
            this.ssReportStatusStrip.Text = "statusStrip1";
            // 
            // tsslReportInfo
            // 
            this.tsslReportInfo.Name = "tsslReportInfo";
            this.tsslReportInfo.Size = new System.Drawing.Size(46, 17);
            this.tsslReportInfo.Text = "[status]";
            // 
            // frmReporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 396);
            this.Controls.Add(this.pnlReportPanel);
            this.Controls.Add(this.clbReportProfiles);
            this.Controls.Add(this.ssReportStatusStrip);
            this.Controls.Add(this.msMenuStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReporting";
            this.ShowInTaskbar = false;
            this.Text = "frmReporting";
            this.Load += new System.EventHandler(this.frmReporting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chrtReportChart)).EndInit();
            this.msMenuStrip.ResumeLayout(false);
            this.msMenuStrip.PerformLayout();
            this.pnlReportPanel.ResumeLayout(false);
            this.ssReportStatusStrip.ResumeLayout(false);
            this.ssReportStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chrtReportChart;
        private System.Windows.Forms.CheckedListBox clbReportProfiles;
        private System.Windows.Forms.MenuStrip msMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runReportToolStripMenuItem;
        private System.Windows.Forms.Panel pnlReportPanel;
        private System.Windows.Forms.StatusStrip ssReportStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslReportInfo;
    }
}