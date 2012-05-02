using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;
using Base;

namespace Domain.Interfaces
{
    public interface ISizeService
    {
        Size GetSizeById(int id);
        List<Size> GetAll();
        void Add(Size entity);
        ResponseMessage Update(Size entity);
        ResponseMessage Delete(int id);
    }
}
