using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface ICRUDRepository<T> where T : class 
    {
        List<T> GetAll();

        void Add(T entity);
       
        void Update(T entity);

        void Delete(T entity);
    }
}
