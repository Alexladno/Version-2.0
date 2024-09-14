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
using System.Data.Entity;

namespace Регистрация
{
    /// <summary>
    /// Логика взаимодействия для Raspisanie4u.xaml
    /// </summary>
    public partial class Raspisanie4u : Window
    {

        DataBase DataBase = new DataBase();

        public Raspisanie4u()
        {
            InitializeComponent();
            pari.MouseDown += Pari_MouseDown;
            Vixod_Click.MouseDown += Vixod_Click_MouseDown;
            Admin.MouseDown += Admin_MouseDown;
            rezimur.MouseDown += Rezimur_MouseDown;
            Datasource.MouseDown += Datasource_MouseDown;
            otchet.MouseDown += Otchet_MouseDown1;


            time.MouseDown += Time_MouseDown;
            time1.MouseDown += Time1_MouseDown;

            label1.Content = "8:00";
            label2.Content = "8:45";
            label3.Content = "8:55";
            label4.Content = "9:40";
            label5.Content = "9:55";
            label6.Content = "10:40";
            label7.Content = "10:55";
            label8.Content = "11:40";
            label9.Content = "11:50";
            label10.Content = "12:35";
            label11.Content = "12:45";
            label12.Content = "13:30";
            label13.Content = "13:40";
            label14.Content = "14:25";
            label15.Content = "14:35";
            label16.Content = "15:20";


            LoadCurrentDaySchedule_rasp();







        }

        private void Otchet_MouseDown1(object sender, MouseButtonEventArgs e)
        {
            Otchety otchety = new Otchety();
            otchety.Show();
        }
        



