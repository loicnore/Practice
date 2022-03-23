using Microsoft.OData.Edm;
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
    /// Логика взаимодействия для PatientRegistration.xaml
    /// </summary>
    public partial class PatientRegistration : Page
    {
        private Patients _currentPatient = new Patients();
        public PatientRegistration(Patients selectedPatient)
        {
            InitializeComponent();
            if (selectedPatient != null)
                _currentPatient = selectedPatient;
            DataContext = _currentPatient;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentPatient.Surname) || string.IsNullOrWhiteSpace(_currentPatient.Name) ||
                string.IsNullOrWhiteSpace(_currentPatient.Patronymic) || string.IsNullOrWhiteSpace(_currentPatient.Address) ||
                string.IsNullOrWhiteSpace(_currentPatient.Phone))
                errors.AppendLine("Заполните пустые поля!");
            try
            {
                if (_currentPatient.Phone != null)
                {
                    if (_currentPatient.Phone.Length != 12)
                        errors.AppendLine("Номер телефона должен содержать 11 цифр и знак +.");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Номер телефона должен содержать 11 цифр и знак +.");
            }

            int min = 00000000;
            int max = 99999999;
            int num = 0;
            if (medcard.Text != null)
            {
                string mc = Convert.ToString(_currentPatient.MedCard);
                if (mc.Length != 8)
                    errors.AppendLine("Номер мед. карты должен содержать 8 цифр.");
            }

            while (_currentPatient.MedCard == num)
            {
                Random card = new Random();
                num = card.Next(min, max);
                _currentPatient.MedCard = Convert.ToInt32(num);
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentPatient.PatientID == 0)
            {
                Random random = new Random();
                _currentPatient.PatientID = random.Next(100);
                ClinicReceptionEntities.GetContext().Patients.Add(_currentPatient);
            }
                

            try
            {
                ClinicReceptionEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешное изменение данных!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            surname.Clear();
            name.Clear();
            patronymic.Clear();
            birthdate.Clear();
            phone.Clear();
            address.Clear();
            medcard.Clear();
        }
    }
}
