using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Toeb.Startup))]
namespace Toeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
