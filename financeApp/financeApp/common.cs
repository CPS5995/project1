using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class common
{

    /// <summary>
    /// Returns the FIRST day of the week for a given date.
    /// i.e. 02/22/2018 returns 02/18/2018 [Sunday]
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime getStartOfWeek(DateTime date)
    {
        int dateDiff = date.DayOfWeek - DayOfWeek.Sunday;
        return date.AddDays(-1 * dateDiff);
    }

    /// <summary>
    /// Returns the Last day of the week, for a given date
    /// i.e. 02/22/2018 returns 02/24/2018 [Saturday]
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime getEndOfWeek(DateTime date)
    {
        int dateDiff = date.DayOfWeek - DayOfWeek.Saturday;
        return date.AddDays(-1*dateDiff);
    }

    /// <summary>
    /// given a set of cashflows and a date range (with INCLUSIVE bounds),
    /// returns all dates from the given flow set that are within that range
    /// </summary>
    /// <param name="flowsToSearch"></param>
    /// <param name="lowerBound"></param>
    /// <param name="upperBound"></param>
    /// <returns></returns>
    public static List<cashFlow> getCashFlowsWithinRange(List<cashFlow> flowsToSearch, DateTime lowerBound, DateTime upperBound)
    {
        return flowsToSearch.Where(x => x.flowDate >= lowerBound && x.flowDate <= upperBound).ToList();
    }

    /// <summary>
    /// given a month number, returns the month name associated with that number
    /// i.e. Given "3", returns "March"
    /// </summary>
    /// <param name="month"></param>
    /// <returns></returns>
    public static string getMonthName(int month)
    {
        return new DateTime(2018, month, 1).ToString("MMMMMMMMMMMMMMMM", System.Globalization.CultureInfo.InvariantCulture);
    }

}

