using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TooBuzyEntities
{
    [DataContract]
    public class Table
    {
        public Table()
        {
            Bookings = new List<Booking>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int TableNo { get; set; }
        [DataMember]
        public int NoOfSeats { get; set; }
        [DataMember]
        public IEnumerable<Booking> Bookings { get; set; }
        [DataMember]
        public Customer Customer { get; set; }
        [DataMember]
        public int CustomerId { get; set; }

        public override string ToString()
        {
            return "(" + this.Id + ") BordNr: "+ this.TableNo + "(Pladser:"+this.NoOfSeats +")";
        }
    }
}
