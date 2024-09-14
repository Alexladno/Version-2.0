using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data;
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
using Microsoft.Win32;
using System.IO;
using System.Windows.Threading;

namespace Регистрация
{
    /// <summary>
    /// Логика взаимодействия для Raspisanie.xaml
    /// </summary>
    public partial class Raspisanie : Window
    {

        DataBase DataBase = new DataBase();
        public string table_name { get; set; }



        public Raspisanie()
        {
            InitializeComponent();
            Vixos_Click.MouseDown += Vixos_Click_MouseDown;
            Uroki.MouseDown += Uroki_MouseDown;
            Onerezim.MouseDown += Onerezim_MouseDown;
            Admin.MouseDown += Admin_MouseDown;
            otchet.MouseDown += Otchet_MouseDown;


            testcolor11.Fill = new SolidColorBrush(Colors.White);
            testcolor12.Fill = new SolidColorBrush(Colors.White);
            testcolor13.Fill = new SolidColorBrush(Colors.White);
            testcolor14.Fill = new SolidColorBrush(Colors.White);

            time.MouseDown += Time_MouseDown;
            time1.MouseDown += Time1_MouseDown;

            label.Content = "8:15";
            label1.Content = "9:50";
            label3.Content = "10:00";
            label4.Content = "11:35";
            label5.Content = "12:00";
            label6.Content = "13:35";
            label7.Content = "13:45";
            label8.Content = "15:20";

            LoadCurrentDaySchedule_rasp();






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
                string query = "SELECT TOP 4 name_predmet, fio_prepod, name_grup, number_aud " +
                   "FROM oneisip22 " + // Пробел добавлен после имени таблицы
                   "WHERE CONVERT(date, data_pari, 104) = @date";


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
                            row["name_grup"].ToString(),
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








        private void LoadCurrentDaySchedule_rasp()
        {
            DateTime today = DateTime.Now;
            HighlightSelectedDay_rasp(today.DayOfWeek);
            LoadWeekSchedule_rasp(today);
        }

        private void LoadWeekSchedule_rasp(DateTime selectedDate)
        {
            DateTime startOfWeek = GetStartOfWeek_rasp(selectedDate);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            ClearLabels_rasp();

            HighlightSelectedDay_rasp(selectedDate.DayOfWeek);

            for (int i = 0; i < 7; i++)
            {
                DateTime currentDay = startOfWeek.AddDays(i);
                LoadScheduleForDay_rasp(currentDay);
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
                string query = "SELECT TOP 4 name_predmet, fio_prepod, name_grup, number_aud, podmena " +
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











        private void Otchet_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Otchetp otchetp = new Otchetp();
            otchetp.Show();
        }

        private void Podklychenie_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataBases dataBases = new DataBases();
            dataBases.Show();
        }

        private void Time_MouseDown(object sender, MouseButtonEventArgs e)
        {
            label.Content = "8:15";
            label1.Content = "9:50";
            label3.Content = "10:00";
            label4.Content = "11:35";
            label5.Content = "12:00";
            label6.Content = "13:35";
            label7.Content = "13:45";
            label8.Content = "15:20";
        }


        private void Time1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            label.Content = "8:15";
            label1.Content = "9:15";
            label3.Content = "9:25";
            label4.Content = "10:25";
            label5.Content = "10:35";
            label6.Content = "11:35";
            label7.Content = "11:45";
            label8.Content = "12:45";
        }

        private void Admin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }


