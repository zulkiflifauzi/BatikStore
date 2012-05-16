using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;
using Base;

namespace Domain.Interfaces
{
    public interface IPictureService
    {
        List<Picture> GetPicturesByProductId(int productId);
        void Add(Picture entity);
        Picture GetPictureById(int id);
        ResponseMessage Update(Picture entity);
        void Delete(int id);
    }
}
