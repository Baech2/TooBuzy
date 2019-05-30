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
    /// Interaction logic for DeleteConsumer.xaml
    /// </summary>
    public partial class DeleteConsumer : Window
    {
        public DeleteConsumer()
        {
            InitializeComponent();
        }

        private void AnnullerBtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private async void GetConsumerByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");
            try
            {
                if (!string.IsNullOrEmpty(txtConsumerId.Text))
                {
                    int ParsedId;
                    if (int.TryParse(txtConsumerId.Text, out ParsedId))
                    {
                        Consumer consumer = await proxy.GetConsumerByIdAsync(ParsedId);

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

        private async void DeleteConsumerByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");
            try
            {
                if (!string.IsNullOrEmpty(txtConsumerId.Text))
                {
                    int ParsedId;
                    if (int.TryParse(txtConsumerId.Text, out ParsedId))
                    {
                        await proxy.DeleteConsumerAsync(ParsedId);

                        MessageBox.Show("Forbruger med følgende id er blevet slettet: " + ParsedId, "Forbruger Slettet", MessageBoxButton.OK, MessageBoxImage.Warning);

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
    }
}
