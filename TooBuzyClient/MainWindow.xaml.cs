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
using TooBuzyClient.GUI.BookingUI;
using TooBuzyClient.GUI.ConsumerUI;
using TooBuzyClient.GUI.CustomerUI;
using TooBuzyClient.GUI.MenuUI;
using TooBuzyClient.GUI.ProductUI;
using TooBuzyClient.GUI.TableUI;
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
        #region
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
            var newDeleteConsumerWindow = new DeleteConsumer();
            newDeleteConsumerWindow.ShowDialog();
        }
        private void GetConsumerByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtFindConsumerById.Text))
                {
                    int ParsedId;
                    if (int.TryParse(txtFindConsumerById.Text, out ParsedId))
                    {
                        Consumer consumer = proxy.GetConsumerById(ParsedId);

                        MessageBox.Show(consumer.Name);
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                proxy.Close();
            }
        }
        private void GetConsumerByPhoneBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtFindConsumerByPhone.Text))
                {
                    int ParsedPhoneNo;
                    if (int.TryParse(txtFindConsumerByPhone.Text, out ParsedPhoneNo))
                    {
                        Consumer consumer = proxy.GetByInt(ParsedPhoneNo);
                        MessageBox.Show("Name:" + consumer.Name + "   &     PhoneNumber:" + consumer.PhoneNo.ToString());

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                proxy.Close();
            }
        }
        public async void updateConsumerListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                var allConumsers = await proxy.GetAllAsync();
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
                proxy.Close();
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
        #endregion

        //Customer CRUD Controls
        #region
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
            var newDeleteCustomerWindow = new DeleteCustomer();
            newDeleteCustomerWindow.ShowDialog();
        }
        private void FindCustomerByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtFindCustyomerById.Text))
                {
                    int ParsedId;
                    if (int.TryParse(txtFindCustyomerById.Text, out ParsedId))
                    {
                        Customer customer= proxy.GetCustomerById(ParsedId);

                        MessageBox.Show(customer.Name);
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                proxy.Close();
            }
        }
        private void FindCustomerByPhoneBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtFindConsumerByPhone.Text))
                {
                    if (int.TryParse(txtFindConsumerByPhone.Text, out int ParsedPhoneNo))
                    {
                        Customer customer = proxy.GetCustomerByPhone(ParsedPhoneNo);
                        MessageBox.Show("Name:" + customer.Name + "   &     PhoneNumber:" + customer.PhoneNo.ToString());

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                proxy.Close();
            }
        }
        public async void updateCustomersListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                var allCustomers = await proxy.GetAllCustomersAsync();
                listBCustomers.Items.Clear();
                foreach (Customer customer in allCustomers)
                {
                    listBCustomers.Items.Add(customer);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                proxy.Close();
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
        #endregion

        //Order CRUD Controls
        #region
        private void CreateOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            //var newcreateorderwindow = new createorder();
            //newcreateorderwindow.showdialog();
        }
        private void UpdateOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            //var newUpdateOrderWindow = new UpdateOrder();
            //newUpdateOrderWindow.ShowDialog();
        }
        private void DeleteOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            //var newDeleteOrderWindow = new DeleteOrder();
            //newDeleteOrderWindow.ShowDialog();
        }
        private void getAllOrders_Click(object sender, RoutedEventArgs e)
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
        public async void updateOrdersListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                var allOrders = await proxy.GetAllOrdersAsync();
                listBOrders.Items.Clear();
                foreach (Order order in allOrders)
                {
                    listBOrders.Items.Add(order);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                proxy.Close();
            }
        }
        private void FindOrderByIdBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        //Product CRUD Controls
        #region
        private void CreateProductBtn_Click(object sender, RoutedEventArgs e)
        {
            var newCreateProductWindow = new CreateProduct();
            newCreateProductWindow.ShowDialog();
        }
        private void UpdateProductBtn_Click(object sender, RoutedEventArgs e)
        {
            var newUpdateProductWindow = new UpdateProduct();
            newUpdateProductWindow.ShowDialog();
        }
        private void DeleteProductBtn_Click(object sender, RoutedEventArgs e)
        {
            var newDeleteProductWindow = new DeleteProduct();
            newDeleteProductWindow.ShowDialog();
        }
        private void FindProductByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtFindProductById.Text))
                {
                    int ParsedId;
                    if (int.TryParse(txtFindProductById.Text, out ParsedId))
                    {
                        Product product = proxy.GetProductById(ParsedId);

                        MessageBox.Show(product.Name);
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                proxy.Close();
            }
        }
        public async void updateProductListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                var allProducts = await proxy.GetAllProductsAsync();
                listBProduct.Items.Clear();
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
                proxy.Close();
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
        #endregion

        //Menu CRUD Controls
        #region
        private void CreateMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            var newCreateMenuWindow = new CreateMenu();
            newCreateMenuWindow.ShowDialog();
        }
        private void UpdateMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            var newUpdateMenuWindow = new UpdateMenu();
            newUpdateMenuWindow.ShowDialog();
        }
        private void DeleteMenutBtn_Click(object sender, RoutedEventArgs e)
        {
            var newDeleteMenuWindow = new DeleteMenu();
            newDeleteMenuWindow.ShowDialog();
        }
        private void FindMenuByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtFindProductById.Text))
                {
                    int ParsedId;
                    if (int.TryParse(txtFindMenuById.Text, out ParsedId))
                    {
                        Menu menu = proxy.GetMenuById(ParsedId);

                        MessageBox.Show(menu.Name);
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                proxy.Close();
            }
        }
        public async void updateMenuListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                var allMenus = await proxy.GetAllMenusAsync();
                listBMenu.Items.Clear();
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
                proxy.Close();
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
        #endregion

        //Tables CRUD Controls
        #region
        private void CreateTableBtn_Click(object sender, RoutedEventArgs e)
        {
            var newCreateTableWindow = new CreateTable();
            newCreateTableWindow.ShowDialog();
        }

        private void UpdateTableBtn_Click(object sender, RoutedEventArgs e)
        {
            var newUpdateTableWindow = new UpdateTable();
            newUpdateTableWindow.ShowDialog();
        }

        private void DeleteTableBtn_Click(object sender, RoutedEventArgs e)
        {
            var newDeleteTableWindow = new DeleteTable();
            newDeleteTableWindow.ShowDialog();
        }

        private void FindTableByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtFindTableById.Text))
                {
                    int ParsedId;
                    if (int.TryParse(txtFindTableById.Text, out ParsedId))
                    {
                        Table table = proxy.GetTableById(ParsedId);

                        MessageBox.Show(table.Id.ToString() + " " + table.TableNo.ToString());
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                proxy.Close();
            }
        }

        public async void updateTableListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                var allTables = await proxy.GetAllTablesAsync();
                listBTable.Items.Clear();
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
                proxy.Close();
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
        #endregion

        //Bookings CRUD Controls
        #region
        private void CreateBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            var newCreateBookingWindow = new CreateBooking();
            newCreateBookingWindow.ShowDialog();
        }

        private void UpdateBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            var newUpdateBookingWindow = new UpdateBooking();
            newUpdateBookingWindow.ShowDialog();
        }

        private void DeleteBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            var newDeleteBookingWindow = new DeleteBooking();
            newDeleteBookingWindow.ShowDialog();
        }

        private void FindBookingByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtFindTableById.Text))
                {
                    if (int.TryParse(txtFindTableById.Text, out int ParsedId))
                    {
                        Booking booking = proxy.GetBookingById(ParsedId);

                        MessageBox.Show(booking.Id.ToString() + " " + booking.TableId.ToString());
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                proxy.Close();
            }
        }

        public async void updateBookingListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                var allBookings = await proxy.GetAllBookingsAsync();
                listBBooking.Items.Clear();
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
                proxy.Close();
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
        #endregion

    }
}