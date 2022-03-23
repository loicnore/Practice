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
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public AdminPanel(string l)
        {
            InitializeComponent();
            loginTxt.Text = "Добро пожаловать, " + l + " !";
        }

        private void regAcc_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AccountsList());
        }
        private void regEmBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EmployeeList());
        }  
    }
}
