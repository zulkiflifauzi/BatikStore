using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using WebUI.Models;
using Repository;

[assembly: WebActivator.PreApplicationStartMethod(typeof(WebUI.App_Start.AutoMapperMaps), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(WebUI.App_Start.AutoMapperMaps), "Stop")]

namespace WebUI.App_Start
{
    public static class AutoMapperMaps
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            Mapper.CreateMap<Product, ViewModelProduct>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.DateEntered.ToString("d MMM yyyy")));
            Mapper.CreateMap<ViewModelProduct, Product>()
                .ForMember(x => x.Type, opt => opt.Ignore()); ;

            Mapper.CreateMap<Model, ViewModelModel>();
            Mapper.CreateMap<ViewModelModel, Model>();

            Mapper.CreateMap<Origin, ViewModelOrigin>();
            Mapper.CreateMap<ViewModelOrigin, Origin>();

            Mapper.CreateMap<Repository.Type, ViewModelType>();
            Mapper.CreateMap<ViewModelType, Repository.Type>();

            Mapper.CreateMap<Size, ViewModelSize>();
            Mapper.CreateMap<ViewModelSize, Size>();

            Mapper.CreateMap<Picture, ViewModelPicture>();
            Mapper.CreateMap<ViewModelPicture, Picture>();
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {

        }
    }
}
