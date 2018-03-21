using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

public static class database
{
    public class sqlStatement
    {
        public string connectionString { get; set; }
        public string query { get; set; }
        public Dictionary<string, object> queryParameters = new Dictionary<string, object>();

        public sqlStatement() { }

        public sqlStatement(string connectionString, string query, Dictionary<string, object> queryParameters = null)
        {
            this.connectionString = connectionString;
            this.query = query;
            this.queryParameters = queryParameters;
        }

    }



    /// <summary>
    /// Executes a SELECT statement against the database, 
    /// and returns the result set in a data table 
    /// </summary>
    /// <param name="sqlStatement"></param>
    /// <returns></returns>
    public static DataTable selectFromDatabase(sqlStatement sqlStatement)
    {
        using (MySqlConnection databaseConnection = new MySqlConnection(sqlStatement.connectionString))
        {
            databaseConnection.Open();

            using (MySqlCommand command = new MySqlCommand(sqlStatement.query, databaseConnection))
            {
                if (sqlStatement.queryParameters != null)
                {
                    foreach (KeyValuePair<string, object> parameter in sqlStatement.queryParameters)
                    {
                        command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                    }
                }

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                {
                    using (DataTable resultSet = new DataTable())
                    {
                        dataAdapter.Fill(resultSet);
                        return resultSet;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Executes a Non Query (Update, Delete, etc...) against the database,
    /// and returns the number of rows affected
    /// </summary>
    /// <param name="sqlStatement"></param>
    /// <returns></returns>
    public static int executeNonQueryOnDatabase(sqlStatement sqlStatement)
    {
        using (MySqlConnection databaseConnection = new MySqlConnection(sqlStatement.connectionString))
        {
            databaseConnection.Open();

            using (MySqlCommand command = new MySqlCommand(sqlStatement.query, databaseConnection))
            {
                if (sqlStatement.queryParameters != null)
                {
                    foreach (KeyValuePair<string, object> parameter in sqlStatement.queryParameters)
                    {
                        command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                    }
                }

                return command.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// Executes a Scalar query against the Database,
    /// and returns the resulting value of the query
    /// </summary>
    /// <param name="sqlStatement"></param>
    /// <returns></returns>
    public static object executeScalarOnDatabase(sqlStatement sqlStatement)
    {
        using (MySqlConnection databaseConnection = new MySqlConnection(sqlStatement.connectionString))
        {
            databaseConnection.Open();

            using (MySqlCommand command = new MySqlCommand(sqlStatement.query, databaseConnection))
            {
                if (sqlStatement.queryParameters != null)
                {
                    foreach (KeyValuePair<string, object> parameter in sqlStatement.queryParameters)
                    {
                        command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                    }
                }

                return command.ExecuteScalar();
            }
        }
    }


    /// <summary>
    /// returns to connection string for connecting to the database
    /// </summary>
    /// <returns></returns>
    public static string getConnectString()
    {
        MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder();
        connString.Server = "[redacted]";
        connString.Database = "[redacted]";
        connString.UserID = "[redacted]";
        connString.Password = "[redacted]";

        return connString.ToString();
    }

}

