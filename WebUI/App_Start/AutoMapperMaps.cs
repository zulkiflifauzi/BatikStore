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
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model != null ? src.Model.Name : string.Empty));
            Mapper.CreateMap<ViewModelProduct, Product>();

            Mapper.CreateMap<Model, ViewModelModel>();
            Mapper.CreateMap<ViewModelModel, Model>();
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {

        }
    }
}
