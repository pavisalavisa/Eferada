using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Business.DependecyModules;
using Eferada.DependencyModules;
using Eferada.Infrastructure;
using Owin;

namespace Eferada
{
    public static class AutofacConfig
    {
        public static IContainer BuildContainer(IAppBuilder app)
        {
            //Create IoC container
            var containerBuilder = new ContainerBuilder();

            //Register controllers
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Register web abstactions
            containerBuilder.RegisterModule<AutofacWebTypesModule>();

            containerBuilder.Register(c => new ServerRootPathProvider(HttpContext.Current.Server.MapPath("~")))
                .As<IServerRootPathProvider>()
                .SingleInstance();

            //Enable property injection into action filters.
            containerBuilder.RegisterFilterProvider();

            //Register modules
            containerBuilder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            containerBuilder.RegisterModule(new BusinessIocModule(true));
            containerBuilder.RegisterModule(new DataIocModule());

            return containerBuilder.Build();
        }
    }
}