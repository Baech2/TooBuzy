using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TooBuzyBusinessLogic.Interfaces;
using TooBuzyDataAccess;
using TooBuzyEntities;

namespace TooBuzyBusinessLogic
{
    public class CustomerContoller : ICRUD<Customer>
    {
        private CustomerDb _CustomerDb = new CustomerDb();
        public void Create(Customer entity)
        {
            if (entity != null)
            {
                _CustomerDb.Create(entity);
            }
        }

        public void Delete(int Id)
        {
            _CustomerDb.Delete(Id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _CustomerDb.GetAll();
        }

        public Customer GetById(int Id)
        {
            return _CustomerDb.GetById(Id);
        }

        public Customer GetByInt(int phone)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            if (entity != null)
            {
                _CustomerDb.Update(entity);
            }
        }
    }
}
