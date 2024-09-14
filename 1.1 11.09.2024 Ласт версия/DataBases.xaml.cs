using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Регистрация
{
     partial class DataBases : Window
    {
        public static string Server;
        public static string Baza;
        public static string Login;
        public static string Pass;

        public DataBases()
        {
            InitializeComponent();
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
                                case "Server":
                                    serverName.Text = parts[1].Trim();
                                    break;
                                case "Baza":
                                    bazaName.Text = parts[1].Trim();
                                    break;
                            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Server = serverName.Text;
            Baza = bazaName.Text;
            Login = loginName.Text;
            Pass = passName.Password;
            Close();
        }
    }
}