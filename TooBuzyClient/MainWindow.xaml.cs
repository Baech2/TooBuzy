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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TooBuzyBusinessLogic;
using TooBuzyEntities;

namespace TooBuzyClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void getAll_Click(object sender, RoutedEventArgs e)
        {
            updateConsumerListBox();
        }
        public void updateConsumerListBox()
        {
           TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");
            var allConumsers = client.GetAll();
            listBConsumers.Items.Clear();
            foreach (Consumer consumer in allConumsers)
            {
                listBConsumers.Items.Add(consumer);
            }
            
        }

        private void InsertConsumer_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhoneNo.Text))
            {
                int ParsedPhoneNo = -1;
                if (int.TryParse(txtPhoneNo.Text, out ParsedPhoneNo))
                {
                    Consumer newConsumer = new Consumer { Name = txtName.Text, PhoneNo = ParsedPhoneNo };

                    client.CreateConsumer(newConsumer);
                    updateConsumerListBox();
                    MessageBox.Show("Name:" + newConsumer.Name + "& PhoneNumber:" + newConsumer.PhoneNo.ToString());
                }

            }
        }

        private void btnFindConsumer_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");
            if (!string.IsNullOrEmpty(txtPhoneNo_Copy.Text))
            {
                int ParsedPhoneNo;
                if (int.TryParse(txtPhoneNo_Copy.Text, out ParsedPhoneNo))
                {
                    Consumer consumer = client.GetByInt(ParsedPhoneNo);
                    MessageBox.Show("Name:" + consumer.Name + "   &     PhoneNumber:" + consumer.PhoneNo.ToString());

                }

            }
        }

        private void btnFindConsumerById_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient client = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");
            if (!string.IsNullOrEmpty(txtGetById.Text))
            {
                int ParsedId;
                if (int.TryParse(txtGetById.Text, out ParsedId))
                {
                    Consumer consumer = client.GetConsumerById(ParsedId);

                    MessageBox.Show(consumer.Name);
                }

            }


        }
    }
}