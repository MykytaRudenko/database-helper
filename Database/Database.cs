using Microsoft.Data.SqlClient;

namespace DatabaseHelper
{
    internal class Database
    {
        private string? connStr = null;
        private SqlConnection? conn = null;
        public Database(string str)
        {
            try
            {
                connStr = str;
                conn = GetSqlConn();
                Console.WriteLine("DB connection created successful!");
                conn.Open();
                Console.WriteLine("Connection opened!");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public SqlConnection GetSqlConn()
        {
            if (conn == null)
            {
                SqlConnection testConn = new SqlConnection(connStr);
                return testConn;
            }
            else
            {
                Console.WriteLine("Connection already created!");
                return conn;
            }
        }
        public int ExecuteCommand(string command)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                return new SqlCommand(command, conn).ExecuteNonQuery();
            }
            else return 0;

        }
        public void Destroy()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("Connection closed!");
            }
            else Console.WriteLine("Connection did not open!");
        }
    }
}
