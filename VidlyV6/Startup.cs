using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyV6.Startup))]
namespace VidlyV6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
