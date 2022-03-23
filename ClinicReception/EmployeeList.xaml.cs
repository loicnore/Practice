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
    /// Логика взаимодействия для EmployeeList.xaml
    /// </summary>
    public partial class EmployeeList : Page
    {
        private Staff _currentEmp= new Staff();
        public EmployeeList()
        {
            InitializeComponent();
            DataContext = _currentEmp;
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ClinicReceptionEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().Staff.ToList();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EmployeeRegistration(null));
        }

        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EmployeeRegistration((sender as Button).DataContext as Staff));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var empForRemoving = data_Grid.SelectedItems.Cast<Staff>().ToList();
            if (MessageBox.Show($"Вы уверены, что хотите удалить следующее количество {empForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ClinicReceptionEntities.GetContext().Staff.RemoveRange(empForRemoving);
                    ClinicReceptionEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().Staff.ToList();
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
                data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().Staff.ToList();
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message.ToString());
            }
        }

        private void poiskTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _currentEmp = ClinicReceptionEntities.GetContext().Staff.ToList();
            _currentEmp = _currentEmp.Where(p => p.Surname.ToLower().Contains(poiskTxt.Text.ToLower())).ToList();
            data_Grid.ItemsSource = _currentEmp;
        }
    }
}
