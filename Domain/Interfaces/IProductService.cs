using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;
using Base;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        bool IsModelAlreadyUsed(int modelId);
        bool IsOriginAlreadyUsed(int originId);
        bool IsTypeAlreadyUsed(int originId);
        bool IsSizeAlreadyUsed(int sizeId);
        ResponseMessage Add(Product entity);
        Product GetById(int id);
        ResponseMessage Update(Product entity);
        ResponseMessage Delete(int id);
        List<Product> GetRandomPromotedProducts();
    }
}
