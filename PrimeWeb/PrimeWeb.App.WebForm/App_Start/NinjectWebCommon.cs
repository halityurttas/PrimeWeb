[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PrimeWeb.App.WebForm.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(PrimeWeb.App.WebForm.App_Start.NinjectWebCommon), "Stop")]

namespace PrimeWeb.App.WebForm.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using PrimeWeb.Service;
    using PrimeWeb.Service.CDNService;
    using PrimeWeb.Service.CacheService;

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
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //register core modules
            Framework.Dependency.DependencyRegistrar.RegisterCoreModules(kernel);
            kernel.Bind<ICacheService>().To<MemoryCacheService>().InSingletonScope().WithConstructorArgument("options", "");
            //.WithConstructorArgument("path", HttpContext.Current.Server.MapPath("Content")).WithConstructorArgument("vpath", "Content");
        }        
    }
}
