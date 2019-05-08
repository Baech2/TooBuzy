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
        public bool Create(Customer entity)
        {
            bool customerCreated = false;
            if (entity != null)
            {
                customerCreated = _CustomerDb.Create(entity);
            }
            return customerCreated;
        }

        public bool Delete(int Id)
        {
            bool customerDelted = false;
            if (Id <= 0 )
            {
                customerDelted = _CustomerDb.Delete(Id);
            }
            return customerDelted;
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

        public bool Update(Customer entity)
        {
            bool customerUpdated = false;
            if (entity != null)
            {
                customerUpdated = _CustomerDb.Update(entity);
            }
            return customerUpdated;
        }
    }
}
