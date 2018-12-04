using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Repository.Startup))]
namespace MVC_Repository
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
