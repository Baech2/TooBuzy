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
    public class MenuController : ICRUD<Menu>
    {
        private MenuDb _MenuDb = new MenuDb();

        public bool Create(Menu entity)
        {
            bool menuCreated = false;
            if (entity != null)
            {
                menuCreated = _MenuDb.Create(entity);
            }
            return menuCreated;
        }

        public bool Delete(int Id)
        {
            bool menuDelted = false;
            if (Id != 0)
            {
                menuDelted = _MenuDb.Delete(Id);
            }
            return menuDelted;
        }

        public IEnumerable<Menu> GetAll()
        {
            return _MenuDb.GetAll();
        }

        public Menu GetById(int Id)
        {
            return _MenuDb.GetById(Id);
        }

        public bool Update(Menu entity)
        {
            bool menuUpdated = false;
            if (entity != null)
            {
                menuUpdated = _MenuDb.Update(entity);
            }
            return menuUpdated;
        }
    }
}
