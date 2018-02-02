using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Class for holding the user's login/account info
/// all of a user's profiles should be associated with their account.
/// </summary>
    public class userAccount
    {

    public string name { get; set; }
    public List<fundingProfile> profiles = new List<fundingProfile>();

    //Default constructor
    public userAccount() { }



    /// <summary>
    /// Returns a list of all Overdue cash flows associated with this account
    /// </summary>
    /// <returns></returns>
    public List<cashFlow> getOverdueFlows()
    {
        return this.getAccountCashFlows().Where(x => x.isOverDue()).ToList();
    }

    /// <summary>
    /// Returns a list of ALL cashflows associated with this account
    /// </summary>
    /// <returns></returns>
    public List<cashFlow> getAccountCashFlows()
    {
        List<cashFlow> tempFlows = new List<cashFlow>();

        foreach (fundingProfile profile in this.profiles)
        {
            tempFlows.AddRange(profile.cashFlows);
        }

        return tempFlows;

    }

}
