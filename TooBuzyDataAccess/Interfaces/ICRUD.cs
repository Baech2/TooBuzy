using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TooBuzyDataAccess.Interfaces
{
    interface ICRUD<T>
    {
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int Id);
        T GetById(int Id);
        IEnumerable<T> GetAll();
    }
}
