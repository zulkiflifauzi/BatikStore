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
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;
        private readonly IProductService _productService;
        

        [Inject]
        public ModelService(IModelRepository modelRepository, IProductService productService)
        {
            _modelRepository = modelRepository;
            _productService = productService;
        }

        public List<Model> GetAll()
        {
            return _modelRepository.GetAll();
        }

        public void Add(Model entity)
        {
            _modelRepository.Add(entity);
        }

        public ResponseMessage Update(Model entity)
        {
            ResponseMessage response = new ResponseMessage();
            if (_productService.IsModelAlreadyUsed(entity.Id) == true)
            {
                response.IsError = true;
                response.ErrorCodes.Add(string.Format(GeneralLocalisations.CannotBeEdited, ModelLocalisations.Model));
                return response;
            }
            _modelRepository.Update(entity);
            return response;
        }

        public Model GetModelById(int id)
        {
            return _modelRepository.GetModelById(id);
        }
        
        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();
            if (_productService.IsModelAlreadyUsed(id) == true)
            {
                response.IsError = true;
                response.ErrorCodes.Add(string.Format(GeneralLocalisations.CannotBeDeleted, ModelLocalisations.Model));
                return response;
            }
            _modelRepository.Delete(id);
            return response;
        }
    }
}
