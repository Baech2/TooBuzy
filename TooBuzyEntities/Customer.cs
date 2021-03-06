﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TooBuzyEntities
{
    [DataContract]
    public class Customer
    {
        public Customer()
        {
            Tables = new List<Table>();
            Createdate = DateTime.Now;
            MenuId = 1;
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int ZipCode { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int PhoneNo { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public List<Table> Tables { get; set; }
        [DataMember]
        public DateTime Createdate { get; set; }
        [DataMember]
        public int? MenuId { get; set; }
        [DataMember]
        public Menu menu { get; set; }

        public override string ToString()
        {
            return "("+this.Id+")" + this.Name + ","+ this.Address +"," + this.ZipCode;
        }
    }
}
