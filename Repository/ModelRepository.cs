using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Interfaces;

namespace Repository
{
    public class ModelRepository : IModelRepository
    {
        public List<Model> GetAll()
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Models.ToList();
            }
        }

        public void Add(Model entity)
        {
            using (var db = new BatikStoreEntities())
            {
                db.Models.AddObject(entity);
                db.SaveChanges();
            }
        }

        public void Update(Model entity)
        {
            using (var db = new BatikStoreEntities())
            {
                var existing = db.Models.SingleOrDefault(c => c.Id == entity.Id);
                if (existing != null)
                {
                    db.Models.ApplyCurrentValues(entity);
                    db.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var db = new BatikStoreEntities())
            {
                var existing = db.Models.SingleOrDefault(c => c.Id == id);
                if (existing != null)
                {
                    db.Models.DeleteObject(existing);
                    db.SaveChanges();
                }
            }
        }

        public Model GetModelById(int id)
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Models.FirstOrDefault(c => c.Id == id);
            }
        }
    }
}
