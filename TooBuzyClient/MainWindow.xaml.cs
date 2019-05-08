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
using TooBuzyClient.GUI.ConsumerUI;
using TooBuzyClient.GUI.CustomerUI;
using TooBuzyEntities;
using Menu = TooBuzyEntities.Menu;
using Table = TooBuzyEntities.Table;

namespace TooBuzyClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            updateConsumerListBox();
            updateCustomersListBox();
            updateOrdersListBox();
            updateProductListBox();
            updateMenuListBox();
            updateTableListBox();
            updateBookingListBox();
        }
        //Consumer CRUD controls
        private void CreateConsumerBtn_Click(object sender, RoutedEventArgs e)
        {
            var newCreateConsumerWindow = new CreateConsumer();
            newCreateConsumerWindow.ShowDialog();
        }
        private void UpdateConsumerBtn_Click(object sender, RoutedEventArgs e)
        {
            var newUpdateConsumerWindow = new UpdateConsumer();
            newUpdateConsumerWindow.ShowDialog();
        }
        private void DeleteConsumerBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void GetConsumerByIdBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void GetConsumerByPhoneBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        public async void updateConsumerListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                var allConumsers = await client.GetAllAsync();
                listBConsumers.Items.Clear();
                foreach (Consumer consumer in allConumsers)
                {
                    listBConsumers.Items.Add(consumer);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
        private void getAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                updateConsumerListBox();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }

        }

        //Customer CRUD Controls
        private void CreateCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            var newCreateCustomerWindow = new CreateCustomer();
            newCreateCustomerWindow.ShowDialog();
        }
        private void UpdateCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            var newUpdateCustomerWindow = new UpdateCustomer();
            newUpdateCustomerWindow.ShowDialog();
        }
        private void DeleteCustomerBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void FindCustomerByIdBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void FindCustomerByPhoneBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        public async void updateCustomersListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                var allCustomers = await client.GetAllCustomersAsync();
                listBCustomers.Items.Clear();
                foreach (Customer customer in allCustomers)
                {
                    listBConsumers.Items.Add(customer);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
        private void getAllCustomers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                updateCustomersListBox();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
        }

        //Order CRUD Controls
        private void CreateOrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateOrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteOrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void getAllOrders_Click(object sender, RoutedEventArgs e)
        {

        }
        public async void updateOrdersListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                var allOrders = await client.GetAllOrdersAsync();
                listBOrders.Items.Clear();
                foreach (Order order in allOrders)
                {
                    listBConsumers.Items.Add(order);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
        private void FindOrderByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                updateOrdersListBox();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
        }


        //Product CRUD Controls
        private void CreateProductBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateProductBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteProductBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void FindProductByIdBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        public async void updateProductListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                var allProducts = await client.GetAllProductsAsync();
                listBConsumers.Items.Clear();
                foreach (Product product in allProducts)
                {
                    listBProduct.Items.Add(product);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

        private void getAllProducts_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                updateProductListBox();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
        }

        //Menu CRUD Controls
        private void CreateMenuBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateMenuBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteMenutBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void FindMenuByIdBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        public async void updateMenuListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                var allMenus = await client.GetAllMenusAsync();
                listBConsumers.Items.Clear();
                foreach (Menu menu in allMenus)
                {
                    listBMenu.Items.Add(menu);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

        private void getAllMenus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                updateMenuListBox();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
        }
        

        //Tables CRUD Controls
        private void CreateTableBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateTableBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteTableBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindTableByIdBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        public async void updateTableListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                var allTables = await client.GetAllTablesAsync();
                listBConsumers.Items.Clear();
                foreach (Table table in allTables)
                {
                    listBTable.Items.Add(table);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                client.Close();
            }
        }


        private void getAllTables_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                updateTableListBox();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
        }


        //Bookings CRUD Controls
        private void CreateBookingBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateBookingBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBookingBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindBookingByIdBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        public async void updateBookingListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                var allBookings = await client.GetAllBookingsAsync();
                listBConsumers.Items.Clear();
                foreach (Booking booking in allBookings)
                {
                    listBBooking.Items.Add(booking);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                client.Close();
            }
        }


        private void getAllBookings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                updateBookingListBox();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
        }
    }
}