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
    public class BookingController : ICRUD<Booking>
    {
        private BookingDb _BookingDb = new BookingDb();
        public void Create(Booking entity)
        {
            if (entity != null)
            {
                _BookingDb.Create(entity);
            }
        }

        public void Delete(int Id)
        {
            _BookingDb.Delete(Id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return _BookingDb.GetAll();
        }

        public Booking GetById(int Id)
        {
            return _BookingDb.GetById(Id);
        }

        public Booking GetByInt(int phone)
        {
            throw new NotImplementedException();
        }

        public void Update(Booking entity)
        {
            if (entity != null)
            {
                _BookingDb.Update(entity);
            }
        }
    }
}
