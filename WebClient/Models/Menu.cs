using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class Menu
    {
        public Menu()
        {
            Products = new List<Product>();

        }
        public int Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}