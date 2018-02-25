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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chrtReportChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.clbReportProfiles = new System.Windows.Forms.CheckedListBox();
            this.msMenuStrip = new System.Windows.Forms.MenuStrip();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.reportTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbReportType = new System.Windows.Forms.ToolStripComboBox();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataRangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowerBoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tstbLowerBound = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.upperBoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tstbUpperBound = new System.Windows.Forms.ToolStripTextBox();
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
            chartArea3.Name = "ChartArea1";
            this.chrtReportChart.ChartAreas.Add(chartArea3);
            this.chrtReportChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chrtReportChart.Legends.Add(legend3);
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
            this.runReportToolStripMenuItem,
            this.toolStripSeparator2,
            this.reportTypeToolStripMenuItem});
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // reportTypeToolStripMenuItem
            // 
            this.reportTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbReportType});
            this.reportTypeToolStripMenuItem.Name = "reportTypeToolStripMenuItem";
            this.reportTypeToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.reportTypeToolStripMenuItem.Text = "Report Type";
            // 
            // tscbReportType
            // 
            this.tscbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbReportType.Name = "tscbReportType";
            this.tscbReportType.Size = new System.Drawing.Size(121, 23);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataRangeToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // dataRangeToolStripMenuItem
            // 
            this.dataRangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lowerBoundToolStripMenuItem,
            this.tstbLowerBound,
            this.toolStripSeparator1,
            this.upperBoundToolStripMenuItem,
            this.tstbUpperBound});
            this.dataRangeToolStripMenuItem.Name = "dataRangeToolStripMenuItem";
            this.dataRangeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dataRangeToolStripMenuItem.Text = "Data Range";
            // 
            // lowerBoundToolStripMenuItem
            // 
            this.lowerBoundToolStripMenuItem.Enabled = false;
            this.lowerBoundToolStripMenuItem.Name = "lowerBoundToolStripMenuItem";
            this.lowerBoundToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.lowerBoundToolStripMenuItem.Text = "Lower Bound";
            // 
            // tstbLowerBound
            // 
            this.tstbLowerBound.Name = "tstbLowerBound";
            this.tstbLowerBound.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // upperBoundToolStripMenuItem
            // 
            this.upperBoundToolStripMenuItem.Enabled = false;
            this.upperBoundToolStripMenuItem.Name = "upperBoundToolStripMenuItem";
            this.upperBoundToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.upperBoundToolStripMenuItem.Text = "Upper Bound";
            // 
            // tstbUpperBound
            // 
            this.tstbUpperBound.Name = "tstbUpperBound";
            this.tstbUpperBound.Size = new System.Drawing.Size(100, 23);
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
        private System.Windows.Forms.ToolStripMenuItem dataRangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lowerBoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tstbLowerBound;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem upperBoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tstbUpperBound;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem reportTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tscbReportType;
    }
}