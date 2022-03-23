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
    /// Логика взаимодействия для RegistratorPanel.xaml
    /// </summary>
    public partial class RegistratorPanel : Page
    {
        public RegistratorPanel(string l)
        {
            InitializeComponent();
            loginTxt.Text ="Добро пожаловать, " + l + " !";
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PatientRegistration(null));
        }

        private void PatBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PatientsList());
        }

        private void recBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RecordRegistration(null));
        }

        private void SchedBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ScheduleInfo());
        }

        private void RepBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Reports());
        }

        
    }
}
