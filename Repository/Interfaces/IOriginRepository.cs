using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IOriginRepository : ICRUDRepository<Origin>
    {
        Origin GetOriginById(int id);
    }
}
