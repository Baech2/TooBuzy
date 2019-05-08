using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class Order
    {
        public Order()
        {
            OrderLines = new List<OrderLine>();
        }
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}