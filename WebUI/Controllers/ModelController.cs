using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Domain.Interfaces;
using Repository;
using WebUI.Models;
using AutoMapper;
using Base;
using Resources;

namespace WebUI.Controllers
{
    public class ModelController : BaseController
    {
        private readonly IModelService _modelService;

        [Inject]
        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {            
            var models = Mapper.Map<List<Model>, List<ViewModelModel>>(_modelService.GetAll());
            return View(models);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Create(ViewModelModel model)
        {
            var entity = Mapper.Map<ViewModelModel, Model>(model);
            _modelService.Add(entity);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Model,ViewModelModel>(_modelService.GetModelById(id)));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(ViewModelModel model)
        {
            var entity = Mapper.Map<ViewModelModel, Model>(model);
            ResponseMessage response =  _modelService.Update(entity);

            if (response.IsError == true)
            {
                foreach (var item in response.ErrorCodes)
                {
                    ModelState.AddModelError(item, item);
                }

                return View(model);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            ResponseMessage response = _modelService.Delete(id);

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
