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
using Base;

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
            return View("List", Mapper.Map<List<Picture>, List<ViewModelPicture>>(_pictureService.GetPicturesByProductId(id)));
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Create(int id)
        {
            ViewData["productId"] = id;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(ViewModelPicture model)
        {
            var entity = Mapper.Map<ViewModelPicture, Picture>(model);
            _pictureService.Add(entity);
            return RedirectToAction("List", new { id = model.Product_ProductId });
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Picture, ViewModelPicture>(_pictureService.GetPictureById(id)));
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(ViewModelPicture model)
        {
            var entity = Mapper.Map<ViewModelPicture, Picture>(model);
            ResponseMessage response = _pictureService.Update(entity);

            if (response.IsError == true)
            {
                foreach (var item in response.ErrorCodes)
                {
                    ModelState.AddModelError(item, item);
                }

                return View(model);
            }
            return RedirectToAction("List", new { id = model.Product_ProductId });
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            var product = Mapper.Map<Picture, ViewModelPicture>(_pictureService.GetPictureById(id));
            return View(product);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Delete(ViewModelPicture model)
        {
            _pictureService.Delete(model.Id);

            return RedirectToAction("List", new { id = model.Product_ProductId });
        }
        
    }
}
