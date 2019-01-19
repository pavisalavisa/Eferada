using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Eferada;
using Eferada.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Startup), nameof(Startup.Configuration))]
namespace Eferada
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // Build IoC container
            var container = AutofacConfig.BuildContainer(app);

            // Create HttpConfiguration
            var httpConfig = new HttpConfiguration();

            // Help MVC Site related
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Configure WebApi
            WebApiConfig.Configure(httpConfig, container);

            app.UseAutofacMiddleware(container);

            // Configure CORS
            ConfigureCors(app);

            // Configure OAuth
            //OAuthConfig.Configure(app, container);

            app.UseWebApi(httpConfig);

            // After this point http config can't be changed.
            httpConfig.EnsureInitialized();
        }

        private void ConfigureCors(IAppBuilder app)
        {
            // TODO: Define Origins in config file or something similar.
            var corsPolicy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true,
                AllowAnyOrigin = true
            };

            var corsOptions = new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(corsPolicy)
                }
            };

            app.UseCors(corsOptions);
        }
    }
}
