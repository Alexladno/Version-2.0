using System;
using System.Data;
using System.Data.SqlClient;

namespace Регистрация
{
    internal class DataBase
    {
        public static string connectionString;

        public DataBase() { }

        private SqlConnection connection;

        // Метод для получения строки подключения в зависимости от заполненности полей
        private string GetConnectionString()
        {
            if (!string.IsNullOrEmpty(DataBases.Server) && !string.IsNullOrEmpty(DataBases.Baza) &&
                string.IsNullOrEmpty(DataBases.Login) && string.IsNullOrEmpty(DataBases.Pass))
            {
                return $"Data Source={DataBases.Server}; Initial Catalog={DataBases.Baza}; Integrated Security=True; Max Pool Size=200;";
            }
            else if (!string.IsNullOrEmpty(DataBases.Server) && !string.IsNullOrEmpty(DataBases.Baza) &&
                     !string.IsNullOrEmpty(DataBases.Login) && !string.IsNullOrEmpty(DataBases.Pass))
            {
                return $"Data Source={DataBases.Server}; Initial Catalog={DataBases.Baza}; User ID={DataBases.Login}; Password={DataBases.Pass}; Max Pool Size=200;";
            }
            else
            {
                throw new InvalidOperationException("Неправильная конфигурация базы данных.");
            }
        }

        // Метод для подключения к базе данных
        public SqlConnection ConnectToDatabase()
        {
            connectionString = GetConnectionString();
            connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        // Метод для открытия соединения
        public void OpenConnection()
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connectionString = GetConnectionString();
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
        }

        // Метод для закрытия соединения
        public void CloseConnection()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        // Метод для выполнения запроса и получения данных в виде DataTable
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            OpenConnection();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }

            CloseConnection();
            return dataTable;
        }

        public bool IsConnectionOpen()
        {
            return connection != null && connection.State == ConnectionState.Open;
        }
    }
}
