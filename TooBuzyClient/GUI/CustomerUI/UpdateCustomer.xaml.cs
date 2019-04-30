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

namespace TooBuzyClient.GUI.CustomerUI
{
    /// <summary>
    /// Interaction logic for UpdateCustomer.xaml
    /// </summary>
    public partial class UpdateCustomer : Window
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private async void UpdateCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("NetTcpBinding_ITooBuzyService");

            try
            {
                int parsedPhoneNo;
                int parsedZip;
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtType.Text) && !string.IsNullOrEmpty(txtZipCode.Text) && !string.IsNullOrEmpty(txtAddress.Text) && !string.IsNullOrEmpty(txtPhoneNo.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    if (int.TryParse(txtPhoneNo.Text, out parsedPhoneNo) && int.TryParse(txtZipCode.Text,out parsedZip))
                    {
                        Customer updateCustomer = new Customer { Name = txtName.Text, Type = txtType.Text, ZipCode = parsedZip, Address = txtAddress.Text, PhoneNo = parsedPhoneNo, Password = txtPassword.Text };
                        //await proxy.UpdateCustomerAsync(updateCustomer);
                        //Metodes mangler i service contract. fix!
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
    }
}
