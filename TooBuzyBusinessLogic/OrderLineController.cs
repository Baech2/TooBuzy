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
        public void Create(OrderLine entity)
        {
            if (entity != null)
            {
                _OrderLineDb.Create(entity);
            }
        }

        public void Delete(int Id)
        {
            _OrderLineDb.Delete(Id);
        }

        public IEnumerable<OrderLine> GetAll()
        {
            return _OrderLineDb.GetAll();
        }

        public OrderLine GetById(int Id)
        {
            return _OrderLineDb.GetById(Id);
        }

        public OrderLine GetByInt(int phone)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderLine entity)
        {
            if (entity != null)
            {
                _OrderLineDb.Update(entity);
            }
        }
    }
}
