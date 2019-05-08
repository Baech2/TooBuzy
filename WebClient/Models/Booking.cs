using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class Booking
    {
        public Booking()
        {
            Tables = new List<Table>();
        }
        
        public int Id { get; set; }
       
        public DateTime Date { get; set; }
        
        public int ConsumerId { get; set; }
        
        public Consumer Consumer { get; set; }
        
        public List<Table> Tables { get; set; }
    }
}