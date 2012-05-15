using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IProductRepository : ICRUDRepository<Product>
    {
        bool IsModelAlreadyUsed(int modelId);
        bool IsOriginAlreadyUsed(int originId);
        bool IsTypeAlreadyUsed(int typeId);
        bool IsSizeAlreadyUsed(int sizeId);
        Product GetByNumber(string number);
        Product GetById(int Id);
        List<Product> GetRandomPromotedProducts();
    }
}
