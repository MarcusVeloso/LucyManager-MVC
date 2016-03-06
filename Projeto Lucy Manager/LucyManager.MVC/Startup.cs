using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LucyManager.MVC.Startup))]
namespace LucyManager.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
