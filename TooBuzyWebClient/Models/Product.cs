using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TooBuzyWebClient.Models
{
    public class Product
    {
        public Product()
        {
            Orderlines = new List<OrderLine>();
        }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Desciption { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        public int Stock { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public List<OrderLine> Orderlines { get; set; }

    }
}