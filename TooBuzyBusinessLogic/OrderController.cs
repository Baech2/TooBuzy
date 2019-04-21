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
    public class OrderController : ICRUD<Order>
    {
        private OrderDb _OrderDb = new OrderDb();
        public void Create(Order entity)
        {
            if (entity != null)
            {
                _OrderDb.Create(entity);
            }
        }

        public void Delete(int Id)
        {
            _OrderDb.Delete(Id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _OrderDb.GetAll();
        }

        public Order GetById(int Id)
        {
            return _OrderDb.GetById(Id);
        }

        public Order GetByInt(int phone)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            if (entity != null)
            {
                _OrderDb.Update(entity);
            }
        }
    }
}
