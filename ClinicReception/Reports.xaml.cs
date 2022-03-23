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
    /// Логика взаимодействия для Reports.xaml
    /// </summary>
    public partial class Reports : Page
    {

        private WorkScopeReports _currentWorkRep1 = new WorkScopeReports();
        private IncidenceReports _currentWorkRep2 = new IncidenceReports();
        public Reports()
        {
            InitializeComponent();
            if (typeCombo_Box.Text == "WorkScopeReports")
                DataContext = _currentWorkRep1;
            if (typeCombo_Box.Text == "IncidenceReports")
                DataContext = _currentWorkRep2;
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (typeCombo_Box.Text == "WorkScopeReports")
            {
                var repForRemoving1 = data_Grid.SelectedItems.Cast<WorkScopeReports>().ToList();
                if (MessageBox.Show($"Вы уверены, что хотите удалить следующее количество {repForRemoving1.Count()} элементов?", "Внимание", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ClinicReceptionEntities.GetContext().WorkScopeReports.RemoveRange(repForRemoving1);
                        ClinicReceptionEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены!");
                        data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().WorkScopeReports.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else if (typeCombo_Box.Text == "IncidenceReports")
            {
                var repForRemoving2 = data_Grid.SelectedItems.Cast<IncidenceReports>().ToList();
                if (MessageBox.Show($"Вы уверены, что хотите удалить следующее количество {repForRemoving2.Count()} элементов?", "Внимание", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ClinicReceptionEntities.GetContext().IncidenceReports.RemoveRange(repForRemoving2);
                        ClinicReceptionEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены!");
                        data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().IncidenceReports.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (typeCombo_Box.Text == "WorkScopeReports")
            {
                try
                {

                    ClinicReceptionEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные сохранены!");
                    data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().WorkScopeReports.ToList();
                }
                catch (Exception exep)
                {
                    MessageBox.Show(exep.Message.ToString());
                }
            }
            else if (typeCombo_Box.Text == "IncidenceReports")
            {
                try
                {
                    ClinicReceptionEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные сохранены!");
                    data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().IncidenceReports.ToList();
                }
                catch (Exception exep)
                {
                    MessageBox.Show(exep.Message.ToString());
                }
            }
            
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (typeCombo_Box.Text == "WorkScopeReports")
            {
                Random random = new Random();
                _currentWorkRep1.ReportID = random.Next(100);
                ClinicReceptionEntities.GetContext().WorkScopeReports.Add(_currentWorkRep1);
                ClinicReceptionEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись добавлена!");
                data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().WorkScopeReports.ToList();
            }
            else if (typeCombo_Box.Text == "IncidenceReports")
            {
                Random random = new Random();
                _currentWorkRep2.ReportID = random.Next(100);
                ClinicReceptionEntities.GetContext().IncidenceReports.Add(_currentWorkRep2);
                ClinicReceptionEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись добавлена!");
                data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().IncidenceReports.ToList();
            }
            
        }
        

        private void SelBtn_Click(object sender, RoutedEventArgs e)
        {
            ClinicReceptionEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            if (typeCombo_Box.Text == "WorkScopeReports")
            { 
                data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().WorkScopeReports.ToList();
            }
            else if (typeCombo_Box.Text == "IncidenceReports")
            {
                data_Grid.ItemsSource = ClinicReceptionEntities.GetContext().IncidenceReports.ToList();
            }
            
        }


    }
}
