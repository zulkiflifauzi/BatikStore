using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;
using Base;

namespace Domain.Interfaces
{
    public interface IModelService
    {
        Model GetModelById(int id);
        List<Model> GetAll();
        void Add(Model entity);
        ResponseMessage Update(Model entity);
        ResponseMessage Delete(int id);
    }
}
