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
            loadReportTypeComboBox();

            chrtReportChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chrtReportChart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chrtReportChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chrtReportChart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            tstbLowerBound.Text = common.getStartOfWeek(DateTime.Now).ToShortDateString();
            tstbUpperBound.Text = common.getEndOfWeek(DateTime.Now).ToShortDateString();

            tscbReportType.SelectedIndex = 0;

            runReport(loadedAccount.profiles, common.getStartOfWeek(DateTime.Now), common.getEndOfWeek(DateTime.Now), getReportTypeByName(tscbReportType.Text));
        }

        /// <summary>
        /// takes the passed user account and "loads" it into the form.
        /// Updating the form title and profile list accordingly
        /// </summary>
        /// <param name="accountToLoad"></param>
        public void loadAccountIntoForm(userAccount accountToLoad)
        {
            this.loadedAccount = accountToLoad;
            this.Text = "Reporting On: " + loadedAccount.name;

            foreach (fundingProfile profile in loadedAccount.profiles)
            {
                clbReportProfiles.Items.Add(profile.name.ToString(), true);
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

        private void runReport(List<fundingProfile> reportDataSet, DateTime reportLowerBound, DateTime reportUpperBound, reporting.reportType reportType)
        {

            foreach (Series reportSeries in getReportSeries(reportDataSet, reportLowerBound, reportUpperBound, reportType))
            {
                chrtReportChart.Series.Add(reportSeries);
            }


            tsslReportInfo.Text = getReportStatus(reportDataSet, reportLowerBound, reportUpperBound, reportType);
        }


        private string getReportStatus(List<fundingProfile> reportDataSet, DateTime reportLowerBound, DateTime reportUpperBound, reporting.reportType reportType)
        {

            List<cashFlow> reportFlows = new List<cashFlow>();

            foreach (fundingProfile profile in reportDataSet)
            {
                reportFlows.AddRange(profile.cashFlows);
            }

            return "Showing: [" + common.getCashFlowsWithinRange(reportFlows, reportLowerBound, reportUpperBound).Count()
                + "] of [" + reportFlows.Count() + "] flows | Report Bounds: " +
                reportLowerBound.ToShortDateString() + " " + reportUpperBound.ToShortDateString();
        }


        private void runReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime reportLowerBound = new DateTime();
            DateTime reportUpperBound = new DateTime();
            reporting.reportType reportType;

            reportType = getReportTypeByName(tscbReportType.Text);

            if (common.isDate(tstbLowerBound.Text))
            {
                reportLowerBound = DateTime.Parse(tstbLowerBound.Text);
            }

            if (common.isDate(tstbUpperBound.Text))
            {
                reportUpperBound = DateTime.Parse(tstbUpperBound.Text);
            }
            chrtReportChart.Series.Clear();
            runReport(getSelectedProfiles(), reportLowerBound, reportUpperBound, reportType);
        }


        private List<Series> getReportSeries(List<fundingProfile> reportDataSet, DateTime reportLowerBound, DateTime reportUpperBound, reporting.reportType reportType)
        {

            List<Series> outSeries = new List<Series>();

            List<cashFlow> reportIncomeFlows = new List<cashFlow>();
            List<cashFlow> reportExpenseFlows = new List<cashFlow>();


            foreach (fundingProfile profile in reportDataSet)
            {
                //reportFlows.AddRange(profile.cashFlows);    
                reportIncomeFlows.AddRange(common.getCashFlowsWithinRange(profile.getAllIncomeFlows(), reportLowerBound, reportUpperBound));
                reportExpenseFlows.AddRange(common.getCashFlowsWithinRange(profile.getAllExpenseFlows(), reportLowerBound, reportUpperBound));
            }

            switch (reportType)
            {
                case reporting.reportType.weekly:
                    outSeries.Add(reporting.getWeeklySummationSeries(reportIncomeFlows, "Income", SeriesChartType.Column, Color.Green));
                    outSeries.Add(reporting.getWeeklySummationSeries(reportExpenseFlows, "Expenses", SeriesChartType.Column, Color.Red));
                    break;
                case reporting.reportType.monthly:
                    outSeries.Add(reporting.getMonthlySummationSeries(reportIncomeFlows, "Income", SeriesChartType.Column, Color.Green));
                    outSeries.Add(reporting.getMonthlySummationSeries(reportExpenseFlows, "Expenses", SeriesChartType.Column, Color.Red));
                    break;
                case reporting.reportType.yearly:
                    outSeries.Add(reporting.getYearlySummationSeries(reportIncomeFlows, "Income", SeriesChartType.Column, Color.Green));
                    outSeries.Add(reporting.getYearlySummationSeries(reportExpenseFlows, "Expenses", SeriesChartType.Column, Color.Red));
                    break;
            }

            return outSeries;
        }


        /// <summary>
        ///  populates the toolstrip combo box with the values from the reportType enum
        /// </summary>
        private void loadReportTypeComboBox()
        {
            foreach (string reportType in Enum.GetNames(typeof(reporting.reportType)))
            {
                tscbReportType.Items.Add(reportType.ToString());
            }
        }


        /// <summary>
        /// Takes the STRING name of a reportType, and returns the appropriate reportType object
        /// Throws an exception if none exists
        /// </summary>
        /// <param name="reportTypeName"></param>
        /// <returns></returns>
        private reporting.reportType getReportTypeByName(string reportTypeName)
        {

            foreach (reporting.reportType reportType in Enum.GetValues(typeof(reporting.reportType)))
            {
                if (Enum.GetName(typeof(reporting.reportType), reportType) == reportTypeName)
                {
                    return reportType;
                }
            }

            throw new ArgumentException("No such ReportType Exists");
        }


    }
}
