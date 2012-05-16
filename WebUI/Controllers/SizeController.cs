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
    public class SizeController : BaseController
    {
        private readonly ISizeService _sizeService;

        [Inject]
        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var models = Mapper.Map<List<Size>, List<ViewModelSize>>(_sizeService.GetAll());
            return View(models);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Create(ViewModelSize model)
        {
            var entity = Mapper.Map<ViewModelSize, Size>(model);
            _sizeService.Add(entity);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Size, ViewModelSize>(_sizeService.GetSizeById(id)));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(ViewModelSize model)
        {
            var entity = Mapper.Map<ViewModelSize, Size>(model);
            ResponseMessage response =  _sizeService.Update(entity);

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

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            ResponseMessage response = _sizeService.Delete(id);

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

    }
}
