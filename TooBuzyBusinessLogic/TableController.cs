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
    public class TableController : ICRUD<Table>
    {
        private TableDb _TableDb = new TableDb();
        public void Create(Table entity)
        {
            if (entity != null)
            {
                _TableDb.Create(entity);
            }
        }

        public void Delete(int Id)
        {
            _TableDb.Delete(Id);
        }

        public IEnumerable<Table> GetAll()
        {
            return _TableDb.GetAll();
        }

        public Table GetById(int Id)
        {
            return _TableDb.GetById(Id);
        }

        public Table GetByInt(int phone)
        {
            throw new NotImplementedException();
        }

        public void Update(Table entity)
        {
            if (entity != null)
            {
                _TableDb.Update(entity);
            }
        }
    }
}
