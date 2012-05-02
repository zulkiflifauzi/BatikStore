using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        bool IsModelAlreadyUsed(int modelId);
        bool IsOriginAlreadyUsed(int originId);
        bool IsTypeAlreadyUsed(int originId);
    }
}
