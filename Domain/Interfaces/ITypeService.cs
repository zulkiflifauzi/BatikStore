using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;
using Base;

namespace Domain.Interfaces
{
    public interface ITypeService
    {
        Type GetTypeById(int id);
        List<Type> GetAll();
        void Add(Type entity);
        ResponseMessage Update(Type entity);
        ResponseMessage Delete(int id);
    }
}
