using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TooBuzyEntities
{
    [DataContract]
    public class Consumer
    {
        public Consumer()
        {
            Bookings = new List<Booking>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int PhoneNo { get; set; }
        [DataMember]
        public List<Booking> Bookings { get; set; }

        public override string ToString()
        {
            return this.Name + "(" + PhoneNo + ")";
        }
    }
}
