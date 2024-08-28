using System.Data.SqlClient;

namespace ABCCars
{
    // This class is used to store the connection string
    internal class ConnectionString
    {
        public string connectionString;
        // ================== Connection string to connect to the database ==================
        
        public ConnectionString()
        {
            connectionString = "Server=ATOM\\SQLEXPRESS;Database=ABCCarTrades;Trusted_Connection=True;";
    }
        // ==================================================================================

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
