using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TooBuzyWebClient.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int TableNo { get; set; }
        public int NoOfSeats { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}