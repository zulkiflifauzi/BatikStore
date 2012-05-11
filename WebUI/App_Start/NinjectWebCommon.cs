[assembly: WebActivator.PreApplicationStartMethod(typeof(WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(WebUI.App_Start.NinjectWebCommon), "Stop")]

namespace WebUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Domain.Interfaces;
    using Domain;
    using Repository.Interfaces;
    using Repository;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();

            kernel.Bind<IModelService>().To<ModelService>();
            kernel.Bind<IModelRepository>().To<ModelRepository>();

            kernel.Bind<IOriginService>().To<OriginService>();
            kernel.Bind<IOriginRepository>().To<OriginRepository>();

            kernel.Bind<ITypeService>().To<TypeService>();
            kernel.Bind<ITypeRepository>().To<TypeRepository>();

            kernel.Bind<ISizeService>().To<SizeService>();
            kernel.Bind<ISizeRepository>().To<SizeRepository>();

            kernel.Bind<IPictureService>().To<PictureService>();
            kernel.Bind<IPictureRepository>().To<PictureRepository>();
        }        
    }
}