        private bool calendarOpened = false;
        private void OpenCalendarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!calendarOpened)
            {
                ScheduleCalendar.Visibility = Visibility.Visible;
                LoadScheduleButton.Visibility = Visibility.Visible;
                calendarOpened = true;
            }
            else
            {
                ScheduleCalendar.Visibility = Visibility.Collapsed;
                LoadScheduleButton.Visibility = Visibility.Collapsed;
                calendarOpened = false;
            }
        }


        private void LoadScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            if (ScheduleCalendar.SelectedDate.HasValue)
            {
                DateTime selectedDate = ScheduleCalendar.SelectedDate.Value;
                LoadWeekSchedule(selectedDate);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите дату.", "Информация");
            }
        }

        private void LoadWeekSchedule(DateTime selectedDate)
        {
            DateTime startOfWeek = GetStartOfWeek(selectedDate);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            ClearLabels();

            HighlightSelectedDay(selectedDate.DayOfWeek);

            for (int i = 0; i < 7; i++)
            {
                DateTime currentDay = startOfWeek.AddDays(i);
                LoadScheduleForDay(currentDay);
            }
        }

        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private void LoadScheduleForDay(DateTime date)
        {
            try
            {
            string query = "SELECT TOP 8 name_predmet, fio_prepod, name_class, number_aud " +
               "FROM ninea " + // Пробел добавлен после имени таблицы
               "WHERE CONVERT(date, data_yroka, 104) = @date";


            SqlParameter parameter = new SqlParameter("@date", date.ToString("dd.MM.yyyy"));

            
                DataTable dataTable = DataBase.ExecuteQuery(query, new SqlParameter[] { parameter });

                int lessonIndex = 1;
                foreach (DataRow row in dataTable.Rows)
                {
                    int numberAud;
                    if (int.TryParse(row["number_aud"].ToString(), out numberAud))
                    {
                        UpdateLabelsForDay(date.DayOfWeek, lessonIndex,
                            row["name_predmet"].ToString(),
                            row["fio_prepod"].ToString(),
                            row["name_class"].ToString(),
                            numberAud);
                    }
                    lessonIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
            }
        }

        private void UpdateLabelsForDay(DayOfWeek dayOfWeek, int lessonIndex, string subject, string teacher, string group, int room)
        {
            string subjectLabelName = $"{dayOfWeek}Lesson{lessonIndex}SubjectLabel";
            string teacherLabelName = $"{dayOfWeek}Lesson{lessonIndex}TeacherLabel";
            string groupLabelName = $"{dayOfWeek}Lesson{lessonIndex}GroupLabel";
            string roomLabelName = $"{dayOfWeek}Lesson{lessonIndex}RoomLabel";

            Label subjectLabel = (Label)FindName(subjectLabelName);
            Label teacherLabel = (Label)FindName(teacherLabelName);
            Label groupLabel = (Label)FindName(groupLabelName);
            Label roomLabel = (Label)FindName(roomLabelName);

            if (subjectLabel != null) subjectLabel.Content = $"{subject}";
            if (teacherLabel != null) teacherLabel.Content = $"{teacher}";
            if (groupLabel != null) groupLabel.Content = $"{group}";
            if (roomLabel != null) roomLabel.Content = $"{room}";
        }

        private void ClearLabels()
        {
            foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
            {
                for (int i = 1; i <= 8; i++)
                {
                    string subjectLabelName = $"{dayOfWeek}Lesson{i}SubjectLabel";
                    string teacherLabelName = $"{dayOfWeek}Lesson{i}TeacherLabel";
                    string groupLabelName = $"{dayOfWeek}Lesson{i}GroupLabel";
                    string roomLabelName = $"{dayOfWeek}Lesson{i}RoomLabel";

                    Label subjectLabel = (Label)FindName(subjectLabelName);
                    Label teacherLabel = (Label)FindName(teacherLabelName);
                    Label groupLabel = (Label)FindName(groupLabelName);
                    Label roomLabel = (Label)FindName(roomLabelName);

                    if (subjectLabel != null) subjectLabel.Content = string.Empty;
                    if (teacherLabel != null) teacherLabel.Content = string.Empty;
                    if (groupLabel != null) groupLabel.Content = string.Empty;
                    if (roomLabel != null) roomLabel.Content = string.Empty;
                }
            }
        }

        private void HighlightSelectedDay(DayOfWeek dayOfWeek)
        {
            MondayLabel.Fill = Brushes.Transparent;
            TuesdayLabel.Fill = Brushes.Transparent;
            WednesdayLabel.Fill = Brushes.Transparent;
            ThursdayLabel.Fill = Brushes.Transparent;
            FridayLabel.Fill = Brushes.Transparent;
            SaturdayLabel.Fill = Brushes.Transparent;
            SundayLabel.Fill = Brushes.Transparent;

            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    MondayLabel.Fill = Brushes.Yellow;
                    break;
                case DayOfWeek.Tuesday:
                    TuesdayLabel.Fill = Brushes.Yellow;
                    break;
                case DayOfWeek.Wednesday:
                    WednesdayLabel.Fill = Brushes.Yellow;
                    break;
                case DayOfWeek.Thursday:
                    ThursdayLabel.Fill = Brushes.Yellow;
                    break;
                case DayOfWeek.Friday:
                    FridayLabel.Fill = Brushes.Yellow;
                    break;
                case DayOfWeek.Saturday:
                    SaturdayLabel.Fill = Brushes.Yellow;
                    break;
                case DayOfWeek.Sunday:
                    SundayLabel.Fill = Brushes.Yellow;
                    break;
            }
        }



        private void Time_MouseDown(object sender, MouseButtonEventArgs e)
        {
            label1.Content = "8:00";
            label2.Content = "8:45";
            label3.Content = "8:55";
            label4.Content = "9:40";
            label5.Content = "9:55";
            label6.Content = "10:40";
            label7.Content = "10:55";
            label8.Content = "11:40";
            label9.Content = "11:50";
            label10.Content = "12:35";
            label11.Content = "12:45";
            label12.Content = "13:30";
            label13.Content = "13:40";
            label14.Content = "14:25";
            label15.Content = "14:35";
            label16.Content = "15:20";
        }

        private void Time1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            label1.Content = "8:00";
            label2.Content = "8:30";
            label3.Content = "8:40";
            label4.Content = "9:10";
            label5.Content = "9:20";
            label6.Content = "9:50";
            label7.Content = "10:00";
            label8.Content = "10:30";
            label9.Content = "10:40";
            label10.Content = "11:10";
            label11.Content = "11:40";
            label12.Content = "12:10";
            label13.Content = "12:40";
            label14.Content = "13:10";
            label15.Content = "13:40";
            label16.Content = "14:10";

        }

























        private void LoadCurrentDaySchedule_rasp()
        {
            DateTime today = DateTime.Now;
            HighlightSelectedDay(today.DayOfWeek);
            LoadWeekSchedule_rasp(today);
        }

        private void LoadWeekSchedule_rasp(DateTime selectedDate)
        {
            DateTime startOfWeek = GetStartOfWeek_rasp(selectedDate);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            ClearLabels_rasp();

            HighlightSelectedDay(selectedDate.DayOfWeek);

            for (int i = 0; i < 7; i++)
            {
                DateTime currentDay = startOfWeek.AddDays(i);
                LoadScheduleForDay(currentDay);
            }
        }

        private DateTime GetStartOfWeek_rasp(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private void LoadScheduleForDay_rasp(DateTime date)
        { 
             try
            {
            string query = "SELECT TOP 8 name_predmet, fio_prepod, name_grup, number_aud, podmena " +
                           "FROM oneisip22 " +
                           "WHERE CONVERT(date, data_pari, 104) = @date";

            SqlParameter parameter = new SqlParameter("@date", date.ToString("dd.MM.yyyy"));

            
                DataTable dataTable = DataBase.ExecuteQuery(query, new SqlParameter[] { parameter });

                int lessonIndex = 1;
                foreach (DataRow row in dataTable.Rows)
                {
                    int numberAud;
                    if (int.TryParse(row["number_aud"].ToString(), out numberAud))
                    {
                        UpdateLabelsForDay_rasp(date.DayOfWeek, lessonIndex,
                            row["name_predmet"].ToString(),
                            row["fio_prepod"].ToString(),
                            row["name_grup"].ToString(),
                            numberAud);

                        // Проверяем значение поля 'podmena' и обновляем цвет квадрата
                        string podmena = row["podmena"].ToString();
                        UpdateRectangleColor_rasp(date.DayOfWeek, lessonIndex, podmena);
                    }
                    lessonIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
            }
        }

        private void UpdateLabelsForDay_rasp(DayOfWeek dayOfWeek, int lessonIndex, string subject, string teacher, string group, int room)
        {
            string subjectLabelName = $"{dayOfWeek}Lesson{lessonIndex}SubjectLabel";
            string teacherLabelName = $"{dayOfWeek}Lesson{lessonIndex}TeacherLabel";
            string groupLabelName = $"{dayOfWeek}Lesson{lessonIndex}GroupLabel";
            string roomLabelName = $"{dayOfWeek}Lesson{lessonIndex}RoomLabel";

            Label subjectLabel = (Label)FindName(subjectLabelName);
            Label teacherLabel = (Label)FindName(teacherLabelName);
            Label groupLabel = (Label)FindName(groupLabelName);
            Label roomLabel = (Label)FindName(roomLabelName);

            if (subjectLabel != null) subjectLabel.Content = $"{subject}";
            if (teacherLabel != null) teacherLabel.Content = $"{teacher}";
            if (groupLabel != null) groupLabel.Content = $"{group}";
            if (roomLabel != null) roomLabel.Content = $"{room}";
        }

        private void UpdateRectangleColor_rasp(DayOfWeek dayOfWeek, int lessonIndex, string podmena)
        {
            // Определяем номер дня недели (1 = Понедельник, 7 = Воскресенье)
            int dayNumber = (int)dayOfWeek;
            if (dayNumber == 0) dayNumber = 7; // Воскресенье - это 7

            // Ищем квадрат по имени
            string rectangleName = $"testcolor{dayNumber}{lessonIndex}";
            Rectangle rectangle = (Rectangle)FindName(rectangleName);

            if (rectangle != null)
            {
                if (podmena == "Yes")
                {
                    // Если 'podmena' = 'Yes', закрашиваем квадрат в красный цвет
                    rectangle.Fill = Brushes.Red;
                }
                else
                {
                    // Если 'podmena' = 'No', оставляем цвет без изменений
                    // Мы не делаем ничего, так как цвет квадрата уже задан
                }
            }
        }

        private void ClearLabels_rasp()
        {
            foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
            {
                for (int i = 1; i <= 4; i++)
                {
                    string subjectLabelName = $"{dayOfWeek}Lesson{i}SubjectLabel";
                    string teacherLabelName = $"{dayOfWeek}Lesson{i}TeacherLabel";
                    string groupLabelName = $"{dayOfWeek}Lesson{i}GroupLabel";
                    string roomLabelName = $"{dayOfWeek}Lesson{i}RoomLabel";

                    Label subjectLabel = (Label)FindName(subjectLabelName);
                    Label teacherLabel = (Label)FindName(teacherLabelName);
                    Label groupLabel = (Label)FindName(groupLabelName);
                    Label roomLabel = (Label)FindName(roomLabelName);

                    if (subjectLabel != null) subjectLabel.Content = string.Empty;
                    if (teacherLabel != null) teacherLabel.Content = string.Empty;
                    if (groupLabel != null) groupLabel.Content = string.Empty;
                    if (roomLabel != null) roomLabel.Content = string.Empty;
                }
            }
        }

        private void HighlightSelectedDay_rasp(DayOfWeek dayOfWeek)
        {
            MondayLabel.Fill = Brushes.Transparent;
            TuesdayLabel.Fill = Brushes.Transparent;
            WednesdayLabel.Fill = Brushes.Transparent;
            ThursdayLabel.Fill = Brushes.Transparent;
            FridayLabel.Fill = Brushes.Transparent;
            SaturdayLabel.Fill = Brushes.Transparent;
            SundayLabel.Fill = Brushes.Transparent;

            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    MondayLabel.Fill = Brushes.Yellow;
                    break;
                case DayOfWeek.Tuesday:
                    TuesdayLabel.Fill = Brushes.Yellow;
                    break;
                case DayOfWeek.Wednesday:
                    WednesdayLabel.Fill = Brushes.Yellow;
                    break;
                case DayOfWeek.Thursday:
                    ThursdayLabel.Fill = Brushes.Yellow;
                    break;
                case DayOfWeek.Friday:
                    FridayLabel.Fill = Brushes.Yellow;
                    break;
                case DayOfWeek.Saturday:
                    SaturdayLabel.Fill = Brushes.Yellow;
                    break;
                case DayOfWeek.Sunday:
                    SundayLabel.Fill = Brushes.Yellow;
                    break;
            }
        }



        private void Datasource_MouseDown(object sender, MouseButtonEventArgs e)
        {
           DataBases dataBases = new DataBases();
            dataBases.Show();
        }


        private void Admin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Admin8 admin8 = new Admin8();
            admin8.Show();
            Close();
        }

        private void Vixod_Click_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void Pari_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Raspisanie raspisanie = new Raspisanie();
            raspisanie.Show();
            Close();
        }

        private void Rezimur_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rezimur rezimur = new Rezimur();
            rezimur.Show();
        }






        


        

    }
}
