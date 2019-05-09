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

namespace TooBuzyClient.GUI.BookingUI
{
    /// <summary>
    /// Interaction logic for CreateBooking.xaml
    /// </summary>
    public partial class CreateBooking : Window
    {
        public CreateBooking()
        {
            InitializeComponent();
        }

        private void AnnullerBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateBookingBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MonthlyCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedDateTextBox.Text = MonthlyCalendar.SelectedDate.ToString();
        }
        private void MonthlyCalendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e) { }
        private void MonthlyCalendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e) { }
    }
}
