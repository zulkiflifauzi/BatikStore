using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Interfaces;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAll()
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Products.Include("Model").ToList();
            }
        }

        public bool IsModelAlreadyUsed(int modelId)
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Products.Any(c => c.Model_ModelId == modelId);
            }
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