        private void Onerezim_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rezim rezim = new Rezim();
            rezim.Show();
        }

        private void Uroki_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Raspisanie4u raspisanie4U = new Raspisanie4u();
            raspisanie4U.Show();
            Close();
        }

        private void Vixos_Click_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void oneisip22_Click(object sender, RoutedEventArgs e)
        {
            table_name = "oneisip22";
            LoadCurrentDaySchedule_tabl();
        }

        private void twoisip22_Click(object sender, RoutedEventArgs e)
        {
            table_name = "twoisip22";
            LoadCurrentDaySchedule_tabl();
        }

        private void triisip22_Click(object sender, RoutedEventArgs e)
        {
            table_name = "triisip22";
            LoadCurrentDaySchedule_tabl();
        }

        private void kpo22_Click(object sender, RoutedEventArgs e)
        {
            table_name = "kpo22";
            LoadCurrentDaySchedule_tabl();
        }

        private void ras22_Click(object sender, RoutedEventArgs e)
        {
            table_name = "ras22";
            LoadCurrentDaySchedule_tabl();
        }

        private void doroshkov_Click(object sender, RoutedEventArgs e)
        {
            table_name = "doroshkov";
            LoadCurrentDaySchedule_tabl();
        }

        private void fedosenko_Click(object sender, RoutedEventArgs e)
        {
            table_name = "fedosenko";
            LoadCurrentDaySchedule_tabl();
        }

        private void fyrkalo_Click(object sender, RoutedEventArgs e)
        {
            table_name = "fyrkalo";
            LoadCurrentDaySchedule_tabl();
        }

        private void anikashin_Click(object sender, RoutedEventArgs e)
        {
            table_name = "anikashin";
            LoadCurrentDaySchedule_tabl();
        }

        private void seroysov_Click(object sender, RoutedEventArgs e)
        {
            table_name = "seroysov";
            LoadCurrentDaySchedule_tabl();
        }




        private void LoadCurrentDaySchedule_tabl()
        {
            DateTime today = DateTime.Now;
            HighlightSelectedDay_tabl(today.DayOfWeek);
            LoadWeekSchedule_tabl(today);
        }

        private void LoadWeekSchedule_tabl(DateTime selectedDate)
        {
            DateTime startOfWeek = GetStartOfWeek_tabl(selectedDate);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            ClearLabels_tabl();

            HighlightSelectedDay_tabl(selectedDate.DayOfWeek);

            for (int i = 0; i < 7; i++)
            {
                DateTime currentDay = startOfWeek.AddDays(i);
                LoadScheduleForDay_tabl(currentDay);
            }
        }

        private DateTime GetStartOfWeek_tabl(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private void LoadScheduleForDay_tabl(DateTime date)
        {
            try
            {
                string query = $"SELECT TOP 4 name_predmet, fio_prepod, name_grup, number_aud, podmena FROM {table_name} WHERE CONVERT(date, data_pari, 104) = @date";

                SqlParameter parameter = new SqlParameter("@date", date.ToString("dd.MM.yyyy"));


                DataTable dataTable = DataBase.ExecuteQuery(query, new SqlParameter[] { parameter });

                int lessonIndex = 1;
                foreach (DataRow row in dataTable.Rows)
                {
                    int numberAud;
                    if (int.TryParse(row["number_aud"].ToString(), out numberAud))
                    {
                        UpdateLabelsForDay_tabl(date.DayOfWeek, lessonIndex,
                            row["name_predmet"].ToString(),
                            row["fio_prepod"].ToString(),
                            row["name_grup"].ToString(),
                            numberAud);

                        // Проверяем значение поля 'podmena' и обновляем цвет квадрата
                        string podmena = row["podmena"].ToString();
                        UpdateRectangleColor_tabl(date.DayOfWeek, lessonIndex, podmena);
                    }
                    lessonIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
            }
        }

        private void UpdateLabelsForDay_tabl(DayOfWeek dayOfWeek, int lessonIndex, string subject, string teacher, string group, int room)
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

        private void UpdateRectangleColor_tabl(DayOfWeek dayOfWeek, int lessonIndex, string podmena)
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

        private void ClearLabels_tabl()
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

        private void HighlightSelectedDay_tabl(DayOfWeek dayOfWeek)
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

        private void SaveImage_Click(object sender, RoutedEventArgs e)
        {
            // Убедитесь, что Canvas отрисован и имеет ненулевые размеры
            ScheduleCanvas.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            ScheduleCanvas.Arrange(new Rect(ScheduleCanvas.DesiredSize));

            // Обновите размеры после разметки
            int width = (int)ScheduleCanvas.ActualWidth;
            int height = (int)ScheduleCanvas.ActualHeight;

            if (width <= 0 || height <= 0)
            {
                MessageBox.Show("Размеры контейнера некорректны. Пожалуйста, убедитесь, что контейнер имеет ненулевые размеры.", "Ошибка");
                return;
            }

            // Создайте RenderTargetBitmap для захвата изображения
            RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);

            // Отрисуйте Canvas в RenderTargetBitmap
            rtb.Render(ScheduleCanvas);

            // Создайте BitmapEncoder для сохранения изображения
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));

            // Сохраните изображение в файл
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PNG Image|*.png",
                FileName = $"Расписание_{table_name}" + DateTime.Now.ToString("yyyy_MMdd_HHmmss")
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    encoder.Save(fs);
                }
                MessageBox.Show("Изображение сохранено успешно!", "Успех");
            }
        }

    }
}
