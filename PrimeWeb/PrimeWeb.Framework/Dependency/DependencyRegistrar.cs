using PrimeWeb.Service;
using PrimeWeb.Service.LogService;
using PrimeWeb.Core.Data;
using PrimeWeb.Repo;
using PrimeWeb.Data;
using PrimeWeb.Repo.Implementation;
using Ninject;
using Ninject.Web.Common;
using PrimeWeb.Service.CacheService;

namespace PrimeWeb.Framework.Dependency
{
    public static class DependencyRegistrar
    {
        public static void RegisterCoreModules(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork<DBContext>>().To<UnitOfWork>().InRequestScope().WithConstructorArgument(DBContext.Create());
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<IRoleRepository>().To<RoleRepository>().InRequestScope();
            kernel.Bind<ILogService>().To<Log4NetService>().InSingletonScope();
        }
    }
}
