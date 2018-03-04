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
        return date.AddDays(-1 * dateDiff).Date;
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
        return date.AddDays(-1 * dateDiff).Date;
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

    /// <summary>
    /// returns a boolean indicating if the passed value is a date
    /// </summary>
    /// <param name="dateString"></param>
    /// <returns></returns>
    public static bool isDate(string dateString)
    {
        DateTime temp;
        if (DateTime.TryParse(dateString, out temp))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Gets the active instance of "frmMain".
    /// </summary>
    /// <returns></returns>
    public static financeApp.frmMain getMainForm()
    {
        return (financeApp.frmMain)System.Windows.Forms.Application.OpenForms["frmMain"];
    }

    /// <summary>
    /// Closes all MDI Children for the passed Form.
    /// Done by calling .Close() on all the children.
    /// </summary>
    /// <param name="parentForm"></param>
    public static void closeAllMdiChildForms(System.Windows.Forms.Form parentForm)
    {
        foreach (System.Windows.Forms.Form childForm in parentForm.MdiChildren)
        {
            childForm.Close();
        }
    }

    /*<begin DB stuff>*/
    /* TODO: still needs to do the database stuff and whatever */

    public static int getNextAccountId()
    {
        return 1; //placeholder
    }

    public static int getNextProfileId()
    {
        return getNextProfileId(getMainForm().loadedAccount); //placeholder
    }

    public static int getNextProfileId(userAccount accountToGetNextFrom)
    {
        //placeholder function, don't use in "Prod"
        return accountToGetNextFrom.profiles.Max(x => x.id) + 1;
    }

    public static void addProfileToAccount(userAccount accountToAddProfile, fundingProfile profileToAdd)
    {
        accountToAddProfile.profiles.Add(profileToAdd);
    }

    public static void updateProfileOnAccount(userAccount owningAccount, fundingProfile oldProfile, fundingProfile updatedProfile)
    {
        //TODO
    }

    public static void deleteProfileFromAccount(userAccount owningAccount, fundingProfile profileToDelete)
    {
        owningAccount.profiles.Remove(profileToDelete);
    }

    public static int getNextCashFlowId()
    {
        return getNextCashFlowId(getMainForm().loadedAccount); //placeholder
    }

    public static int getNextCashFlowId(userAccount accountToGetNextFrom)
    {
        //placeholder function, don't use in "Prod"
        return accountToGetNextFrom.getAccountCashFlows().Max(x => x.id) + 1;
    }

    public static void addCashFlowToProfile(fundingProfile profileToRecieveFlow, cashFlow flowToAdd)
    {
        profileToRecieveFlow.cashFlows.Add(flowToAdd);
    }

    public static void updateCashFlowOnAccount(fundingProfile owningProfile, cashFlow oldFlow, cashFlow updatedFlow)
    {
        //TODO
    }

    public static void deleteCashFlowFromProfile(fundingProfile owningProfile, cashFlow flowToDelete)
    {
        owningProfile.cashFlows.Remove(flowToDelete);
    }

    /*</end DB stuff>*/

}

