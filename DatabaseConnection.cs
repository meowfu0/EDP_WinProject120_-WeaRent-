using MySql.Data.MySqlClient;
using System;

namespace EDP_WinProject102__WearRent_
{
    internal class DatabaseConnection
    {
        private MySqlConnection connection;

        
        public DatabaseConnection()
        {
          
            string connString = "Server=localhost; Database=clothing rental_ecommerce6; Uid=root; Pwd=password12341;";
            connection = new MySqlConnection(connString);
        }

        
        public void OpenConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void ExecuteQuery(MySqlCommand cmd)
        {
            try
            {
                OpenConnection();
                cmd.Connection = connection; 
                cmd.ExecuteNonQuery(); 
                CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public object ExecuteScalarQuery(MySqlCommand cmd)
        {
            object result = null;
            try
            {
                OpenConnection();
                cmd.Connection = connection;
                result = cmd.ExecuteScalar();
                CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return result;
        }


        public MySqlDataReader ExecuteSelectQuery(MySqlCommand cmd)
        {
            MySqlDataReader reader = null;
            try
            {
                OpenConnection();
                cmd.Connection = connection; 
                reader = cmd.ExecuteReader(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return reader;
        }
    }
}
