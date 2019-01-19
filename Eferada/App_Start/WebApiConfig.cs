using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Eferada.Infrastructure.Validation;

namespace Eferada.App_Start
{
    public class WebApiConfig
    {
        public static void Configure(HttpConfiguration config, IContainer container)
        {

            //config.SuppressDefaultHostAuthentication();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //ConfigureCors(config);

            ConfigureRoutes(config);

            ConfigureFilters(config);

            //ConfigureJsonMediaTypeFormatter(config);

            //ConfigureServices(config);

            //ConfigureMessageHandlers(config);
        }

        //private static void ConfigureCors(HttpConfiguration config)
        //{

        //    var cors = new EnableCorsAttribute("*", "*", "*");
        //    config.EnableCors(cors);
        //}

        private static void ConfigureRoutes(HttpConfiguration config)
        {

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }

        private static void ConfigureFilters(HttpConfiguration config)
        {

            // Configure Web API to use only bearer token authentication.
            //config.Filters.Add(new AuthorizeAttribute());
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //// Configure Web API model validation 
            config.Filters.Add(new ValidateModelStateFilterAttribute());
        }

        //private static void ConfigureJsonMediaTypeFormatter(HttpConfiguration config)
        //{

        //    config.Formatters.Clear();

        //    var jsonFormatter = new JsonMediaTypeFormatter
        //    {
        //        SerializerSettings =
        //        {
        //            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        //            DateFormatHandling = DateFormatHandling.IsoDateFormat,
        //            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        //            Formatting = Formatting.Indented
        //        }
        //    };

        //    jsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });

        //    config.Formatters.Add(jsonFormatter);

        //    // Binary data support for example: file upload. 
        //    config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
        //}

        //private static void ConfigureServices(HttpConfiguration config)
        //{

        //    // Configure Exception Handler and Logger services
        //    Logger.Debug("Configuring Exception Handler and _logger services...");
        //    config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
        //    config.Services.Add(typeof(IExceptionLogger), new Common.Web.Http.ExceptionHandling.ExceptionLogger());

        //    // Replace ITraceWriter service
        //    Logger.Debug("Configuring TraceWriter service...");
        //    config.Services.Replace(typeof(System.Web.Http.Tracing.ITraceWriter), new MyApiTraceWriter());

        //    // Replace IBodyModelValidator service (default behavior to validate all models as one and removes prefix - model name from keys in model state dictionary)
        //    config.Services.Replace(typeof(IBodyModelValidator),
        //        config.DependencyResolver.GetService(typeof(IBodyModelValidator)));
        //}

        //private static void ConfigureMessageHandlers(HttpConfiguration config)
        //{
        //    Logger.Debug("Qp.Api.WebApiConfig.ConfigureMessageHandlers() called.");

        //    // Configuring message handlers
        //    Logger.Debug("Configuring message handlers...");
        //    config.MessageHandlers.Add(new CultureSelectorMessageHandler());
        //    config.MessageHandlers.Add(new PreflightRequestsMessageHandler());
        //    config.MessageHandlers.Add(new ExecutionTimeMetricMessageHandler());
        //    config.MessageHandlers.Add(new ApiRequestMetricMessageHandler());
        //}
    }
}
