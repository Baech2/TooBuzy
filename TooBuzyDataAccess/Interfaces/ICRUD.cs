using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TooBuzyDataAccess.Interfaces
{
    interface ICRUD<T>
    {
        void Create(T entity);
        void Update(int Id);
        void Delete(int Id);
        T GetById(int Id);
        IEnumerable<T> GetAll();
        T GetByInt(int phone);
    }
}
