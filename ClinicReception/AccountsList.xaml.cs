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
    /// Логика взаимодействия для AccountsList.xaml
    /// </summary>
    public partial class AccountsList : Page
    {
        private Accounts _currentAcc = new Accounts();
        public AccountsList()
        {
            InitializeComponent();
            DataContext = _currentAcc;
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ClinicReceptionEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().Accounts.ToList();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AccountRegistration(null));
        }
        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AccountRegistration((sender as Button).DataContext as Accounts));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var accForRemoving = data_Grid.SelectedItems.Cast<Accounts>().ToList();
            if (MessageBox.Show($"Вы уверены, что хотите удалить следующее количество {accForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ClinicReceptionEntities.GetContext().Accounts.RemoveRange(accForRemoving);
                    ClinicReceptionEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().Accounts.ToList();
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
                data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().Accounts.ToList();
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message.ToString());
            }
        }

        private void poiskTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _currentAcc = ClinicReceptionEntities.GetContext().Accounts.ToList();
            _currentAcc = _currentAcc.Where(p => p.Email.ToLower().Contains(poiskTxt.Text.ToLower())).ToList();
            data_Grid.ItemsSource = _currentAcc;
        }
    }
}
