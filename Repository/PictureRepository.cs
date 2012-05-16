using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Interfaces;

namespace Repository
{
    public class PictureRepository : IPictureRepository
    {
        public List<Picture> GetPicturesByProductId(int productId)
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Pictures.Where(c => c.Product_ProductId == productId).ToList();
            }
        }


        public List<Picture> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Picture entity)
        {
            using (var db = new BatikStoreEntities())
            {
                db.Pictures.AddObject(entity);
                db.SaveChanges();
            }
        }

        public void Update(Picture entity)
        {
            using (var db = new BatikStoreEntities())
            {
                var existing = db.Pictures.SingleOrDefault(c => c.Id == entity.Id);
                if (existing != null)
                {
                    db.Pictures.ApplyCurrentValues(entity);
                    db.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var db = new BatikStoreEntities())
            {
                var existing = db.Pictures.SingleOrDefault(c => c.Id == id);
                if (existing != null)
                {
                    db.Pictures.DeleteObject(existing);
                    db.SaveChanges();
                }
            }
        }


        public Picture GetPictureById(int id)
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Pictures.SingleOrDefault(c => c.Id == id);
            }
        }
    }
}
