using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Interfaces;
using Ninject;
using Repository.Interfaces;
using Repository;

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
    }
}
