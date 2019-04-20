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
using TooBuzyEntities;

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
        public async void updateConsumerListBox()
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");
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

        private void InsertConsumer_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhoneNo.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    int ParsedPhoneNo = -1;
                    if (int.TryParse(txtPhoneNo.Text, out ParsedPhoneNo))
                    {
                        Consumer newConsumer = new Consumer { Name = txtName.Text, PhoneNo = ParsedPhoneNo, Password = txtPassword.Text };

                        client.CreateConsumer(newConsumer);
                        updateConsumerListBox();
                        MessageBox.Show("Name:" + newConsumer.Name + "& PhoneNumber:" + newConsumer.PhoneNo.ToString());
                    }

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

        private void btnFindConsumer_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtPhoneNo_Copy.Text))
                {
                    int ParsedPhoneNo;
                    if (int.TryParse(txtPhoneNo_Copy.Text, out ParsedPhoneNo))
                    {
                        Consumer consumer = client.GetByInt(ParsedPhoneNo);
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
                client.Close();
            }

        }

        private void btnFindConsumerById_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtGetById.Text))
                {
                    int ParsedId;
                    if (int.TryParse(txtGetById.Text, out ParsedId))
                    {
                        Consumer consumer = client.GetConsumerById(ParsedId);

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
                client.Close();
            }
        }

        private void btnConsumerUpdate_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtNameUpdate.Text) && !string.IsNullOrEmpty(txtPhoneNoUpdate.Text) && !string.IsNullOrEmpty(txtPasswordUpdate.Text))
                {
                    int ParsedId;
                    int PhoneNoUpdate;
                    if (int.TryParse(txtIdUpdate.Text, out ParsedId) && int.TryParse(txtPhoneNoUpdate.Text, out PhoneNoUpdate))
                    {
                        Consumer UpdateConsumer = new Consumer { Id = ParsedId, Name = txtNameUpdate.Text, PhoneNo = PhoneNoUpdate, Password = txtPasswordUpdate.Text };
                        client.UpdateConsumer(UpdateConsumer);
                        updateConsumerListBox();

                    }
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
    }
}