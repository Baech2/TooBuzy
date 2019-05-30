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

namespace TooBuzyClient.GUI.ConsumerUI
{
    /// <summary>
    /// Interaction logic for UpdateConsumer.xaml
    /// </summary>
    public partial class UpdateConsumer : Window
    {
        public UpdateConsumer()
        {
            InitializeComponent();
        }

        private void UpdateConsumerBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhoneNo.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    
                    int PhoneNoUpdate;
                    if (int.TryParse(txtPhoneNo.Text, out PhoneNoUpdate))
                    {
                        Consumer UpdateConsumer = new Consumer {Name = txtName.Text, PhoneNo = PhoneNoUpdate, Password = txtPassword.Text };
                        client.UpdateConsumer(UpdateConsumer);
                        MessageBox.Show("Bruger er blevet opdateret", "Bruger opdateret", MessageBoxButton.OK, MessageBoxImage.Information);
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
                Visibility = Visibility.Collapsed;
            }
        }

        private void AnnullerBtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
