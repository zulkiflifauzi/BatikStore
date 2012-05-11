using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Interfaces;

namespace Repository
{
    public class PictureRepository : IPictureRepository
    {
        public List<Picture> GetPictureByProductId(int productId)
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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
