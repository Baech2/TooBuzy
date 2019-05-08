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
        public bool Create(Booking entity)
        {
            bool tt = false;
            if (entity != null)
            {
                tt = _BookingDb.Create(entity);
            }
            return tt;
        }

        public bool Delete(int Id)
        {
            bool bookingDeleted = false;
            if (Id != 0)
            {
                bookingDeleted = _BookingDb.Delete(Id);
            }
            return bookingDeleted;
        }

        public IEnumerable<Booking> GetAll()
        {
            return _BookingDb.GetAll();
        }

        public Booking GetById(int Id)
        {
            return _BookingDb.GetById(Id);
        }

        public bool Update(Booking entity)
        {
            bool bookingUpdated = false;
            if (entity != null)
            {
                bookingUpdated = _BookingDb.Update(entity);
            }
            return bookingUpdated;
        }
    }
}
