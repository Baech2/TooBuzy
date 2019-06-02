using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace TooBuzyClient.GUI.CustomerUI
{
    /// <summary>
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : Window
    {
        public CreateCustomer()
        {
            InitializeComponent();
        }

        private void CreateCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");

            try
            {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtType.Text) && !string.IsNullOrEmpty(txtZipCode.Text) && !string.IsNullOrEmpty(txtAddress.Text) && !string.IsNullOrEmpty(txtPhoneNo.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    var hash = PasswordManager.Hash(txtPassword.Text);
                    if (int.TryParse(txtPhoneNo.Text, out int parsedPhoneNo) && int.TryParse(txtZipCode.Text, out int parsedZip))
                    {
                        Customer newCustomer = new Customer { Name = txtName.Text, Type = txtType.Text, ZipCode = parsedZip, Address = txtAddress.Text, PhoneNo = parsedPhoneNo, Logo = txtLogo.Text , Password = hash};
                        proxy.CreateCustomer(newCustomer);
                        MessageBox.Show("Kunden er blevet oprettet", "Kunde oprettet", MessageBoxButton.OK, MessageBoxImage.Information);
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
