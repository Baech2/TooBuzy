using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TooBuzyEntities
{
    [DataContract]
    public class Product
    {
        public Product()
        {
            Orderlines = new List<OrderLine>();
            IsDeleted = false;
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public int Stock { get; set; }
        [DataMember]
        public int MenuId { get; set; }
        [DataMember]
        public Menu Menu { get; set; }
        [DataMember]
        public List<OrderLine> Orderlines { get; set; }

        public override string ToString()
        {
            return "("+this.Id+")"+ this.Name + "(" +this.Price+ ")";
        }
    }
}
