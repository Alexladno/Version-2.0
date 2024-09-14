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

namespace Регистрация
{
    public partial class DataEntryDialog : Window
    {
        public DateTime? SelectedDate { get; private set; }

        public DataEntryDialog(DateTime? selectedDate = null)
        {
            InitializeComponent();

            SelectedDate = selectedDate;

            // Устанавливаем выбранную дату в DatePicker, если она была передана
            if (SelectedDate.HasValue)
            {
                DatePicker.SelectedDate = SelectedDate.Value;
            }

            // Инициализируем ComboBox'ы
            InitializeComboBoxes();
        }

        private void InitializeComboBoxes()
        {
            // Пример значений для ComboBox'ов
            TeacherComboBox.Items.Add("Преподаватель 1");
            TeacherComboBox.Items.Add("Преподаватель 2");
            TeacherComboBox.Items.Add("Преподаватель 3");

            GroupComboBox.Items.Add("Группа 1");
            GroupComboBox.Items.Add("Группа 2");
            GroupComboBox.Items.Add("Группа 3");
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedDate = DatePicker.SelectedDate;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public ScheduleData GetSelectedData()
        {
            return new ScheduleData
            {
                Teacher = TeacherComboBox.Text,
                Group = GroupComboBox.Text,
                Audience = AudienceTextBox.Text,
                Subject = SubjectTextBox.Text
            };
        }
    }

    public class ScheduleData
    {
        public string Teacher { get; set; }
        public string Group { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }

}
