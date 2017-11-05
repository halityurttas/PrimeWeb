using Unity.Lifetime;
using PrimeWeb.Service;
using PrimeWeb.Service.LogService;
using PrimeWeb.Core.Data;
using PrimeWeb.Repo;
using PrimeWeb.Data;
using PrimeWeb.Repo.Implementation;

namespace PrimeWeb.Framework.Dependency
{
    public static class DependencyRegistrar
    {
        public static void RegisterBase(Microsoft.Practices.Unity.IUnityContainer container)
        {
            Core.Infrastructure.Singleton.Add(container);
            container.RegisterType<IUnitOfWork<DBContext>, UnitOfWork>();
            container.RegisterType<ILogService, Log4NetService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
        }
    }
}
