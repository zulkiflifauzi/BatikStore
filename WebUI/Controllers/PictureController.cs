using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Domain.Interfaces;
using AutoMapper;
using Repository;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class PictureController : BaseController
    {
        private readonly IPictureService _pictureService;
        private readonly IProductService _productService;

        [Inject]
        public PictureController(IPictureService pictureService, IProductService productService)
        {
            _pictureService = pictureService;
            _productService = productService;
        }

        public ActionResult List(int id)
        {
            ViewBag.ProductNumber = _productService.GetById(id).Number;
            ViewBag.ProductId = id;
            return View("List", Mapper.Map<List<Picture>, List<ViewModelPicture>>(_pictureService.GetPictureByProductId(id)));
        }

        public ActionResult Create(int id)
        {
            ViewData["productId"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewModelPicture model)
        {
            var entity = Mapper.Map<ViewModelPicture, Picture>(model);
            _pictureService.Add(entity);
            return RedirectToAction("List", new { id = model.Product_ProductId });
        }
        
    }
}
