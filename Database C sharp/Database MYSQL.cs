using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Database_C_sharp
{
    internal class Database_MYSQL
    {
        private MySqlConnection connection;
        private string server = "localhost";
        private string username = "root";
        private string password = "";
        private string database = "test";
        public MySqlDataAdapter adapter;
        public DataSet data;

        // Constructor
        public Database_MYSQL()
        {
            Initialize();
        }

        // Initialize the database connection
        private void Initialize()
        {
            string connectionString = $"server={server};username={username};Password={password};database={database}";
            connection = new MySqlConnection(connectionString);
        }

        // Open the database connection
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
            
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }

        // Close the database connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        // Insert data into the database
        public bool InsertData(string value1)
        {
            try
            {
                // Open the connection
                if (OpenConnection())
                {
                    // Your INSERT query with parameters
                    string query = "INSERT INTO `prayer` (`dontbescared`) VALUES (@value1)";

                    // Create a MySqlCommand object and pass the query and connection
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        cmd.Parameters.AddWithValue("@value1", value1);

                        // Execute the query
                        cmd.ExecuteNonQuery();

                        // Close the connection
                        CloseConnection();

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }

        // Retrieve data from the database and populate DataGridView
        public DataSet GetDataForDataGridView()
        {
            try
            {
                // Open the connection
                if (OpenConnection())
                {
                    // Your SELECT query
                    string query = "SELECT * FROM `prayer`";

                    // Create a DataSet to store the data
                    DataSet dataSet = new DataSet();

                    // Create a MySqlDataAdapter to execute the query and fill the DataSet
                    using (adapter = new MySqlDataAdapter(query, connection))
                    {
                        // Fill the DataSet
                        adapter.Fill(dataSet, "YourData");

                        // Close the connection
                        CloseConnection();

                        return dataSet;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
