using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TooBuzyEntities;

namespace TooBuzyDataAccess.Interfaces
{
    public interface ICustomer
    {
        Customer GetByInt(int phone);
        bool Login(string Name, string Password);
    }
}
