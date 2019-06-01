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

namespace TooBuzyClient.GUI.ProductUI
{
    /// <summary>
    /// Interaction logic for DeleteProduct.xaml
    /// </summary>
    public partial class DeleteProduct : Window
    {
        public DeleteProduct()
        {
            InitializeComponent();
        }

        private void GetProductByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");
            try
            {
                if (!string.IsNullOrEmpty(txtProductId.Text))
                {

                    if (int.TryParse(txtProductId.Text, out int ParsedId))
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

        private void DeleteProductByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");
            try
            {
                if (!string.IsNullOrEmpty(txtProductId.Text))
                {

                    if (int.TryParse(txtProductId.Text, out int ParsedId))
                    {
                        proxy.DeleteProduct(ParsedId);

                        MessageBox.Show("Produkt med følgende id er blevet slettet: " + ParsedId, "Produkt Slettet", MessageBoxButton.OK, MessageBoxImage.Warning);

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
