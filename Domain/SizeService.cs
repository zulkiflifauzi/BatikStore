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
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IProductService _productService;
        

        [Inject]
        public SizeService(ISizeRepository sizeRepository, IProductService productService)
        {
            _sizeRepository = sizeRepository;
            _productService = productService;
        }

        public List<Size> GetAll()
        {
            return _sizeRepository.GetAll();
        }

        public void Add(Size entity)
        {
            _sizeRepository.Add(entity);
        }

        public ResponseMessage Update(Size entity)
        {
            ResponseMessage response = new ResponseMessage();
            if (_productService.IsSizeAlreadyUsed(entity.Id) == true)
            {
                response.IsError = true;
                response.ErrorCodes.Add(string.Format(GeneralLocalisations.CannotBeEdited, SizeLocalisations.Size));
                return response;
            }
            _sizeRepository.Update(entity);
            return response;
        }

        public Size GetSizeById(int id)
        {
            return _sizeRepository.GetSizeById(id);
        }
        
        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();
            if (_productService.IsSizeAlreadyUsed(id) == true)
            {
                response.IsError = true;
                response.ErrorCodes.Add(string.Format(GeneralLocalisations.CannotBeDeleted, SizeLocalisations.Size));
                return response;
            }
            _sizeRepository.Delete(id);
            return response;
        }
    }
}
