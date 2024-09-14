using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Регистрация
{
    static class DataBank
    {
        public static string Server;
        public static string Baza;
        public static string connectionString;

        public static SqlConnection ConnectToDatabase()
        {
            connectionString = $"Data Source={DataBank.Server}; Initial Catalog={DataBank.Baza}; Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
