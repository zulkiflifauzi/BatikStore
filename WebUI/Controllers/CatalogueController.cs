using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Domain.Interfaces;
using WebUI.Models;
using AutoMapper;
using Repository;

namespace WebUI.Controllers
{
    public class CatalogueController : BaseController
    {
        private readonly IProductService _productService;

        [Inject]
        public CatalogueController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewModelCatalogue result = new ViewModelCatalogue();
            result.PromotedProducts.AddRange(Mapper.Map<List<Product>, List<ViewModelProduct>>(_productService.GetRandomPromotedProducts()));
            result.RandomProducts.AddRange(Mapper.Map<List<Product>, List<ViewModelProduct>>(_productService.GetRandomProducts(false)));
            result.LatestProducts.AddRange(Mapper.Map<List<Product>, List<ViewModelProduct>>(_productService.GetLatestProducts()));
            return View(result);
        }

    }
}
