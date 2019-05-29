using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TooBuzyEntities;

namespace TooBuzyClient.GUI.TableUI
{
    /// <summary>
    /// Interaction logic for CreateTable.xaml
    /// </summary>
    public partial class CreateTable : Window
    {
        public CreateTable()
        {
            InitializeComponent();
        }

        private void CreateTableBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");

            try
            {
                if (!string.IsNullOrEmpty(txtNoOfSeats.Text) && !string.IsNullOrEmpty(txtTableNo.Text) && !string.IsNullOrEmpty(txtCustomerId.Text))
                {
                    if (int.TryParse(txtNoOfSeats.Text, out int parsedNoOfSeats) && int.TryParse(txtTableNo.Text, out int parsedTableNo) && int.TryParse(txtCustomerId.Text, out int parsedCustomerId))
                    {
                        Table newTable = new Table { NoOfSeats = parsedNoOfSeats, TableNo = parsedTableNo, CustomerId = parsedCustomerId };

                        proxy.CreateTable(newTable);
                        MessageBox.Show("Bordet er blevet oprettet", "Bord oprettet", MessageBoxButton.OK, MessageBoxImage.Information);
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
