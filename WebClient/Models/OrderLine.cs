﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}