using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IModelRepository : ICRUDRepository<Model>
    {
        Model GetModelById(int id);
    }
}
