using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace financeApp
{
    public partial class frmReporting : Form
    {
        public frmReporting()
        {
            InitializeComponent();
        }

        private userAccount loadedAccount;

        private void frmReporting_Load(object sender, EventArgs e)
        {

            chrtReportChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chrtReportChart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chrtReportChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chrtReportChart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            
            runReport(loadedAccount.profiles);
        }

        public void loadAccountIntoForm(userAccount accountToLoad)
        {
            this.loadedAccount = accountToLoad;
            this.Text = "Reporting On: " + loadedAccount.name;

            foreach (fundingProfile profile in loadedAccount.profiles)
            {
                clbReportProfiles.Items.Add(profile.name.ToString(),true);   
            }
        }

        /// <summary>
        /// Gets a list of all of the currently selected Profiles on the form
        /// </summary>
        /// <returns></returns>
        private List<fundingProfile> getSelectedProfiles()
        {
            return loadedAccount.profiles.Where(x => clbReportProfiles.CheckedItems.Contains(x.name)).ToList();
            
        }

        private void runReport(List<fundingProfile> reportDataSet)
        {
            List<cashFlow> reportIncomeFlows = new List<cashFlow>();
            List<cashFlow> reportExpenseFlows = new List<cashFlow>();

            foreach (fundingProfile profile in reportDataSet)
            {
                //reportFlows.AddRange(profile.cashFlows);    
                reportIncomeFlows.AddRange(profile.getAllIncomeFlows());
                reportExpenseFlows.AddRange(profile.getAllExpenseFlows());
            }

            chrtReportChart.Series.Add(reporting.getWeeklySummationSeries(reportIncomeFlows, "Income", SeriesChartType.Column,Color.Green));
            chrtReportChart.Series.Add(reporting.getWeeklySummationSeries(reportExpenseFlows, "Expenses", SeriesChartType.Column,Color.Red));

            //chrtReportChart.Series.Add(reporting.getWeeklySummationSeries(reportFlows, "Report", SeriesChartType.Column));
        }



        private void runReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chrtReportChart.Series.Clear();
            runReport(getSelectedProfiles());
        }


    }
}
