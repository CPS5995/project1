using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

public static class reporting
{

    public enum reportType
    {
        weekly,
        monthly,
        yearly
    };

    /// <summary>
    /// Generates a Weekly summation series for the passed cashflows 
    /// </summary>
    /// <param name="dataToReport"></param>
    /// <param name="seriesName"></param>
    /// <param name="chartType"></param>
    /// <returns></returns>
    public static Series getWeeklySummationSeries(List<cashFlow> dataToReport, string seriesName, SeriesChartType chartType, Color displayColor)
    {
        Series outputSeries = new Series(seriesName);
        outputSeries.ChartType = chartType;
        outputSeries.Color = displayColor;

        if (dataToReport.Count() > 0)
        {
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList())
            {
                outputSeries.Points.AddXY(day.ToString(), dataToReport.Where(x => x.flowDate.DayOfWeek == day).Sum(x => x.amount));
            }
        }
        return outputSeries;
    }

    /// <summary>
    /// Generates a Monthly summation for the passed cashFlows
    /// </summary>
    /// <param name="dataToReport"></param>
    /// <param name="seriesName"></param>
    /// <param name="chartType"></param>
    /// <param name="displayColor"></param>
    /// <returns></returns>
    public static Series getMonthlySummationSeries(List<cashFlow> dataToReport, string seriesName, SeriesChartType chartType, Color displayColor)
    {
        Series outputSeries = new Series(seriesName);
        outputSeries.ChartType = chartType;
        outputSeries.Color = displayColor;

        if (dataToReport.Count() > 0)
        {
            for (int i = 1; i <= 12; i++)
            {
                outputSeries.Points.AddXY(common.getMonthName(i), dataToReport.Where(x => x.flowDate.Month == i).Sum(x => x.amount));
            }
        }

        return outputSeries;
    }

    /// <summary>
    /// Generates a Yearly summation series for the given cash flows
    /// </summary>
    /// <param name="dataToReport"></param>
    /// <param name="seriesName"></param>
    /// <param name="chartType"></param>
    /// <param name="displayColor"></param>
    /// <returns></returns>
    public static Series getYearlySummationSeries(List<cashFlow> dataToReport, string seriesName, SeriesChartType chartType, Color displayColor)
    {
        Series outputSeries = new Series(seriesName);
        outputSeries.ChartType = chartType;
        outputSeries.Color = displayColor;

        if (dataToReport.Count() > 0)
        {
            for (int i = dataToReport.Min(x => x.flowDate).Year; i <= dataToReport.Max(x => x.flowDate).Year; i++)
            {
                outputSeries.Points.AddXY(i, dataToReport.Where(x => x.flowDate.Year == i).Sum(x => x.amount));
            }
        }

        return outputSeries;
    }

    /// <summary>
    /// Returns an empty "dummy series".
    /// Useful for when there is no data to display
    /// </summary>
    /// <returns></returns>
    public static Series getDummySeries()
    {
        Series outputSeries = new Series("No Data Found");
        outputSeries.ChartType = SeriesChartType.Column;
        outputSeries.Color = Color.White;

        outputSeries.Points.AddXY("No Data Found",1);


        return outputSeries;
    }

}
