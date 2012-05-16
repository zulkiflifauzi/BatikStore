using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Interfaces;

namespace Repository
{
    public class UserRepository : IUserRepository
    {       
        public User GetUserByEmail(string email)
        {
            using (var db = new BatikStoreEntities())
            {
                return db.Users.SingleOrDefault(c => c.Email == email);
            }
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
