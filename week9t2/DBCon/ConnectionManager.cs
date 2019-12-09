using System.Configuration;
using System.Data.SqlClient;

namespace DBCon
{
    public class ConnectionManager
    {
        private static SqlConnection connection = null;

        private ConnectionManager() { }

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["week9t1"].ConnectionString;

                //   string connectionString2 = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;

                connection = new SqlConnection(connectionString);
                connection.Open();
            }

            return connection;
        }
    }
}
