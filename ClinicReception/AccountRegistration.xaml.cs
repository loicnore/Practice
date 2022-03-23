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
    /// Логика взаимодействия для AccountRegistration.xaml
    /// </summary>
    public partial class AccountRegistration : Page
    {
        private Accounts _currentAcc = new Accounts();
        public event DependencyPropertyChangedEventHandler IsEnabledChanged;
        public AccountRegistration(Accounts selectedAcc)
        {
            InitializeComponent();
            if (selectedAcc != null)
                _currentAcc = selectedAcc;
            DataContext = _currentAcc;
            if (_currentAcc.Email != null)
                MessageBox.Show("Поле Email недоступно для изменения!");
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentAcc.Email) || string.IsNullOrWhiteSpace(_currentAcc.Password) ||
                string.IsNullOrWhiteSpace(_currentAcc.Role))
                errors.AppendLine("Заполните пустые поля!");
            

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }



            if (_currentAcc.Email == null || (_currentAcc.Email != "anohliza@gmail.com" & _currentAcc.Email != "burnick@gmail.com" & _currentAcc.Email != "klimshan@gmail.com"))
            {
                ClinicReceptionEntities.GetContext().Accounts.Add(_currentAcc);
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
           
            email.Clear();
            password.Clear();
            role.Clear();
        }
    }
}
