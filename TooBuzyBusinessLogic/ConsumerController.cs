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
    public class ConsumerController  /*ICRUD<Consumer>*/
    {
        private ConsumerDb _ConsumerDb = new ConsumerDb();
        public bool Create(Consumer entity)
        {
            bool tt = false;
            if (entity != null)
            {
                tt = _ConsumerDb.Create(entity);
            }
            return tt;
        }

        public void Delete(int Id)
        {
            if (Id != 0)
            {
                _ConsumerDb.Delete(Id);
            }
        }

        public IEnumerable<Consumer> GetAll()
        {
            return _ConsumerDb.GetAll();
        }

        public Consumer GetById(int Id)
        {
            if (Id != 0)
            {
                return _ConsumerDb.GetById(Id);
            }
            else
            {
                throw new Exception("Id is invalid");
            }
        }

        public Consumer GetByInt(int phone)
        {
            if (phone.ToString().Length >= 8)
            {
                return _ConsumerDb.GetByInt(phone);
            }
            else
            {
                throw new Exception("Phone Number is invalid");
            }
        }

        public bool Update(Consumer entity)
        {
            bool tt = false;
            if (entity != null)
            {
                tt = _ConsumerDb.Update(entity);
                return tt;
            }
            return tt;
        }
    }
}
