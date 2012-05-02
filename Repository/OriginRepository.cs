using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Interfaces;

namespace Repository
{
    public class OriginRepository : IOriginRepository
    {
        public List<Origin> GetAll()
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Origins.ToList();
            }
        }

        public void Add(Origin entity)
        {
            using (var db = new BatikStoreEntities())
            {
                db.Origins.AddObject(entity);
                db.SaveChanges();
            }
        }

        public void Update(Origin entity)
        {
            using (var db = new BatikStoreEntities())
            {
                var existing = db.Origins.SingleOrDefault(c => c.Id == entity.Id);
                if (existing != null)
                {
                    db.Origins.ApplyCurrentValues(entity);
                    db.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var db = new BatikStoreEntities())
            {
                var existing = db.Origins.SingleOrDefault(c => c.Id == id);
                if (existing != null)
                {
                    db.Origins.DeleteObject(existing);
                    db.SaveChanges();
                }
            }
        }

        public Origin GetOriginById(int id)
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Origins.FirstOrDefault(c => c.Id == id);
            }
        }
    }
}
