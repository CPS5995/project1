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
    /// returns a boolean indicating if the passed value is a number
    /// </summary>
    /// <param name="numberString"></param>
    /// <returns></returns>
    public static bool isNumeric(string numberString)
    {
        double temp;
        if (double.TryParse(numberString, out temp))
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

    /// <summary>
    /// Replaces an item in a list with a new item
    /// </summary>
    /// <param name="parentList"></param>
    /// <param name="itemToReplace"></param>
    /// <param name="newItem"></param>
    public static void replaceItemInList(List<cashFlow> parentList, cashFlow itemToReplace, cashFlow newItem)
    {
        int index = parentList.IndexOf(itemToReplace);

        if (index != -1)
        {
            parentList[index] = newItem;
        }
    }

    /// <summary>
    /// Replaces an item in a list with a new item
    /// [This is the overload for fundingProfiles]
    /// </summary>
    /// <param name="parentList"></param>
    /// <param name="itemToReplace"></param>
    /// <param name="newItem"></param>
    public static void replaceItemInList(List<fundingProfile> parentList, fundingProfile itemToReplace, fundingProfile newItem)
    {
        int index = parentList.IndexOf(itemToReplace);

        if (index != -1)
        {
            parentList[index] = newItem;
        }
    }

    /*<begin DB stuff>*/
    /* TODO: still needs to do the database stuff and whatever */

    /*User Accounts*/
    public static int getNextAccountId()
    {
        return 1; //placeholder
    }

    public static void createNewAccount(userAccount accountToCreate)
    {
        //TODO
    }

    public static void updateAccount(userAccount oldAccount, userAccount updatedAccount)
    {
        //TODO
    }

    public static void deleteAccount(userAccount accountToDelete)
    {
        //TODO
    }

    /*Funding Profiles*/
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
        //Database stuff
        database.sqlStatement insertSql = new database.sqlStatement();
        insertSql.connectionString = database.getConnectString();

        insertSql.query = "INSERT INTO bmw_funding_profile " +
                          "(account_id,profile_name) " +
                          "VALUES " +
                          "(@account_id, @profile_name) ";

        insertSql.queryParameters.Add("@account_id", accountToAddProfile.id);
        insertSql.queryParameters.Add("@profile_name", profileToAdd.name);

        database.executeNonQueryOnDatabase(insertSql);
    }

    public static void updateProfileOnAccount(userAccount owningAccount, fundingProfile oldProfile, fundingProfile updatedProfile)
    {
        replaceItemInList(owningAccount.profiles, oldProfile, updatedProfile);
        //Database stuff
        database.sqlStatement updateSql = new database.sqlStatement();
        updateSql.connectionString = database.getConnectString();

        updateSql.query = "UPDATE bmw_funding_profile " +
                          "SET profile_name = @profile_name " +
                          "WHERE id = @id ";

        updateSql.queryParameters.Add("@id", oldProfile.id);
        updateSql.queryParameters.Add("@profile_name", updatedProfile.name);

        database.executeNonQueryOnDatabase(updateSql);
    }

    public static void deleteProfileFromAccount(userAccount owningAccount, fundingProfile profileToDelete)
    {
        owningAccount.profiles.Remove(profileToDelete);
        
        //Database stuff
        database.sqlStatement deleteSql = new database.sqlStatement();
        deleteSql.connectionString = database.getConnectString();

        /* Delete the Child Cash Flows */
        deleteSql.query = "DELETE FROM bmw_cash_flow " +
                          "WHERE profile_id = @profile_id ";

        deleteSql.queryParameters.Add("@profile_id", profileToDelete.id);

        database.executeNonQueryOnDatabase(deleteSql);
        deleteSql.queryParameters.Clear();

        /* Delete the Profile */
        deleteSql.query = "DELETE FROM bmw_funding_profile " +
                          "WHERE id = @id ";

        deleteSql.queryParameters.Add("@id", profileToDelete.id);
        
        database.executeNonQueryOnDatabase(deleteSql);
        
    }

    /*Cash Flows*/
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
        //Database stuff
        database.sqlStatement insertSql = new database.sqlStatement();
        insertSql.connectionString = database.getConnectString();

        insertSql.query = "INSERT INTO bmw_cash_flow " +
                          "(profile_id,flow_name,flow_type,amount,transaction_date,due_date) " +
                          "VALUES " +
                          "(@profile_id,@flow_name,@flow_type,@amount,@transaction_date,@due_date) ";

        insertSql.queryParameters.Add("@profile_id", profileToRecieveFlow.id);
        insertSql.queryParameters.Add("@flow_name", flowToAdd.name);
        insertSql.queryParameters.Add("@flow_type", flowToAdd.flowType);
        insertSql.queryParameters.Add("@amount", flowToAdd.amount);
        insertSql.queryParameters.Add("@transaction_date", flowToAdd.flowDate);
        insertSql.queryParameters.Add("@due_date", flowToAdd.dueDate);

        database.executeNonQueryOnDatabase(insertSql);
    }

    public static void updateCashFlowOnAccount(fundingProfile owningProfile, cashFlow oldFlow, cashFlow updatedFlow)
    {
        replaceItemInList(owningProfile.cashFlows, oldFlow, updatedFlow);
        //Database stuff
        database.sqlStatement updateSql = new database.sqlStatement();
        updateSql.connectionString = database.getConnectString();

        updateSql.query = "UPDATE bmw_cash_flow " +
                          "SET flow_name = @flow_name, " +
                          "flow_type = @flow_type, " +
                          "amount = @amount, " +
                          "transaction_date = @transaction_date, " +
                          "due_date = @due_date " +
                          "WHERE id = @id ";

        updateSql.queryParameters.Add("@id", oldFlow.id);
        updateSql.queryParameters.Add("@flow_name", updatedFlow.name);
        updateSql.queryParameters.Add("@flow_type", updatedFlow.flowType);
        updateSql.queryParameters.Add("@amount", updatedFlow.amount);
        updateSql.queryParameters.Add("@transaction_date", updatedFlow.flowDate);
        updateSql.queryParameters.Add("@due_date", updatedFlow.dueDate);

        database.executeNonQueryOnDatabase(updateSql);
    }

    public static void deleteCashFlowFromProfile(fundingProfile owningProfile, cashFlow flowToDelete)
    {
        owningProfile.cashFlows.Remove(flowToDelete);
        //Database stuff
        database.sqlStatement deleteSql = new database.sqlStatement();
        deleteSql.connectionString = database.getConnectString();

        deleteSql.query = "DELETE FROM bmw_cash_flow " +
                          "WHERE id = @id ";

        deleteSql.queryParameters.Add("@id", flowToDelete.id);

        database.executeNonQueryOnDatabase(deleteSql);
    }

    /*</end DB stuff>*/


    /// <summary>
    /// 
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public static userAccount getAccountFromDatabase(int accountId)
    {
        database.sqlStatement sql = new database.sqlStatement();
        sql.connectionString = database.getConnectString();

        sql.query = "SELECT ua.id, ua.username " +
                    "FROM bmw_user_account ua " +
                    "WHERE ua.id = @account_id ";

        sql.queryParameters.Add("@account_id", accountId);


        foreach (System.Data.DataRow row in database.selectFromDatabase(sql).Rows)
        {
            return new userAccount(int.Parse(row["id"].ToString()),
                row["username"].ToString(),
                getProfilesForAccount(int.Parse(row["id"].ToString())));
        }

        return null;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public static List<fundingProfile> getProfilesForAccount(int accountId)
    {
        database.sqlStatement sql = new database.sqlStatement();
        sql.connectionString = database.getConnectString();

        sql.query = "SELECT fp.id, fp.profile_name " +
                    "FROM bmw_funding_profile fp " +
                    "WHERE fp.account_id = @account_id ";

        sql.queryParameters.Add("@account_id", accountId);

        List<fundingProfile> profiles = new List<fundingProfile>();

        foreach (System.Data.DataRow row in database.selectFromDatabase(sql).Rows)
        {
            profiles.Add(new fundingProfile(int.Parse(row["id"].ToString()),
                row["profile_name"].ToString(), getCashFlowsForProfile(int.Parse(row["id"].ToString()))));
        }

        return profiles;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="profileId"></param>
    /// <returns></returns>
    public static List<cashFlow> getCashFlowsForProfile(int profileId)
    {
        database.sqlStatement sql = new database.sqlStatement();
        sql.connectionString = database.getConnectString();

        sql.query = "SELECT cf.id, cf.flow_name, cf.flow_type, " +
                    "cf.amount, cf.transaction_date, cf.due_date " +
                    "FROM bmw_cash_flow cf " +
                    "WHERE cf.profile_id = @profile_id ";

        sql.queryParameters.Add("@profile_id", profileId);

        List<cashFlow> cashFlows = new List<cashFlow>();

        foreach (System.Data.DataRow row in database.selectFromDatabase(sql).Rows)
        {
            DateTime? dueDate;

            if (string.IsNullOrEmpty(row["due_date"].ToString()))
            {
                dueDate = null;
            }
            else
            {
                dueDate = DateTime.Parse(row["due_date"].ToString());
            }

            cashFlows.Add(new cashFlow(int.Parse(row["id"].ToString()),
                row["flow_name"].ToString(),
                double.Parse(row["amount"].ToString()),
                dueDate,
                DateTime.Parse(row["transaction_date"].ToString()),
                cashFlowType.income));
        }

        return cashFlows;

    }

}

