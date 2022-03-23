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
    /// Логика взаимодействия для EmployeeRegistration.xaml
    /// </summary>
    public partial class EmployeeRegistration : Page
    {
        private Staff _currentEmployee = new Staff();
        public EmployeeRegistration(Staff selectedEmployee)
        {
            InitializeComponent();
            if (selectedEmployee != null)
                _currentEmployee = selectedEmployee;
            DataContext = _currentEmployee;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentEmployee.Surname) || string.IsNullOrWhiteSpace(_currentEmployee.Name) ||
                string.IsNullOrWhiteSpace(_currentEmployee.Patronymic) || string.IsNullOrWhiteSpace(_currentEmployee.Position) ||
                string.IsNullOrWhiteSpace(_currentEmployee.Address) || string.IsNullOrWhiteSpace(_currentEmployee.Email) ||
                 string.IsNullOrWhiteSpace(_currentEmployee.Role) || string.IsNullOrWhiteSpace(_currentEmployee.Phone))
                errors.AppendLine("Заполните пустые поля!");
            try
            {
                if (_currentEmployee.Phone != null)
                {
                    if (_currentEmployee.Phone.Length != 12)
                        errors.AppendLine("Номер телефона должен содержать 11 цифр и знак +.");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Номер телефона должен содержать 11 цифр и знак +.");
            }


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentEmployee.EmployeeID == 0)
            {
                Random random = new Random();
                _currentEmployee.EmployeeID = random.Next(100);
                ClinicReceptionEntities.GetContext().Staff.Add(_currentEmployee);
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
            position.Clear();
            phone.Clear();
            address.Clear();
            email.Clear();
            role.Clear();
        }
    }
}
