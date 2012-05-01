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
                return db.Products.ToList();
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

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
