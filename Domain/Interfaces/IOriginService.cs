using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;
using Base;

namespace Domain.Interfaces
{
    public interface IOriginService
    {
        Origin GetModelById(int id);
        List<Origin> GetAll();
        void Add(Origin entity);
        ResponseMessage Update(Origin entity);
        ResponseMessage Delete(int id);
    }
}
