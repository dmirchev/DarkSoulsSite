using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DarkSoulsSiteMVC.Startup))]
namespace DarkSoulsSiteMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
