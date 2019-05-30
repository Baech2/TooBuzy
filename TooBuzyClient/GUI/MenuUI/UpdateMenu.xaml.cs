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
    /// Interaction logic for UpdateMenu.xaml
    /// </summary>
    public partial class UpdateMenu : Window
    {
        public UpdateMenu()
        {
            InitializeComponent();
        }

        private void UpdateMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");

            try
            {
                if (!string.IsNullOrEmpty(txtCategory.Text) && !string.IsNullOrEmpty(txtDescription.Text) && !string.IsNullOrEmpty(txtName.Text))
                {
                    Menu newMenu = new Menu { Name = txtName.Text, Category = txtCategory.Text, Description = txtDescription.Text };

                    proxy.UpdateMenu(newMenu);
                    MessageBox.Show("En Menu er blevet opdateret", "Menu opdateret", MessageBoxButton.OK, MessageBoxImage.Information);
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
