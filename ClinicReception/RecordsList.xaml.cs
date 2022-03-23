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
    /// Логика взаимодействия для RecordsList.xaml
    /// </summary>
    public partial class RecordsList : Page
    {
        private AppointmentRegistration _currentRec = new AppointmentRegistration();
        public RecordsList()
        {
            InitializeComponent();
            DataContext = _currentRec;
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ClinicReceptionEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().AppointmentRegistration.ToList();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RecordRegistration(null));
        }

        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RecordRegistration((sender as Button).DataContext as AppointmentRegistration));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var recForRemoving = data_Grid.SelectedItems.Cast<AppointmentRegistration>().ToList();
            if (MessageBox.Show($"Вы уверены, что хотите удалить следующее количество {recForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ClinicReceptionEntities.GetContext().AppointmentRegistration.RemoveRange(recForRemoving);
                    ClinicReceptionEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().AppointmentRegistration.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClinicReceptionEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены!");
                data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().AppointmentRegistration.ToList();
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message.ToString());
            }
        }

        private void poiskTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _currentRec = ClinicReceptionEntities.GetContext().AppointmentRegistration.ToList();
            _currentRec = _currentRec.Where(p => p.Surname.ToLower().Contains(poiskTxt.Text.ToLower())).ToList();
            data_Grid.ItemsSource = _currentRec;
        }
    }
}
