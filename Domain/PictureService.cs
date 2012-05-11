using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Interfaces;
using Repository;
using Ninject;
using Domain.Interfaces;

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
        public List<Picture> GetPictureByProductId(int productId)
        {
            return _pictureRepository.GetPictureByProductId(productId);
        }


        public void Add(Picture entity)
        {
            _pictureRepository.Add(entity);
        }
    }
}
