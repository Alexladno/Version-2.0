using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;
using MaterialDesignColors;
using System.Data.Common;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Регистрация
{


    
    /// <summary>
    /// Логика взаимодействия для testvivod.xaml
    /// </summary>
    public partial class testvivod : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-AC0US7D\SQLEXPRESS;Initial Catalog=diplom; Integrated Security=True");


        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;



        //private void CreateColumns()
        //{
        //    sqlConnection.Open();
        //    string query = "SELECT id_users, fio_users, email_users, pass_users, grups_users, role_users FROM users";
        //    using (SqlCommand command = new SqlCommand(query, sqlConnection))
        //    {
        //        SqlDataReader reader = command.ExecuteReader();
        //        myDataGrid.ItemsSource = reader;
        //    }

        //}

        

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
                string query = "SELECT id_users, fio_users, email_users,  grups_users, role_users FROM users";
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
            
                string searchText = searchTextBox.Text;
                if (!string.IsNullOrEmpty(searchText))
                {
                    DataView dv = dataTable.DefaultView;
                    dv.RowFilter = string.Format("fio_users LIKE '%{0}%'", searchText);
                    dataGrid.ItemsSource = dv;
                }
                else if(searchTextBox.Text == null)
                {
                string query1 = "SELECT id_users, fio_users, email_users,  grups_users, role_users FROM users";
                dataAdapter = new SqlDataAdapter(query1, sqlConnection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
                else
                {
                    dataGrid.ItemsSource = dataTable.DefaultView;
                }
            
        
        }

        


        public testvivod()
        {
            InitializeComponent();
            //CreateColumns();



            vixod.MouseDown += Vixod_MouseDown;






        }

        private void Vixod_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Raspisanie4u raspisanie4U = new Raspisanie4u();
            raspisanie4U.Show();
            Close();
        }
    }
}
