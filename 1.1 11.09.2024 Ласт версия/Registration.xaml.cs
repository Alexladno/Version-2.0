using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using static MaterialDesignThemes.Wpf.Theme;

namespace Регистрация
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {



        DataBase DataBase = new DataBase();


        public Registration()
        {
            InitializeComponent();


            Reg_Click.MouseDown += Reg_Click_MouseDown;
            Login_Click.MouseDown += Login_Click_MouseDown;






        }

        private void Login_Click_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void Reg_Click_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
            
            DataBase.OpenConnection();

            string fio = fio_box.Text.Trim();
            string email = email_box.Text.Trim().ToLower();
            string pass = pass_box.Text.ToLower();
            string grups = grups_box.Text.ToLower();
            string otdelenie = otdelenie_box.Text.ToLower();


            if (pass.Length < 5)
            {
                pass_box.ToolTip = "Это поле введено не корректно!";
                pass_box.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                email_box.ToolTip = "Это поле введено не корректно!";
                email_box.Background = Brushes.DarkRed;
            }
            else if (otdelenie == null)
            {
                otdelenie_box.ToolTip = "Это поле введено не корректно!";
            }
            else
            {
                fio_box.ToolTip = "";
                fio_box.Background = Brushes.Transparent;
                pass_box.ToolTip = "";
                pass_box.Background = Brushes.Transparent;
                fio_box.ToolTip = "";
                fio_box.Background = Brushes.Transparent;
                email_box.ToolTip = "";
                email_box.Background = Brushes.Transparent;
                otdelenie_box.ToolTip = "";
                otdelenie_box.Background = Brushes.Transparent;

                MessageBox.Show("Вы успешно зарегистрировались!");


                var addQuery = $"INSERT INTO users (fio_users, pass_users, email_users, grups_and_fio, otdelenie, verification_users) VALUES ('{fio}', '{pass}', '{email}', '{grups}', '{otdelenie}', 0)";
                var command = new SqlCommand(addQuery, DataBase.ConnectToDatabase());
                command.ExecuteNonQuery();

                Login login1 = new Login();
                login1.Show();
                Close(); ;

                DataBase.CloseConnection();

            }
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
    }
}
