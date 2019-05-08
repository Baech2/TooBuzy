using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TooBuzyEntities
{
    [DataContract]
    public class Menu
    {
        public Menu()
        {
            Products = new List<Product>();
            
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public List<Product> Products { get; set; }
    }
}
