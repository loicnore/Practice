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
    /// Логика взаимодействия для PatientsList.xaml
    /// </summary>
    public partial class PatientsList : Page
    {
        private Patients _currentPatient = new Patients();
        public PatientsList()
        {
            InitializeComponent();
            DataContext = _currentPatient;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ClinicReceptionEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().Patients.ToList();
            }
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var patForRemoving = data_Grid.SelectedItems.Cast<Patients>().ToList();
            if (MessageBox.Show($"Вы уверены, что хотите удалить следующее количество {patForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ClinicReceptionEntities.GetContext().Patients.RemoveRange(patForRemoving);
                    ClinicReceptionEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().Patients.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void poiskTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _currentPatient = ClinicReceptionEntities.GetContext().Patients.ToList();
            _currentPatient = _currentPatient.Where(p => p.Surname.ToLower().Contains(poiskTxt.Text.ToLower())).ToList();
            data_Grid.ItemsSource = _currentPatient;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PatientRegistration(null));
        }
        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PatientRegistration((sender as Button).DataContext as Patients));
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClinicReceptionEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены!");
                data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().Patients.ToList();
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message.ToString());
            }
        }
    }
}
