using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;

namespace Регистрация
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin8 : Window
    {

        DataBase DataBase = new DataBase();

        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;



        public Admin8()
        {
            InitializeComponent();
            vixod.MouseDown += Vixod_MouseDown;
            Verificator_users.MouseDown += Verificator_users_MouseDown;
            changevivod.MouseDown += Changevivod_MouseDown;

            vivoddannix();
            LoadUsers();
        }



        private void LoadUsers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DataBase.connectionString))
                {
                    connection.Open();
                    string query = "SELECT fio_users FROM users where verification_users = 1";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> users = new List<string>();
                    while (reader.Read())
                    {
                        users.Add(reader["fio_users"].ToString());
                    }
                    userComboBox.ItemsSource = users;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке пользователей: " + ex.Message);
            }
        }

        private void UpdateRole_Click(object sender, RoutedEventArgs e)
        {
            string selectedUser = userComboBox.SelectedItem as string;
            if (selectedUser == null)
            {
                MessageBox.Show("Выберите пользователя.");
                return;
            }

            string selectedRole = (roleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (selectedRole == null)
            {
                MessageBox.Show("Выберите роль.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataBase.connectionString))
                {
                    connection.Open();
                    string query = "UPDATE users SET role_users = @role_users WHERE fio_users = @fio_users";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@fio_users", selectedUser);
                    command.Parameters.AddWithValue("@role_users", selectedRole);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Роль пользователя успешно обновлена.");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить роль пользователя.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении роли пользователя: " + ex.Message);
            }
        }



        private void Changevivod_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vivoddannix();
        }

        private void Verificator_users_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AdminVerification adminVerification = new AdminVerification();
            adminVerification.Show();
        }

        private void ApplyFilter()
        {
            List<string> filters = new List<string>();

            if (checkBoxFilter1.IsChecked == true)
                filters.Add("grups_and_fio = '2ИСиП-22'");

            if (checkBoxFilter2.IsChecked == true)
                filters.Add("grups_and_fio = '1исип-22'");

            if (checkBoxFilter3.IsChecked == true)
                filters.Add("role_users = 'студент'");

            if (checkBoxFilter4.IsChecked == true)
                filters.Add("role_users = 'преподаватель'");

            if (checkBoxFilter5.IsChecked == true)
                filters.Add("role_users = 'админ'");

            if (checkBoxFilter6.IsChecked == true)
                filters.Add("otdelenie = 'ППССЗ'");

            if (checkBoxFilter7.IsChecked == true)
                filters.Add("otdelenie = 'ППКРС'");

            string filterCondition = string.Join(" AND ", filters);

            if (!string.IsNullOrEmpty(filterCondition))
            {
                DataView dataView = dataGrid.ItemsSource as DataView;
                dataView.RowFilter = filterCondition;
            }
            else
            {
                (dataGrid.ItemsSource as DataView).RowFilter = "";
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ApplyFilter();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ApplyFilter();
        }

        private void vivoddannix()
        {
            try
            {
            
            string query = "SELECT id_users, fio_users, email_users,  grups_and_fio, role_users, otdelenie FROM users where verification_users = 1";
            dataAdapter = new SqlDataAdapter(query, DataBase.ConnectToDatabase());
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}");
            }
            finally
            {
                DataBase.CloseConnection();
            }
        }


        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {




            string searchText = searchTextBox.Text;
            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = dataTable.DefaultView;
                dv.RowFilter = string.Format("fio_users LIKE '%{0}%'", searchText);
                dataGrid.ItemsSource = dv;
            }
            else
            {
                vivoddannix();
            }

        }

        private void Vixod_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Raspisanie4u raspisanie4u = new Raspisanie4u();
            raspisanie4u.Show();
            Close();
        }

        private void userComboBox_DropDownOpened(object sender, EventArgs e)
        {

        }
    }
}
