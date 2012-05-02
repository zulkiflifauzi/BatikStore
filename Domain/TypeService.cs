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
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IProductService _productService;
        

        [Inject]
        public TypeService(ITypeRepository typeRepository, IProductService productService)
        {
            _typeRepository = typeRepository;
            _productService = productService;
        }

        public List<Type> GetAll()
        {
            return _typeRepository.GetAll();
        }

        public void Add(Type entity)
        {
            _typeRepository.Add(entity);
        }

        public ResponseMessage Update(Type entity)
        {
            ResponseMessage response = new ResponseMessage();
            if (_productService.IsTypeAlreadyUsed(entity.Id) == true)
            {
                response.IsError = true;
                response.ErrorCodes.Add(string.Format(GeneralLocalisations.CannotBeEdited, OriginLocalisations.Origin));
                return response;
            }
            _typeRepository.Update(entity);
            return response;
        }

        public Type GetTypeById(int id)
        {
            return _typeRepository.GetTypeById(id);
        }
        
        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();
            if (_productService.IsTypeAlreadyUsed(id) == true)
            {
                response.IsError = true;
                response.ErrorCodes.Add(string.Format(GeneralLocalisations.CannotBeDeleted, OriginLocalisations.Origin));
                return response;
            }
            _typeRepository.Delete(id);
            return response;
        }
    }
}
