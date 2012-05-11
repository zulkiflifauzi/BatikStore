using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;

namespace Domain.Interfaces
{
    public interface IPictureService
    {
        List<Picture> GetPictureByProductId(int productId);
        void Add(Picture entity);
    }
}
