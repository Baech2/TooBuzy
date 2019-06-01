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
    /// Interaction logic for DeleteTable.xaml
    /// </summary>
    public partial class DeleteTable : Window
    {
        public DeleteTable()
        {
            InitializeComponent();
        }

        private void GetTableByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");
            try
            {
                if (!string.IsNullOrEmpty(txtTableId.Text))
                {

                    if (int.TryParse(txtTableId.Text, out int ParsedId))
                    {
                        Table table = proxy.GetTableById(ParsedId);

                        MessageBox.Show("Bord Nummer: " + table.TableNo.ToString() + "Forbruger Id:" + table.CustomerId);
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

        private void DeleteTableByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");
            try
            {
                if (!string.IsNullOrEmpty(txtTableId.Text))
                {

                    if (int.TryParse(txtTableId.Text, out int ParsedId))
                    {
                        proxy.DeleteTable(ParsedId);

                        MessageBox.Show("Bord med følgende id er blevet slettet: " + ParsedId, "Bord Slettet", MessageBoxButton.OK, MessageBoxImage.Warning);

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
