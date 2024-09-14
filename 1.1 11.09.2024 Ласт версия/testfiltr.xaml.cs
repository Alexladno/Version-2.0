using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Регистрация
{
    /// <summary>
    /// Логика взаимодействия для testfiltr.xaml
    /// </summary>
    public partial class testfiltr : Window
    {
        private ObservableCollection<Item> items;
        private ICollectionView itemsView;
        private SqlConnection connection;
        private string connectionString = "Data Source=DESKTOP-AC0US7D\\SQLEXPRESS;Initial Catalog=diplom; Integrated Security=True";


        public testfiltr()
        {
            InitializeComponent();
            items = new ObservableCollection<Item>();
            dataGrid.AutoGenerateColumns = true;
            InitializeConnection();
            LoadDataFromDatabase();
            itemsView = CollectionViewSource.GetDefaultView(items);
            dataGrid.ItemsSource = itemsView;
        }

        private void InitializeConnection()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private void LoadDataFromDatabase()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM users", connection); // Замените YourTable на имя вашей таблицы
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                // Создаем объект Item из данных, полученных из базы данных
                Item item = new Item();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    // Используем имена столбцов из базы данных для заполнения свойств объекта Item
                    string columnName = reader.GetName(i);
                    object value = reader[i];
                    item.Properties.Add(columnName, value);
                }
                items.Add(item);
            }
            reader.Close();
        }

        private void FilterCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateFilter();
        }

        private void FilterCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateFilter();
        }

        private void UpdateFilter()
        {
            itemsView.Filter = item =>
            {
                if (item is Item currentItem)
                {
                    bool filterEnabled = filterCheckBox.IsChecked ?? false;
                    if (!filterEnabled)
                        return true;

                    // Проверяем, соответствует ли название группы фильтру
                    return currentItem.Properties.ContainsKey("GroupName") && (currentItem.Properties["GroupName"] as string) == "1ИСиП-22"; // Замените "YourFilterValue" на ваше значение фильтра
                }
                return false;
            };
        }
    }

    public class Item
    {
        // Хранение свойств объекта в словаре для динамического добавления столбцов
        public Dictionary<string, object> Properties { get; } = new Dictionary<string, object>();
    }

}

    

