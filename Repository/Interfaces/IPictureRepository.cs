using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IPictureRepository : ICRUDRepository<Picture>
    {
        List<Picture> GetPictureByProductId(int productId);
    }
}
