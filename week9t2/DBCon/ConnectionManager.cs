using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DBCon
{
    public class ConnectionManager
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["week9t1"].ConnectionString;
        private static readonly string dsdssds = ConfigurationManager.AppSettings["ConnectionString"];

        private static ConnectionManager con;
        private static SqlConnection _sqlConnection;

        public SqlConnection SqlConnetionFactory
        {
            get
            {
                return _sqlConnection;
            }
        }

        private ConnectionManager() { }

        public static ConnectionManager GetConnection
        {
            get
            {
                if (con == null)
                    con = new ConnectionManager();
                try
                {
                    _sqlConnection = new SqlConnection(connectionString);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                return con;
            }
        }
    }
}
