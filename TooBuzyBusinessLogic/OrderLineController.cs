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
    public class OrderLineController : ICRUD<OrderLine>
    {
        private OrderLineDb _OrderLineDb = new OrderLineDb();

        public bool Create(OrderLine entity)
        {
            bool orderlineCreated = false;
            if (entity != null)
            {
                orderlineCreated = _OrderLineDb.Create(entity);
            }
            return orderlineCreated;
        }

        public bool Delete(int Id)
        {
            bool orderlineDeleted = false;
            if (Id != 0)
            {
                orderlineDeleted = _OrderLineDb.Delete(Id);
            }
            return orderlineDeleted;
        }

        public IEnumerable<OrderLine> GetAll()
        {
            return _OrderLineDb.GetAll();
        }

        public OrderLine GetById(int Id)
        {
            return _OrderLineDb.GetById(Id);
        }

        public bool Update(OrderLine entity)
        {
            bool orderlineUpdated = false;
            if (entity != null)
            {
                orderlineUpdated = _OrderLineDb.Update(entity);
            }
            return orderlineUpdated;
        }

    }
}
