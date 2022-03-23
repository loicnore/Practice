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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        private Accounts _currentAccount = new Accounts();
        public Authorization()
        {
            InitializeComponent();
            DataContext = _currentAccount;
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            string email = Email.Text.Trim();
            string password = Password.Password.Trim();
            if (email.Length <= 0 || password.Length > 20)
            {
                Email.ToolTip = "Это поле введено некорректно!";
                Email.Background = Brushes.Red;
                Email.Background = new SolidColorBrush(Colors.Red) { Opacity = 0.4 };
                Password.ToolTip = "Это поле введено некорректно!";
                Password.Background = Brushes.Red;
                Password.Background = new SolidColorBrush(Colors.Red) { Opacity = 0.4 };
            }
            else
            {
                Email.ToolTip = "";
                Password.ToolTip = "";
                Email.Background = Brushes.Transparent;
                Password.Background = Brushes.Transparent;
                using (ClinicReceptionEntities db = new ClinicReceptionEntities())
                {
                    _currentAccount = db.Accounts.Where(l => l.Email == email && l.Password == password).FirstOrDefault();
                }
                if (_currentAccount != null)
                {
                    if (_currentAccount.Role == "A")
                    {
                        string login = _currentAccount.Email;
                        Manager.MainFrame.Navigate(new AdminPanel(email));
                    }
                    if (_currentAccount.Role == "R")
                    {
                        string login = _currentAccount.Email;
                        Manager.MainFrame.Navigate(new RegistratorPanel(email));
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не найден.");
                    Email.Clear();
                    Password.Clear();
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Email.Clear();
                Password.Clear();
            }
        }
    }
}
