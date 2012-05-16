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
    public class OriginController : BaseController
    {
        private readonly IOriginService _originService;

        [Inject]
        public OriginController(IOriginService originService)
        {
            _originService = originService;
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {            
            var models = Mapper.Map<List<Origin>, List<ViewModelOrigin>>(_originService.GetAll());
            return View(models);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Create(ViewModelOrigin model)
        {
            var entity = Mapper.Map<ViewModelOrigin, Origin>(model);
            _originService.Add(entity);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Origin, ViewModelOrigin>(_originService.GetModelById(id)));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(ViewModelOrigin model)
        {
            var entity = Mapper.Map<ViewModelOrigin, Origin>(model);
            ResponseMessage response =  _originService.Update(entity);

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
            ResponseMessage response = _originService.Delete(id);

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
