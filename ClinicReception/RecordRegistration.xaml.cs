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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClinicReception
{
    /// <summary>
    /// Логика взаимодействия для RecordRegistration.xaml
    /// </summary>
    public partial class RecordRegistration : Page
    {
        private AppointmentRegistration _currentRecord = new AppointmentRegistration();
        public RecordRegistration(AppointmentRegistration selectedRecord)
        {
            InitializeComponent();
            if (selectedRecord != null)
                _currentRecord = selectedRecord;
            DataContext = _currentRecord;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentRecord.Surname) || string.IsNullOrWhiteSpace(_currentRecord.Name) ||
                string.IsNullOrWhiteSpace(_currentRecord.Patronymic) || string.IsNullOrWhiteSpace(_currentRecord.Department) ||
                string.IsNullOrWhiteSpace(_currentRecord.Phone) || string.IsNullOrWhiteSpace(_currentRecord.DocSurname) ||
                string.IsNullOrWhiteSpace(_currentRecord.DocName) || string.IsNullOrWhiteSpace(_currentRecord.DocPatronymic))
                errors.AppendLine("Заполните пустые поля!");
            try
            {
                if (_currentRecord.Phone != null)
                {
                    if (_currentRecord.Phone.Length != 12)
                        errors.AppendLine("Номер телефона должен содержать 11 цифр и знак +.");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Номер телефона должен содержать 11 цифр и знак +.");
            }


            if (medcard.Text != null)
            {
                string mc = Convert.ToString(_currentRecord.MedCard);
                if (mc.Length != 8)
                    errors.AppendLine("Номер мед. карты должен содержать 8 цифр.");
            }
            
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentRecord.RecordID == 0)
            {
                Random random = new Random();
                _currentRecord.RecordID = random.Next(100);
                ClinicReceptionEntities.GetContext().AppointmentRegistration.Add(_currentRecord);
            }
            
            try
            {
                ClinicReceptionEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешное сохранение данных!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            patientID.Clear();
            surname.Clear();
            name.Clear();
            patronymic.Clear();
            phone.Clear();
            medcard.Clear();
            dateTime.Clear();
            department.Clear();
            docSurname.Clear();
            docName.Clear();
            docPatronymic.Clear();
        }
    }
}
