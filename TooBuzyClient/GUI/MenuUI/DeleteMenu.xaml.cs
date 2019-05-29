using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TooBuzyEntities;

namespace TooBuzyClient.GUI.MenuUI
{
    /// <summary>
    /// Interaction logic for DeleteMenu.xaml
    /// </summary>
    public partial class DeleteMenu : Window
    {
        public DeleteMenu()
        {
            InitializeComponent();
        }

        private void GetMenuByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtMenuId.Text))
                {
                    
                    if (int.TryParse(txtMenuId.Text, out int ParsedId))
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

        private void DeleteMenuByIdBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");
            try
            {
                if (!string.IsNullOrEmpty(txtMenuId.Text))
                {
                    
                    if (int.TryParse(txtMenuId.Text, out int ParsedId))
                    {
                        proxy.DeleteCustomer(ParsedId);

                        MessageBox.Show("Menu med følgende id er blevet slettet: " + ParsedId, "Menu Slettet", MessageBoxButton.OK, MessageBoxImage.Warning);

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
