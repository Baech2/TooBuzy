using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TooBuzyBusinessLogic.Interfaces;
using TooBuzyDataAccess;
using TooBuzyDataAccess.Interfaces;
using TooBuzyEntities;

namespace TooBuzyBusinessLogic
{
    public class ConsumerController : ICRUD<Consumer>
    {
        private ConsumerDb _ConsumerDb = new ConsumerDb();
        public void Create(Consumer entity)
        {
            if (entity != null)
            {
                _ConsumerDb.Create(entity);
            }
        }

        public void Delete(int Id)
        {
            _ConsumerDb.Delete(Id);
        }

        public IEnumerable<Consumer> GetAll()
        {
            return _ConsumerDb.GetAll();
        }

        public Consumer GetById(int Id)
        {
            return _ConsumerDb.GetById(Id);
        }

        public Consumer GetByInt(int phone)
        {
            return _ConsumerDb.GetByInt(phone);
        }

        public void Update(Consumer entity)
        {
            if (entity != null)
            {
                _ConsumerDb.Update(entity);
            }
        }
    }
}
