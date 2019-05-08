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
        public bool Create(Order entity)
        {
            bool orderCreated = false;
            if (entity != null)
            {
               orderCreated = _OrderDb.Create(entity);
            }
            return orderCreated;
        }

        public bool Delete(int Id)
        {
            bool orderDelted = false;
            if (Id != 0)
            {
                orderDelted = _OrderDb.Delete(Id);
            }
            return orderDelted;
        }

        public IEnumerable<Order> GetAll()
        {
            return _OrderDb.GetAll();
        }

        public Order GetById(int Id)
        {
            return _OrderDb.GetById(Id);
        }

        public bool Update(Order entity)
        {
            bool orderUpdated = false;
            if (entity != null)
            {
                orderUpdated =_OrderDb.Update(entity);
            }
            return orderUpdated;
        }
    }
}
