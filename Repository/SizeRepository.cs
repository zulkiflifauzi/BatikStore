using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Interfaces;

namespace Repository
{
    public class SizeRepository : ISizeRepository
    {
        public List<Size> GetAll()
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Sizes.ToList();
            }
        }

        public void Add(Size entity)
        {
            using (var db = new BatikStoreEntities())
            {
                db.Sizes.AddObject(entity);
                db.SaveChanges();
            }
        }

        public void Update(Size entity)
        {
            using (var db = new BatikStoreEntities())
            {
                var existing = db.Sizes.SingleOrDefault(c => c.Id == entity.Id);
                if (existing != null)
                {
                    db.Sizes.ApplyCurrentValues(entity);
                    db.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var db = new BatikStoreEntities())
            {
                var existing = db.Sizes.SingleOrDefault(c => c.Id == id);
                if (existing != null)
                {
                    db.Sizes.DeleteObject(existing);
                    db.SaveChanges();
                }
            }
        }

        public Size GetSizeById(int id)
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Sizes.FirstOrDefault(c => c.Id == id);
            }
        }
    }
}
