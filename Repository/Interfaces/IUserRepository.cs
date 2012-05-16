using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IUserRepository : ICRUDRepository<User>
    {
        User GetUserByEmail(string email);
    }
}
