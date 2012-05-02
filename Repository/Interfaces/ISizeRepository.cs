using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface ISizeRepository : ICRUDRepository<Size>
    {
        Size GetSizeById(int id);
    }
}
