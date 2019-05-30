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
using Table = TooBuzyEntities.Table;


namespace TooBuzyClient.GUI.TableUI
{
    /// <summary>
    /// Interaction logic for UpdateTable.xaml
    /// </summary>
    public partial class UpdateTable : Window
    {
        public UpdateTable()
        {
            InitializeComponent();
        }

        private void UpdateTableBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");

            try
            {
                if (!string.IsNullOrEmpty(txtNoOfSeats.Text) && !string.IsNullOrEmpty(txtTableNo.Text) && !string.IsNullOrEmpty(txtCustomerId.Text) && !string.IsNullOrEmpty(txtTableId.Text))
                {
                    if (int.TryParse(txtNoOfSeats.Text, out int parsedNoOfSeats) && int.TryParse(txtTableNo.Text, out int parsedTableNo) && int.TryParse(txtCustomerId.Text, out int parsedCustomerId) && int.TryParse(txtTableId.Text, out int ParsedTableId))
                    {
                        Table updateTable = new Table { NoOfSeats = parsedNoOfSeats, TableNo = parsedTableNo, CustomerId = parsedCustomerId, Id = ParsedTableId };

                        proxy.UpdateTable(updateTable);
                        MessageBox.Show("Bordet er blevet opdateret", "Bord opdateret", MessageBoxButton.OK, MessageBoxImage.Information);
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
