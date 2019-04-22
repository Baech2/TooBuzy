using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TooBuzyEntities
{
    [DataContract]
    public class Booking
    {
        public Booking()
        {
            Tables = new List<Table>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int ConsumerId { get; set; }
        [DataMember]
        public Consumer Consumer { get; set; }
        [DataMember]
        public List<Table> Tables { get; set; }
    }
}
