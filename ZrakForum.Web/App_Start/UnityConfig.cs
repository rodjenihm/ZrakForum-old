using System.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;
using ZrakForum.DataAccess.Repositories;
using ZrakForum.DataAccess.Utilities;
using ZrakForum.Web.Services;

namespace ZrakForum.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<DapperConnectionString>
                (new InjectionConstructor(ConfigurationManager.ConnectionStrings["LocalZrakForumDb"].ConnectionString));
            container.RegisterType<IAccountRepository, DapperAccountRepository>();
            container.RegisterType<IRoleRepository, DapperRoleRepository>();
            container.RegisterType<IForumRepository, DapperForumRepository>();
            container.RegisterType<IThreadRepository, DapperThreadRepository>();
            container.RegisterType<IPostRepository, DapperPostRepository>();
            container.RegisterType<IPasswordHasher, PasswordHasher>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}