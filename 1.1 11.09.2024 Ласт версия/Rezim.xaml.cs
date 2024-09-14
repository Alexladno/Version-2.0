using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для Rezim.xaml
    /// </summary>
    public partial class Rezim : Window
    {


        DataBase DataBase = new DataBase();


        public Rezim()
        {
            InitializeComponent();
            Primenit_Click.MouseDown += Primenit_Click_MouseDown;

            sbros.MouseDown += Nado_MouseDown;





        }

        private void Nado_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vibordnya.SelectedItem = null;
            vibordnya.SelectedValue = null;
            vibordnya.SelectedIndex = -1;

            viborpari.SelectedItem = null;
            viborpari.SelectedValue = null;
            viborpari.SelectedIndex = -1;


            vibortable.SelectedItem = null;
            vibortable.SelectedValue = null;
            vibortable.SelectedIndex = -1;

            viborpredmet.SelectedItem = null;
            viborpredmet.SelectedValue = null;
            viborpredmet.SelectedIndex = -1;

            viborfio.SelectedItem = null;
            viborfio.SelectedValue = null;
            viborfio.SelectedIndex = -1;

            viboraud.SelectedItem = null;
            viboraud.SelectedValue = null;
            viboraud.SelectedIndex = -1;




        }

        private void Primenit_Click_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
            
            string selectedDay = (vibordnya.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (selectedDay == null)
            {
                MessageBox.Show("Выберите день недели.");
                return;
            }


            string selectedPara = (viborpari.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (selectedPara == null)
            {
                MessageBox.Show("Выберите день недели.");
                return;
            }

            string selectedAud = (viboraud.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (selectedAud == null)
            {
                MessageBox.Show("Выберите день недели.");
                return;
            }

            string selectedPredmet = (viborpredmet.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (selectedPredmet == null)
            {
                MessageBox.Show("Выберите предмет.");
                return;
            }

            string selectedFio = (viborfio.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (selectedFio == null)
            {
                MessageBox.Show("Выберите ФИО.");
                return;
            }

            string selectedTable = (vibortable.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (selectedTable == null)
            {
                MessageBox.Show("Выберите день недели.");
                return;
            }


            {
              
                    string query = $"UPDATE {selectedTable} SET name_predmet = @name_predmet, number_aud = @number_aud, fio_prepod = @fio_prepod, podmena = 'Yes' WHERE name_day  = @name_day  and para = @para";
                    SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
                command.Parameters.AddWithValue("@name_day", selectedDay);
                    command.Parameters.AddWithValue("@para", selectedPara);
                    command.Parameters.AddWithValue("@number_aud", selectedAud);
                    command.Parameters.AddWithValue("@name_predmet", selectedPredmet);
                    command.Parameters.AddWithValue("@fio_prepod", selectedFio);
                    command.Parameters.AddWithValue("@name_table", selectedTable);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Расписание успешно обновлено.");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить расписание.");
                    }
                
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

        private void UpdateRole_Click(object sender, RoutedEventArgs e)
        {
            

        }


    }
}
