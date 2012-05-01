using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Interfaces;
using Ninject;
using AutoMapper;
using WebUI.Models;
using Repository;
namespace WebUI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        [Inject]
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var products = Mapper.Map<List<Product>, List<ViewModelProduct>>(_productService.GetAll());
            return View(products);
        }

    }
}
