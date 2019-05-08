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
        public bool Create(Product entity)
        {
            bool productCreated = false;
            if (entity != null)
            {
                productCreated = _ProductDb.Create(entity);
            }
            return productCreated;
        }

        public bool Delete(int Id)
        {
            bool productDeleted = false;
            if (Id != 0)
            {
                productDeleted = _ProductDb.Delete(Id);
            }
            return productDeleted;
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

        public bool Update(Product entity)
        {
            bool productUpdated = false;
            if (entity != null)
            {
                productUpdated = _ProductDb.Update(entity);
            }
            return productUpdated;
        }
    }
}
