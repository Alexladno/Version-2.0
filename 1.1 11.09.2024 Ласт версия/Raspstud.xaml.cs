using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Raspstud.xaml
    /// </summary>
    public partial class Raspstud : Window
    {


        DataBase DataBase = new DataBase();

        







        public Raspstud()
        {
            InitializeComponent();
            Vixos_Click.MouseDown += Vixos_Click_MouseDown;


            oneisip22_111();
            oneisip22_112();
            oneisip22_113();
            oneisip22_114();
            oneisip22_121();
            oneisip22_122();
            oneisip22_123();
            oneisip22_124();
            oneisip22_131();
            oneisip22_132();
            oneisip22_133();
            oneisip22_134();
            oneisip22_141();
            oneisip22_142();
            oneisip22_143();
            oneisip22_144();

            oneisip22_211();
            oneisip22_212();
            oneisip22_213();
            oneisip22_214();
            oneisip22_221();
            oneisip22_222();
            oneisip22_223();
            oneisip22_224();
            oneisip22_231();
            oneisip22_232();
            oneisip22_233();
            oneisip22_234();
            oneisip22_241();
            oneisip22_242();
            oneisip22_243();
            oneisip22_244();


            oneisip22_311();
            oneisip22_312();
            oneisip22_313();
            oneisip22_314();
            oneisip22_321();
            oneisip22_322();
            oneisip22_323();
            oneisip22_324();
            oneisip22_331();
            oneisip22_332();
            oneisip22_333();
            oneisip22_334();
            oneisip22_341();
            oneisip22_342();
            oneisip22_343();
            oneisip22_344();


            oneisip22_411();
            oneisip22_412();
            oneisip22_413();
            oneisip22_414();
            oneisip22_421();
            oneisip22_422();
            oneisip22_423();
            oneisip22_424();
            oneisip22_431();
            oneisip22_432();
            oneisip22_433();
            oneisip22_434();
            oneisip22_441();
            oneisip22_442();
            oneisip22_443();
            oneisip22_444();



            oneisip22_511();
            oneisip22_512();
            oneisip22_513();
            oneisip22_514();
            oneisip22_521();
            oneisip22_522();
            oneisip22_523();
            oneisip22_524();
            oneisip22_531();
            oneisip22_532();
            oneisip22_533();
            oneisip22_534();
            oneisip22_541();
            oneisip22_542();
            oneisip22_543();
            oneisip22_544();
        }

        private void Vixos_Click_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void oneisip22_111()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 1";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor11.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet11.Content = sb.ToString();
        }

        private void oneisip22_112()
        {
            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 1", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups11.Content = sb.ToString();
        }


        private void oneisip22_113()
        {
            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 1", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio11.Content = sb.ToString();
        }

        private void oneisip22_114()
        {
            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 1", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud11.Content = sb.ToString();
        }

        private void oneisip22_121()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 2";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor12.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet12.Content = sb.ToString();
        }

        private void oneisip22_122()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 2", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups12.Content = sb.ToString();
        }


        private void oneisip22_123()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 2", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio12.Content = sb.ToString();
        }

        private void oneisip22_124()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 2", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud12.Content = sb.ToString();
        }




        private void oneisip22_131()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 3";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor13.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet13.Content = sb.ToString();
        }

        private void oneisip22_132()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 3", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups13.Content = sb.ToString();
        }


        private void oneisip22_133()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 3", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio13.Content = sb.ToString();
        }

        private void oneisip22_134()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 3", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud13.Content = sb.ToString();
        }



        private void oneisip22_141()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 4";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor14.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet14.Content = sb.ToString();
        }

        private void oneisip22_142()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 4", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups14.Content = sb.ToString();
        }


        private void oneisip22_143()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 4", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio14.Content = sb.ToString();
        }

        private void oneisip22_144()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 4", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud14.Content = sb.ToString();
        }















        private void oneisip22_211()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 5";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor21.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet21.Content = sb.ToString();
        }

        private void oneisip22_212()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 5", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups21.Content = sb.ToString();
        }


        private void oneisip22_213()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 5", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio21.Content = sb.ToString();
        }

        private void oneisip22_214()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 5", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud21.Content = sb.ToString();
        }

        private void oneisip22_221()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 6";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase()); 
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor22.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet22.Content = sb.ToString();
        }

        private void oneisip22_222()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 6", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups22.Content = sb.ToString();
        }


        private void oneisip22_223()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 6", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio22.Content = sb.ToString();
        }

        private void oneisip22_224()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 6", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud22.Content = sb.ToString();
        }




        private void oneisip22_231()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 7";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor23.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet23.Content = sb.ToString();
        }

        private void oneisip22_232()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 7", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups23.Content = sb.ToString();
        }


        private void oneisip22_233()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 7", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio23.Content = sb.ToString();
        }

        private void oneisip22_234()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 7", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud23.Content = sb.ToString();
        }



        private void oneisip22_241()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 8";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor24.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet24.Content = sb.ToString();
        }

        private void oneisip22_242()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 8", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups24.Content = sb.ToString();
        }


        private void oneisip22_243()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 8", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio24.Content = sb.ToString();
        }

        private void oneisip22_244()
        {
            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 8", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            aud24.Content = sb.ToString();
        }








        private void oneisip22_311()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 9";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor31.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet31.Content = sb.ToString();
        }

        private void oneisip22_312()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 9", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups31.Content = sb.ToString();
        }


        private void oneisip22_313()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 9", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio31.Content = sb.ToString();
        }

        private void oneisip22_314()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 9", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud31.Content = sb.ToString();
        }

        private void oneisip22_321()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 10";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor32.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet32.Content = sb.ToString();
        }

        private void oneisip22_322()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 10", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups32.Content = sb.ToString();
        }


        private void oneisip22_323()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 10", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio32.Content = sb.ToString();
        }

        private void oneisip22_324()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 10", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud32.Content = sb.ToString();
        }




        private void oneisip22_331()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 11";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor33.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet33.Content = sb.ToString();
        }

        private void oneisip22_332()
        {
            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 11", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups33.Content = sb.ToString();
        }


        private void oneisip22_333()
        {
            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 11", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio33.Content = sb.ToString();
        }

        private void oneisip22_334()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 11", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud33.Content = sb.ToString();
        }



        private void oneisip22_341()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 12";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor34.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet34.Content = sb.ToString();
        }

        private void oneisip22_342()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 12", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups34.Content = sb.ToString();
        }


        private void oneisip22_343()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 12", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio34.Content = sb.ToString();
        }

        private void oneisip22_344()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 12", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud34.Content = sb.ToString();
        }














        private void oneisip22_411()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 13";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor41.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet41.Content = sb.ToString();
        }

        private void oneisip22_412()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 13", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups41.Content = sb.ToString();
        }


        private void oneisip22_413()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 13", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio41.Content = sb.ToString();
        }

        private void oneisip22_414()
        {


            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 13", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud41.Content = sb.ToString();
        }

        private void oneisip22_421()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 14";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor42.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet42.Content = sb.ToString();
        }

        private void oneisip22_422()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 14", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups42.Content = sb.ToString();
        }


        private void oneisip22_423()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 14", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio42.Content = sb.ToString();
        }

        private void oneisip22_424()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 14", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud42.Content = sb.ToString();
        }




        private void oneisip22_431()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 15";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor43.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet43.Content = sb.ToString();
        }

        private void oneisip22_432()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 15", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups43.Content = sb.ToString();
        }


        private void oneisip22_433()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 15", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio43.Content = sb.ToString();
        }

        private void oneisip22_434()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 15", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud43.Content = sb.ToString();
        }



        private void oneisip22_441()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 16";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor44.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet44.Content = sb.ToString();
        }

        private void oneisip22_442()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 16", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups44.Content = sb.ToString();
        }


        private void oneisip22_443()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 16", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio44.Content = sb.ToString();
        }

        private void oneisip22_444()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 16", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud44.Content = sb.ToString();
        }








        private void oneisip22_511()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 17";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor51.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet51.Content = sb.ToString();
        }

        private void oneisip22_512()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 17", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups51.Content = sb.ToString();
        }


        private void oneisip22_513()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 17", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio51.Content = sb.ToString();
        }

        private void oneisip22_514()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 17", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud51.Content = sb.ToString();
        }

        private void oneisip22_521()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 18";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor52.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet52.Content = sb.ToString();
        }

        private void oneisip22_522()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 18", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups52.Content = sb.ToString();
        }


        private void oneisip22_523()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 18", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio52.Content = sb.ToString();
        }

        private void oneisip22_524()
        {
            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 18", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud52.Content = sb.ToString();
        }




        private void oneisip22_531()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 19";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor53.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet53.Content = sb.ToString();
        }

        private void oneisip22_532()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 19", DataBase.ConnectToDatabase()); 
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups53.Content = sb.ToString();
        }


        private void oneisip22_533()
        {

            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 19", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio53.Content = sb.ToString();
        }

        private void oneisip22_534()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 19", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud53.Content = sb.ToString();
        }



        private void oneisip22_541()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT name_predmet, podmena FROM oneisip22 where id = 20 ";
            SqlCommand command = new SqlCommand(query, DataBase.ConnectToDatabase());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                string colorId = Convert.ToString(table.Rows[0]["podmena"]);
                if (colorId == "Yes")
                {
                    testcolor54.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }
            predmet54.Content = sb.ToString();
        }

        private void oneisip22_542()
        {

            SqlCommand command = new SqlCommand("SELECT name_grup FROM oneisip22 where id = 20", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            grups54.Content = sb.ToString();
        }


        private void oneisip22_543()
        {
            SqlCommand command = new SqlCommand("SELECT fio_prepod FROM oneisip22 where id = 20", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            fio54.Content = sb.ToString();
        }

        private void oneisip22_544()
        {

            SqlCommand command = new SqlCommand("SELECT number_aud FROM oneisip22 where id = 20", DataBase.ConnectToDatabase());
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder sb = new StringBuilder();


            while (reader.Read())
            {
                // Assuming the table has only one column
                sb.AppendLine(reader[0].ToString());
            }


            aud54.Content = sb.ToString();
        }

    }
}
