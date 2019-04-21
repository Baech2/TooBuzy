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
        public void Create(Menu entity)
        {
            if (entity != null)
            {
                _MenuDb.Create(entity);
            }
        }

        public void Delete(int Id)
        {
            _MenuDb.Delete(Id);
        }

        public IEnumerable<Menu> GetAll()
        {
            return _MenuDb.GetAll();
        }

        public Menu GetById(int Id)
        {
            return _MenuDb.GetById(Id);
        }

        public Menu GetByInt(int phone)
        {
            throw new NotImplementedException();
        }

        public void Update(Menu entity)
        {
            if (entity != null)
            {
                _MenuDb.Update(entity);
            }
        }
    }
}
