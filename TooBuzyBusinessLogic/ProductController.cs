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
    public class ProductController : ICRUD<Product>
    {
        private ProductDb _ProductDb = new ProductDb();
        public void Create(Product entity)
        {
            if (entity != null)
            {
                _ProductDb.Create(entity);
            }
        }

        public void Delete(int Id)
        {
            _ProductDb.Delete(Id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _ProductDb.GetAll();
        }

        public Product GetById(int Id)
        {
            return _ProductDb.GetById(Id);
        }

        public Product GetByInt(int phone)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            if (entity != null)
            {
                _ProductDb.Update(entity);
            }
        }
    }
}
