using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

    public static class reporting
    {

    /// <summary>
    /// Generates a Weekly summation series for the passed cashflows 
    /// </summary>
    /// <param name="dataToReport"></param>
    /// <param name="seriesName"></param>
    /// <param name="chartType"></param>
    /// <returns></returns>
    public static Series getWeeklySummationSeries(List<cashFlow> dataToReport, string seriesName, SeriesChartType chartType)
    {
        Series outputSeries = new Series(seriesName);
        outputSeries.ChartType = chartType;

        foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList())
        {
            outputSeries.Points.AddXY(day.ToString(), dataToReport.Where(x => x.flowDate.DayOfWeek == day).Sum(x => x.amount));
        }
        
        return outputSeries;    
    }

}
