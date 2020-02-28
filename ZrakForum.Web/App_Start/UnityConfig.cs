using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using ZrakForum.DataAccess.Repositories;

namespace ZrakForum.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IAccountRepository, DapperAccountRepository>();
            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}