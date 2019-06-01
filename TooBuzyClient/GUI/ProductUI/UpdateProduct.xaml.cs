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
    /// Interaction logic for UpdateProduct.xaml
    /// </summary>
    public partial class UpdateProduct : Window
    {
        public UpdateProduct()
        {
            InitializeComponent();
        }

        private void AnnullerBtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void UpdateProductBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");

            try
            {
                if (!string.IsNullOrEmpty(txtProductName.Text) && !string.IsNullOrEmpty(txtDescription.Text) && !string.IsNullOrEmpty(txtPrice.Text) && !string.IsNullOrEmpty(txtStock.Text) && !string.IsNullOrEmpty(txtMenuId.Text) && !string.IsNullOrEmpty(txtProductId.Text))
                {
                    if (decimal.TryParse(txtPrice.Text, out decimal parsedPrice) && int.TryParse(txtStock.Text, out int parsedStock) && int.TryParse(txtMenuId.Text, out int parsedMenuId) && int.TryParse(txtProductId.Text, out int parsedProductId))
                    {
                        Product updateProduct = new Product { Id = parsedProductId, Name = txtProductName.Text, Description = txtDescription.Text, Price = parsedPrice, ImageUrl = txtImageUrl.Text, Stock = parsedStock, MenuId = parsedMenuId, IsDeleted = false };

                        proxy.UpdateProduct(updateProduct);
                        MessageBox.Show("Produktet er blevet opdateret", "Produkt opdateret", MessageBoxButton.OK, MessageBoxImage.Information);
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
