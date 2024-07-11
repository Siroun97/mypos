using System;
using System.Data.SqlClient;

namespace SimplePOS
{
    public class databaseManager
    {
        private readonly string connectionString;

        public databaseManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public void OpenConnection(SqlConnection connection)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening connection: " + ex.Message);
            }
        }

        public void CloseConnection(SqlConnection connection)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing connection: " + ex.Message);
            }
        }

        public bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    OpenConnection(connection);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the database: " + ex.Message);
                return false;
            }
        }
    }
}
