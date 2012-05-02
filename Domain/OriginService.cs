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
    public class OriginService : IOriginService
    {
        private readonly IOriginRepository _originRepository;
        private readonly IProductService _productService;
        

        [Inject]
        public OriginService(IOriginRepository originRepository, IProductService productService)
        {
            _originRepository = originRepository;
            _productService = productService;
        }

        public List<Origin> GetAll()
        {
            return _originRepository.GetAll();
        }

        public void Add(Origin entity)
        {
            _originRepository.Add(entity);
        }

        public ResponseMessage Update(Origin entity)
        {
            ResponseMessage response = new ResponseMessage();
            if (_productService.IsOriginAlreadyUsed(entity.Id) == true)
            {
                response.IsError = true;
                response.ErrorCodes.Add(string.Format(GeneralLocalisations.CannotBeDeleted, OriginLocalisations.Origin));
                return response;
            }
            _originRepository.Update(entity);
            return response;
        }

        public Origin GetModelById(int id)
        {
            return _originRepository.GetOriginById(id);
        }
        
        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();
            if (_productService.IsOriginAlreadyUsed(id) == true)
            {
                response.IsError = true;
                response.ErrorCodes.Add(string.Format(GeneralLocalisations.CannotBeDeleted, OriginLocalisations.Origin));
                return response;
            }
            _originRepository.Delete(id);
            return response;
        }
    }
}
