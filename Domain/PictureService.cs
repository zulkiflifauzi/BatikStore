using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Interfaces;
using Repository;
using Ninject;
using Domain.Interfaces;
using Base;

namespace Domain
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepository;

        [Inject]
        public PictureService(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }
        public List<Picture> GetPicturesByProductId(int productId)
        {
            return _pictureRepository.GetPicturesByProductId(productId);
        }


        public void Add(Picture entity)
        {
            _pictureRepository.Add(entity);
        }


        public Picture GetPictureById(int id)
        {
            return _pictureRepository.GetPictureById(id);
        }


        public ResponseMessage Update(Picture entity)
        {
            ResponseMessage response = new ResponseMessage();
            _pictureRepository.Update(entity);
            return response;
        }


        public void Delete(int id)
        {
            _pictureRepository.Delete(id);
        }
    }
}
