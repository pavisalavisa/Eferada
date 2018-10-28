using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eferada.Startup))]
namespace Eferada
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
