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
using System.IO;

namespace Регистрация
{
    public partial class Login : Window
    {
        DataBase DataBase = new DataBase();

        public static string UserGroup { get; set; }
        public static string TableName { get; set; }
        public Login()
        {
            InitializeComponent();

            Registr_CLick.MouseDown += Registr_CLick_MouseDown;
            Voiti_Click.MouseDown += Voiti_Click_MouseDown;
            LoadConfiguration();
        }


        // Метод для загрузки конфигурации из файла
        private void LoadConfiguration()
        {
            try
            {
                string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "config.txt");

                if (File.Exists(configPath))
                {

                    var configLines = File.ReadAllLines(configPath);
                    foreach (var line in configLines)
                    {
                        var parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            switch (parts[0].Trim())
                            {
                                case "Email":
                                    emailbox.Text = parts[1].Trim();
                                    break;
                                case "Pass":
                                    passbox.Text = parts[1].Trim();
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Некорректная строка в конфигурации: {line}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Файл конфигурации не найден.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке конфигурации: {ex.Message}");
            }
        }

        private void Voiti_Click_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataBase.OpenConnection();
                var emailUser = emailbox.Text;
                var passUser = passbox.Text;

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();

                string querystring = $"SELECT id_users, pass_users, fio_users, email_users, role_users, grups_and_fio, verification_users FROM users WHERE email_users = '{emailUser}' AND pass_users = '{passUser}'";

                SqlCommand command = new SqlCommand(querystring, DataBase.ConnectToDatabase());

                adapter.SelectCommand = command;
                adapter.Fill(table);

                int verificator = Convert.ToInt32(table.Rows[0]["verification_users"]);
                if (verificator == 0)
                {
                    MessageBox.Show("Ваша заявка на регистрацию еще не одобрена.");
                }
                else
                {
                    if (table.Rows.Count == 1)
                    {
                        string roleId = Convert.ToString(table.Rows[0]["role_users"]);
                        string userGroup = Convert.ToString(table.Rows[0]["grups_and_fio"]);


                        if (userGroup == "1исип-22")
                        {
                            Login.TableName = "oneisip22";
                        }

                        if (userGroup == "2исип-22")
                        {
                            Login.TableName = "twoisip22";
                        }
                        if (userGroup == "1исип-21")
                        {
                            Login.TableName = "oneisip21";
                        }


                        if (userGroup == "anikashin")
                        {
                            Login.TableName = "anikashin";
                        }
                        if (userGroup == "fyrkalo")
                        {
                            Login.TableName = "fyrkalo";
                        }




                        if (roleId == "студент")
                        {
                            MessageBox.Show($"Вы успешно вошли как студент группы {userGroup}!");
                            Rasp_stup testw = new Rasp_stup();
                            testw.Show();
                            Close();
                        }
                        else if (roleId == "преподаватель")
                        {
                            MessageBox.Show("Вы успешно вошли как преподаватель!");
                            Rasp_prepod rasp_prepod = new Rasp_prepod();
                            rasp_prepod.Show();
                            Close();
                        }
                        else if (roleId == "учебная-часть")
                        {
                            MessageBox.Show("Вы успешно вошли!");
                            Raspisanie_ych raspisanie_Ych = new Raspisanie_ych();
                            raspisanie_Ych.Show();
                            Close();
                        }
                        else if (roleId == "админ")
                        {
                            MessageBox.Show("Вы успешно вошли как АДМИН!");
                            Raspisanie raspisanie = new Raspisanie();
                            raspisanie.Show();
                            Close();
                        }
                        else if (roleId == "")
                        {
                            MessageBox.Show("Вы успешно вошли в роли гостя!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль или логин указан неверно", "Ошибка!");
                    }
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}");
            }
            finally
            {
                DataBase.CloseConnection();
            }

        }


        private void Registr_CLick_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Registration login = new Registration();
            login.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBases dataBases = new DataBases();
            dataBases.Show();
        }
    }
}