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

            clbReportProfiles.Items.Clear();
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
                if (reportSeries.Points.Count > 0)
                {
                    chrtReportChart.Series.Add(reportSeries);
                }
            }

            if (chrtReportChart.Series.Count == 0)
            {
                chrtReportChart.Series.Add(reporting.getDummySeries());
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
            if (validateReportBounds(tstbLowerBound.Text, tstbUpperBound.Text))
            {
                chrtReportChart.Series.Clear();
                runReport(getSelectedProfiles(),
                    DateTime.Parse(tstbLowerBound.Text),
                    DateTime.Parse(tstbUpperBound.Text),
                    getReportTypeByName(tscbReportType.Text));
            }
            else
            {
                using (frmMessageBox messageBox = new frmMessageBox())
                {
                    common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
                    common.getMainForm().loadedTheme.themeForm(messageBox);
                    messageBox.show("Upper and Lower bounds MUST be dates and the\r\n" +
                        "Lower Bound must be EARLIER than the Upper Bound.",
                        "Invalid Report Bounds!", MessageBoxButtons.OK);
                }
            }

        }

        /// <summary>
        /// Validates the boundaries of the report data.
        /// The report has valid bounds if 
        /// the upper and lower bounds are both dates, and the
        /// lower bound is not chronologically after the upper bound
        /// </summary>
        /// <param name="lowerBound"></param>
        /// <param name="upperBound"></param>
        /// <returns></returns>
        private bool validateReportBounds(string lowerBound, string upperBound)
        {
            if (!common.isDate(lowerBound) || !common.isDate(upperBound)
                || DateTime.Parse(upperBound) < DateTime.Parse(lowerBound))
            {
                return false;
            }
            else
            {
                return true;
            }
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
