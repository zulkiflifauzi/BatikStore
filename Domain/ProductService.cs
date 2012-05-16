using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Interfaces;
using Ninject;
using Repository.Interfaces;
using Repository;
using Base;
using Domain.Resources;

namespace Domain
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        [Inject]
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public bool IsModelAlreadyUsed(int modelId)
        {
            return _productRepository.IsModelAlreadyUsed(modelId);
        }

        public bool IsOriginAlreadyUsed(int originId)
        {
            return _productRepository.IsOriginAlreadyUsed(originId);
        }

        public bool IsTypeAlreadyUsed(int originId)
        {
            return _productRepository.IsTypeAlreadyUsed(originId);
        }


        public bool IsSizeAlreadyUsed(int sizeId)
        {
            return _productRepository.IsSizeAlreadyUsed(sizeId);
        }
        
        public ResponseMessage Add(Product entity)
        {
            ResponseMessage response = new ResponseMessage();
            if (_productRepository.GetByNumber(entity.Number) != null)
            {
                response.IsError = true;
                response.ErrorCodes.Add(string.Format(GeneralLocalisations.AlreadyExist, ProductLocalisations.Product,ProductLocalisations.Number, entity.Number));
                return response;
            }
            entity.DateEntered = DateTime.Now;
            entity.Promoted = false;
            _productRepository.Add(entity);
            return response;
        }


        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }
        
        public ResponseMessage Update(Product entity)
        {
            ResponseMessage response = new ResponseMessage();
            var product = _productRepository.GetByNumber(entity.Number);
            if ( product != null)
            {
                if (product.Id != entity.Id)
                {
                    response.IsError = true;
                    response.ErrorCodes.Add(string.Format(GeneralLocalisations.AlreadyExist, ProductLocalisations.Product, ProductLocalisations.Number, entity.Number));
                    return response;
                }
            }
            _productRepository.Update(entity);
            return response;
        }


        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();           
            _productRepository.Delete(id);
            return response;
        }

        public List<Product> GetRandomPromotedProducts()
        {
            return _productRepository.GetRandomPromotedProducts();
        }

        public List<Product> GetRandomProducts(bool promotedProducts)
        {
            return _productRepository.GetRandomProducts(promotedProducts);
        }

        public List<Product> GetLatestProducts()
        {
            return _productRepository.GetLatestProducts();
        }
    }
}
