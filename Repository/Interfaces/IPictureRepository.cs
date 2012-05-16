using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IPictureRepository : ICRUDRepository<Picture>
    {
        List<Picture> GetPicturesByProductId(int productId);
        Picture GetPictureById(int id);
    }
}
