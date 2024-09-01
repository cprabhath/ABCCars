using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

// This class is used to execute queries
namespace ABCCars
{
    internal class QueryExecutor
    {
        // ================== Create an instance of the ConnectionString class ==================
        private readonly ConnectionString cs = new ConnectionString();
        // ======================================================================================

        // ========================= Check the connection to the database ========================
        public bool CheckConnection()
        {
            try
            {
                // ================== Create a connection to the database ==================
                using (SqlConnection connection = new SqlConnection(cs.connectionString))
                {
                    connection.Open();
                    connection.Close();
                }
                // ================== Return true if the connection is successful ==================
                return true;
            }
            // ================== Catch any exceptions and return false ==================
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        // =======================================================================================

        public string ExecuteReaderQueries(string query, params SqlParameter[] parameters)
        {
            try
            {
                // ================== Create a connection to the database ==================
                using (SqlConnection connection = new SqlConnection(cs.connectionString))
                {
                    // ================== Open the connection ==================
                    connection.Open();
                    // ================== Create a command to execute the query ==================
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // ================== Add the parameters to the command ==================
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        // ================== Execute the query and return the result ==================
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader[0].ToString();
                            }
                            return null;
                        }
                    }
                }
            }
            // ================== Catch any exceptions and return null ==================
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // ========================= Execute a non-query statement ===============================
        public bool ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                // ================== Create a connection to the database ==================
                using (SqlConnection connection = new SqlConnection(cs.connectionString))
                {
                    // ================== Open the connection ==================
                    connection.Open();
                    // ================== Create a command to execute the query ==================
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);
                        command.ExecuteNonQuery();
                    }
                }
                // ================== Return true if the query is executed successfully ==================
                return true;
            }
            // ================== Catch any exceptions and return false ==================
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        // =======================================================================================

        // ========================= Execute a reader statement ==================================
        public bool ExecuteReader(string query, params SqlParameter[] parameters)
        {
            try
            {
                // ================== Create a connection to the database ==================
                using (SqlConnection connection = new SqlConnection(cs.connectionString))
                {
                    // ================== Open the connection ==================
                    connection.Open();
                    // ================== Create a command to execute the query ==================
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // ================== Add the parameters to the command ==================
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        // ================== Execute the query and return true if there are rows ==================
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            // ================== Catch any exceptions and return false ==================
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        // =======================================================================================

        // ========================= Execute a table statement ===================================
        public DataTable TableExecutor(string query, params SqlParameter[] parameters)
        {
            // ================== Create a new DataTable ==================
            DataTable dataTable = new DataTable();

            try
            {
                // ================== Create a connection to the database ==================
                using (SqlConnection connection = new SqlConnection(cs.connectionString))
                {
                    // ================== Open the connection ==================
                    connection.Open();
                    // ================== Create a command to execute the query ==================
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // ================== Add the parameters to the command ==================
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        // ================== Execute the query and load the data into the DataTable ==================
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
            }
            // ================== Catch any exceptions and return the DataTable ==================
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // ================== Return the DataTable ==================
            return dataTable;
        }
        // =======================================================================================


        // ============================== Query without parameters ===============================
        public List<string> GetList(string query)
        {
            List<string> list = new List<string>();
            try
            {
                // ================== Create a connection to the database ==================
                using (SqlConnection connection = new SqlConnection(cs.connectionString))
                {
                    // ================== Open the connection ==================
                    connection.Open();
                    // ================== Create a command to execute the query ==================
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // ================== Execute the query and add the results to the list ==================
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(reader[0].ToString());
                            }
                        }
                    }
                }
            }
            // ================== Catch any exceptions and return the list ==================
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // ================== Return the list ==================
            return list;


        }

        public List<Dictionary<string, object>> ListAll(string query, SqlParameter[] parameters = null)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                using (SqlConnection connection = new SqlConnection(cs.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // If parameters are provided, add them to the command
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Dictionary<string, object> row = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row[reader.GetName(i)] = reader.GetValue(i);
                                }
                                list.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }


    }
}