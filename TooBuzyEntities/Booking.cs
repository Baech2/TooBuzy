﻿using System;
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
        public int TableId { get; set; }
        [DataMember]
        public Table Table { get; set; }

        public override string ToString()
        {
            return "(" + this.Id + ") ConsumerId:" + this.ConsumerId + ", TableId: " + this.TableId +", Time:"+this.Date.Hour+":"+this.Date.Minute+", Date: "+this.Date.Day+"/"+this.Date.Month;
        }
    }
}
