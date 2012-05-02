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
                return db.Products.Include("Model").Include("Size").Include("Type").Include("Origin").ToList();
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
            using (var db = new BatikStoreEntities())
            {
                db.Products.AddObject(entity);
                db.SaveChanges();
            }
        }

        public void Update(Product entity)
        {
            using (var db = new BatikStoreEntities())
            {
                var existing = db.Products.SingleOrDefault(c => c.Id == entity.Id);
                if (existing != null)
                {
                    db.Products.ApplyCurrentValues(entity);
                    db.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsOriginAlreadyUsed(int originId)
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Products.Any(c => c.Origin_OriginId == originId);
            }
        }


        public bool IsTypeAlreadyUsed(int typeId)
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Products.Any(c => c.Type_TypeId == typeId);
            }
        }


        public bool IsSizeAlreadyUsed(int sizeId)
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Products.Any(c => c.Size_SizeId == sizeId);
            }
        }


        public Product GetByNumber(string number)
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Products.Include("Model").Include("Size").Include("Type").Include("Origin").SingleOrDefault(c => c.Number.Equals(number));
            }
        }


        public Product GetById(int Id)
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Products.Include("Model").Include("Size").Include("Type").Include("Origin").SingleOrDefault(c => c.Id == Id);
            }
        }
    }
}
