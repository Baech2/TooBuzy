using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TooBuzyWebClient.Models
{
    public class Customer
    {
        public Customer()
        {
            Tables = new List<Table>();
            Createdate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int ZipCode { get; set; }
        public string Address { get; set; }
        public int PhoneNo { get; set; }
        public string Password { get; set; }
        public List<Table> Tables { get; set; }
        public DateTime Createdate { get; set; }
    }
}