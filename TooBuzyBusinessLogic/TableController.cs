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
        public bool Create(Table entity)
        {
            bool tableCreated = false;
            if (entity != null)
            {
                tableCreated = _TableDb.Create(entity);
            }
            return tableCreated;
        }

        public bool Delete(int Id)
        {
            bool tableDelted = false;
            if (Id != 0)
            {
                tableDelted =_TableDb.Delete(Id);
            }
            return tableDelted;
        }

        public IEnumerable<Table> GetAll()
        {
            return _TableDb.GetAll();
        }

        public Table GetById(int Id)
        {
            return _TableDb.GetById(Id);
        }

        public bool Update(Table entity)
        {
            bool tableUpdated = false;
            if (entity != null)
            {
                tableUpdated = _TableDb.Update(entity);
            }
            return tableUpdated;
        }
    }
}
