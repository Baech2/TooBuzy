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
using System.Windows.Shapes;
using TooBuzyEntities;
using TooBuzyClient;

namespace TooBuzyClient.GUI.ConsumerUI
{
    /// <summary>
    /// Interaction logic for CreateConsumer.xaml
    /// </summary>
    public partial class CreateConsumer : Window
    {
        public CreateConsumer()
        {
            InitializeComponent();
        }

        private async void CreateConsumerBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhoneNo.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    int ParsedPhoneNo = -1;
                    if (int.TryParse(txtPhoneNo.Text, out ParsedPhoneNo))
                    {
                        Consumer newConsumer = new Consumer { Name = txtName.Text, PhoneNo = ParsedPhoneNo, Password = txtPassword.Text };

                        await proxy.CreateConsumerAsync(newConsumer);
                        MessageBox.Show("Bruger er blevet oprettet", "Bruger oprettet", MessageBoxButton.OK, MessageBoxImage.Information);
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
                Visibility = Visibility.Collapsed;
            }
        }

        private void AnnullerBtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
