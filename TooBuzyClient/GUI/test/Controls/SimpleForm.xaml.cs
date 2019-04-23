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

namespace TooBuzyClient.GUI.test.Controls
{
    /// <summary>
    /// Interaction logic for SimpleForm.xaml
    /// </summary>
    public partial class SimpleForm : Window
    {
        public SimpleForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Full Name :");
            sb.Append(FullName.Text);
            sb.Append("Sex?");
            sb.Append((bool)Male.IsChecked ? "Male" : "Female");
            sb.Append("Computer: ");
            sb.Append((bool)Desktop.IsChecked ? "Desktop" : "");
            sb.Append((bool)Laptop.IsChecked ? "Laptop" : "");
            sb.Append((bool)Tablet.IsChecked ? "Tablet" : "");
            sb.Append(Job.SelectedItem.ToString());
            sb.Append("Delivery Date:");
            sb.Append(DeliveryDate.SelectedDate.ToString());
            MessageBox.Show(sb.ToString());
        }

        private void Job_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var newlySelectedItem = e.AddedItems[0];
            MessageBox.Show(newlySelectedItem.ToString());
        }
    }
}
