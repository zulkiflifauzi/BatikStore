using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Interfaces;
using Ninject;
using AutoMapper;
using WebUI.Models;
using Repository;
using Base;
using System.Text;
namespace WebUI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ISizeService _sizeService;
        private readonly ITypeService _typeService;
        private readonly IOriginService _originService;
        private readonly IModelService _modelService;

        [Inject]
        public ProductController(IProductService productService, ISizeService sizeService, ITypeService typeService, IOriginService originService, IModelService modelService)
        {
            _productService = productService;
            _sizeService = sizeService;
            _typeService = typeService;
            _originService = originService;
            _modelService = modelService;
        }

        public ActionResult Index()
        {
            var products = Mapper.Map<List<Product>, List<ViewModelProduct>>(_productService.GetAll());
            return View(products);
        }

        public ActionResult Create()
        {
            PrepareSelectList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewModelProduct product)
        {
            var entity = Mapper.Map<ViewModelProduct, Product>(product);
            ResponseMessage response = _productService.Add(entity);

            if (response.IsError == true)
            {
                foreach (var item in response.ErrorCodes)
                {
                    ModelState.AddModelError(item, item);
                }
                PrepareSelectList();
                return View(product);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = Mapper.Map<Product, ViewModelProduct>(_productService.GetById(id));
            PrepareSelectList();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(ViewModelProduct product)
        {
            var entity = Mapper.Map<ViewModelProduct, Product>(product);
            ResponseMessage response = _productService.Update(entity);

            if (response.IsError == true)
            {
                foreach (var item in response.ErrorCodes)
                {
                    ModelState.AddModelError(item, item);
                }
                PrepareSelectList();
                return View(product);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = Mapper.Map<Product, ViewModelProduct>(_productService.GetById(id));
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(ViewModelProduct product)
        {
            ResponseMessage response = _productService.Delete(product.Id);

            if (response.IsError == true)
            {
                foreach (var item in response.ErrorCodes)
                {
                    ModelState.AddModelError(item, item);
                }

                return View();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var product = Mapper.Map<Product, ViewModelProduct>(_productService.GetById(id));
            return View(product);
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(ViewModelProduct product, int skip)
        {
            StringBuilder query = new StringBuilder();
            GenerateQueryString(query, product);
            var products = Mapper.Map<List<Product>, List<ViewModelProduct>>(_productService.Search(query.ToString(),skip));
            return View(product);
        }

        private static void AppendCriteria(StringBuilder query)
        {
            if (!string.IsNullOrEmpty(query.ToString()))
            {
                query.Append(" AND ");
            }
        }

        private static void GenerateQueryString(StringBuilder query, ViewModelProduct product)
        {
            if (!string.IsNullOrEmpty(product.Name))
            {
                AppendCriteria(query);

                query.Append("it.Name like '%" + product.Name + "%'");
            }

            if (product.Size_SizeId != 0)
            {
                AppendCriteria(query);
                query.Append("it.Size_SizeId = " + product.Size_SizeId.Value.ToString());
            }

            if (product.Model_ModelId != 0)
            {
                AppendCriteria(query);
                query.Append("it.Model_ModelId = " + product.Model_ModelId.Value.ToString());
            }

            if (product.Type_TypeId != 0)
            {
                AppendCriteria(query);
                query.Append("it.Type_TypeId = " + product.Type_TypeId.Value.ToString());
            }

            if (product.Origin_OriginId != 0)
            {
                AppendCriteria(query);
                query.Append("it.Origin_OriginId = " + product.Origin_OriginId.Value.ToString());
            }
        }

        private void PrepareSelectList()
        {
            List<SelectListItem> sizeList = new List<SelectListItem>();
            foreach (var item in _sizeService.GetAll())
            {
                sizeList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            ViewData["Sizes"] = sizeList;

            List<SelectListItem> modelList = new List<SelectListItem>();
            foreach (var item in _modelService.GetAll())
            {
                modelList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            ViewData["Models"] = modelList;

            List<SelectListItem> originList = new List<SelectListItem>();
            foreach (var item in _originService.GetAll())
            {
                originList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            ViewData["Origins"] = originList;

            List<SelectListItem> typeList = new List<SelectListItem>();
            foreach (var item in _typeService.GetAll())
            {
                typeList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            ViewData["Types"] = typeList;
        }
    }
}
