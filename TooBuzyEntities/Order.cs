﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TooBuzyEntities
{
    [DataContract]
    public class Order
    {
        public Order()
        {
            OrderLines = new List<OrderLine>();
            Createdate = DateTime.Now;
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public decimal TotalPrice { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int BookingId { get; set; }
        [DataMember]
        public Booking Booking{ get; set; }
        [DataMember]
        public DateTime Createdate { get; set; }
        [DataMember]
        public List<OrderLine> OrderLines { get; set; }

        public override string ToString()
        {
            return "(" + this.Id + ")" +this.TotalPrice +"("+this.BookingId+")";
        }
    }
}
