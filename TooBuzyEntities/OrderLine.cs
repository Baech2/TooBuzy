using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TooBuzyEntities
{
    [DataContract]
    public class OrderLine
    {
        public OrderLine()
        {
            Products = new List<Product>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public decimal SubTotal { get; set; }
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public Order Order { get; set; }
        [DataMember]
        public List<Product> Products { get; set; } 
    }
}
