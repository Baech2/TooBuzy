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
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string Desciption { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public int MenuId { get; set; }
        [DataMember]
        public Menu Menu { get; set; }
        [DataMember]
        public int OrderLineId { get; set; }
        [DataMember]
        public OrderLine OrderLine { get; set; }
    }
}
