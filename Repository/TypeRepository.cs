using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Interfaces;

namespace Repository
{
    public class TypeRepository : ITypeRepository
    {
        public List<Type> GetAll()
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Types.ToList();
            }
        }

        public void Add(Type entity)
        {
            using (var db = new BatikStoreEntities())
            {
                db.Types.AddObject(entity);
                db.SaveChanges();
            }
        }

        public void Update(Type entity)
        {
            using (var db = new BatikStoreEntities())
            {
                var existing = db.Types.SingleOrDefault(c => c.Id == entity.Id);
                if (existing != null)
                {
                    db.Types.ApplyCurrentValues(entity);
                    db.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var db = new BatikStoreEntities())
            {
                var existing = db.Types.SingleOrDefault(c => c.Id == id);
                if (existing != null)
                {
                    db.Types.DeleteObject(existing);
                    db.SaveChanges();
                }
            }
        }

        public Type GetTypeById(int id)
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Types.FirstOrDefault(c => c.Id == id);
            }
        }
    }
}
