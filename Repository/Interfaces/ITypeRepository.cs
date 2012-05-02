using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface ITypeRepository : ICRUDRepository<Type>
    {
        Type GetTypeById(int id);
    }
}
