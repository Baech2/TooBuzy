using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TooBuzyWebClient.Models
{
    public class Booking
    {
        public Booking()
        {

        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ConsumerId { get; set; }
        public Consumer Consumer { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}