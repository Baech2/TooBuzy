using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TooBuzyWebClient.Models
{
    public class Consumer
    {
        public Consumer()
        {
            Bookings = new List<Booking>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNo { get; set; }
        public List<Booking> Bookings { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return this.Name + "(" + PhoneNo + ")";
        }
    }
}