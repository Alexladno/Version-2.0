using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Регистрация
{
    public partial class AdminVerification : Window
    {
        private DataTable dataTable; // Объявляем DataTable здесь

        DataBase DataBase = new DataBase();

        public AdminVerification()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                DataBase.OpenConnection();

                string query = "SELECT id_users, fio_users, email_users, grups_and_fio, otdelenie FROM users WHERE verification_users = 0";
                var command = new SqlCommand(query, DataBase.ConnectToDatabase());
                var dataAdapter = new SqlDataAdapter(command);
                dataTable = new DataTable(); // Инициализируем DataTable
                dataAdapter.Fill(dataTable);

                // Добавляем колонку для флажков выбора, если её нет
                if (!dataTable.Columns.Contains("IsSelected"))
                {
                    DataColumn selectedColumn = new DataColumn("IsSelected", typeof(bool));
                    selectedColumn.DefaultValue = false;
                    dataTable.Columns.Add(selectedColumn);
                }

                UsersDataGrid.ItemsSource = dataTable.DefaultView;

                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            List<int> selectedUserIds = new List<int>();

            // Перебираем строки DataTable для получения выбранных пользователей
            foreach (DataRow row in dataTable.Rows)
            {
                // Получаем значение флажка IsSelected для каждой строки
                bool isSelected = (bool)row["IsSelected"];

                if (isSelected)
                {
                    selectedUserIds.Add((int)row["id_users"]);
                }
            }

            if (selectedUserIds.Count > 0)
            {
                try
                {
                    DataBase.OpenConnection();

                    foreach (int userId in selectedUserIds)
                    {
                        string updateQuery = $"UPDATE users SET verification_users = 1 WHERE id_users = {userId}";
                        var updateCommand = new SqlCommand(updateQuery, DataBase.ConnectToDatabase());
                        updateCommand.ExecuteNonQuery();
                    }

                    DataBase.CloseConnection();

                    LoadUsers(); // Обновляем список пользователей после одобрения
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка одобрения пользователей: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите пользователей для одобрения.");
            }
        }
    }
}
