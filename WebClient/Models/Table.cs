using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int TableNo { get; set; }
        public int NoOfSeats { get; set; }
        public Booking Booking { get; set; }
        public int? BookingId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}