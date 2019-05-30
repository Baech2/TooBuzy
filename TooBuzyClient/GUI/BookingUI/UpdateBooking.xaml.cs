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

namespace TooBuzyClient.GUI.BookingUI
{
    /// <summary>
    /// Interaction logic for UpdateBooking.xaml
    /// </summary>
    public partial class UpdateBooking : Window
    {
        public UpdateBooking()
        {
            InitializeComponent();
        }

        private void UpdateBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");
            try
            {
                if (!string.IsNullOrEmpty(txtBookingId.Text) && !string.IsNullOrEmpty(txtConsumerId.Text) && !string.IsNullOrEmpty(txtTableId.Text) && !string.IsNullOrEmpty(MonthlyCalendar.SelectedDate.Value.ToString()))
                {
                    if (int.TryParse(txtBookingId.Text, out int ParsedBookingId) && int.TryParse(txtConsumerId.Text, out int ParsedConsumerId) && int.TryParse(txtTableId.Text, out int ParsedTableId))
                    {
                        Booking updateBooking = new Booking { Id = ParsedBookingId, ConsumerId = ParsedConsumerId, TableId = ParsedTableId, Date = MonthlyCalendar.SelectedDate.Value };
                        proxy.UpdateBooking(updateBooking);
                        MessageBox.Show("Booking er blevet opdateret", "Booking opdateret", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void MonthlyCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedDateTextBox.Text = MonthlyCalendar.SelectedDate.ToString();
        }
        private void MonthlyCalendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e) { }
        private void MonthlyCalendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e) { }

    }
}
