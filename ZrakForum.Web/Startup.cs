using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZrakForum.Web.Startup))]
namespace ZrakForum.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
