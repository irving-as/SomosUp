using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AcopioUP.Startup))]
namespace AcopioUP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
