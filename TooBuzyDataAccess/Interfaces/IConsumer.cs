using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TooBuzyEntities;

namespace TooBuzyDataAccess.Interfaces
{
    interface IConsumer
    {
        Consumer GetByInt(int phone);
        bool Login(string Name, string Password);
    }
}
