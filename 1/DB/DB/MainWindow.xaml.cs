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
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;

namespace DB
{

    public partial class MainWindow : Window
    {
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        string connectionString = @"Data Source=DESKTOP-M09421F\SQLEXPRESS; Initial Catalog=Hotel24; Integrated Security=True";
        DataSet ds;
        DataTable table;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void displayB_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (connection !=null || connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                table = new DataTable();
                SqlCommand sql = new SqlCommand("SELECT * FROM " + combo_Box1.Text, connection);
                // Создаем объект DataAdapter
                adapter = new SqlDataAdapter(sql);
                //// Создаем объект Dataset
                //ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(table);
                // Отображаем данные
                data_Grid.ItemsSource = table.DefaultView;
                //table = ds.Tables[0];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message} " +
                    $"\nРекомендуется: выбрать таблицу из предложенного списка.");
            }
        }

        // добавить гостя
        private void addB_Click(object sender, RoutedEventArgs e)
        {
            if (combo_Box1.Text.ToString() == "Customers")
            {
                using (Hotel24Entities1 db = new Hotel24Entities1())
                {
                    Customer c = new Customer();
                    c.Age = 100;
                    c.Email = "someemail@mail.ru";
                    c.FirstName = "Peter";
                    c.LastName = "Pen";
                    c.PassportID = 123456;
                    c.Phone = "7-999-999-99-99";
                    db.Customers.Add(c);
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Выберите таблицу Customer для изменения!");
            }
        }

        // изменить данные гостя
        private void changeB_Click(object sender, RoutedEventArgs e)
        {
            if (combo_Box1.Text.ToString() == "Customers")
            {
                using (Hotel24Entities1 db = new Hotel24Entities1())
                {
                    Customer p1 = db.Customers.Where((customer) => customer.FirstName == "Peter" && customer.LastName == "Pen").FirstOrDefault();
                    p1.Age = 30000;
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Выберите таблицу Customer для изменения!");
            }
        }

        // удалить данные гостя
        private void delB_Click(object sender, RoutedEventArgs e)
        {
            if (combo_Box1.Text.ToString() == "Customers")
            {
                using (Hotel24Entities1 db = new Hotel24Entities1())
                {
                    Customer p1 = db.Customers.Where((customer) => customer.FirstName == "Peter" && customer.LastName == "Pen").FirstOrDefault();
                    if (p1 != null)
                    {
                        db.Customers.Remove(p1);
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите таблицу Customer для изменения!");
            }
        }

        // сохранить
        private void saveB_Click(object sender, RoutedEventArgs e)
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(table);
        }

        // добавление букинга
        private void addbookB_Click(object sender, RoutedEventArgs e)
        {
            if (combo_Box1.Text.ToString() == "Booking")
            {
                using (Hotel24Entities1 db = new Hotel24Entities1())
                {
                    Booking c = new Booking();
                    c.ArrivalDate = new DateTime(2001, 01, 20);
                    c.ArrivalTime = new TimeSpan(12, 30, 0);
                    c.DepartureDate = new DateTime(2001, 01, 20);
                    c.DepartureTime = new TimeSpan(12, 30, 0);
                    c.CustomerId = db.Customers.Where(customer => customer.FirstName == "Peter" && customer.LastName == "Parker").FirstOrDefault().Id;
                    c.RoomId = db.Rooms.FirstOrDefault().Id;
                    db.Bookings.Add(c);
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Выберите таблицу Booking для изменения!");
            }
        }
        
        // вывод данных
        private void dispdataB_Click(object sender, RoutedEventArgs e)
        {
            tbOutput.Clear();
            if (combo_Box2.Text.ToString() == "Гости")
            {
                using (Hotel24Entities1 db = new Hotel24Entities1())
                {
                    var bookings = db.Bookings.Join(db.Customers,
                        booking => booking.CustomerId,
                        customer => customer.Id,
                        (booking, customer) => new
                        {
                            FirstName = customer.FirstName,
                            LastName = customer.LastName,
                            Phone = customer.Phone,
                            ArrivalDate = booking.ArrivalDate,
                            DepartureDate = booking.DepartureDate,
                        });
                    foreach (var b in bookings)
                        tbOutput.Text += string.Format("({0} {1}) Phone: {2} ArrivalDate: {3} DepartureDate: {4}\n------------\n",
                            b.FirstName, b.LastName, b.Phone,
                            b.ArrivalDate, b.DepartureDate);
                }
            }
            else if (combo_Box2.Text.ToString() == "Букинги")
            {
                tbOutput.Clear();
                using (Hotel24Entities1 db = new Hotel24Entities1())
                {
                    var bookings = from booking in db.Bookings
                        join customer in db.Customers on booking.CustomerId equals customer.Id
                        join room in db.Rooms on booking.RoomId equals room.Id
                        select new
                        {
                            Name = customer.FirstName,
                            Price = room.Price,
                            ArrivalDate = booking.ArrivalDate,
                            DepartureDate = booking.DepartureDate,
                        };
                    foreach (var b in bookings)
                        tbOutput.Text += string.Concat("Name: ", b.Name,
                            " \nPrice: ", b.Price,
                            " \nArrivalDate: ", b.ArrivalDate,
                            " \nDepartureDate: ", b.DepartureDate,
                            "\n-----------\n");
                }
            }

        }

        private void tbOutput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        // удаление букинга
        //private void delbookB_Click(object sender, RoutedEventArgs e)
        //{
        //    if (data_Grid.SelectedItems != null)
        //    {
        //        for(int i=0; i < data_Grid.SelectedItems.Count; i++)
        //        {
        //            DataRowView dataRowView = data_Grid.SelectedItems[i] as DataRowView;
        //            if (dataRowView != null)
        //            {
        //                DataRow data = (DataRow)dataRowView.Row;
        //                var index = data_Grid.SelectedIndex;
        //                data_Grid.Items.RemoveAt(index);
        //            }
        //        }
        //    }
        //if (combo_Box.Text.ToString() == "Booking")
        //{
        //    using (Hotel24Entities1 db = new Hotel24Entities1())
        //    {
        //        Booking p1 = db.Bookings.Where((customer) => customer.FirstName == "Peter" && customer.LastName == "Pen").FirstOrDefault();
        //        if (p1 != null)
        //        {
        //            db.Customers.Remove(p1);
        //            db.SaveChanges();
        //        }
        //    }
        //}
        //else
        //{
        //    MessageBox.Show("Выберите таблицу Booking для изменения!");
        //}
    }
}
