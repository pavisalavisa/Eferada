using Autofac;
using Autofac.Integration.Mvc;
using Business.DependecyModules;
using Eferada.DependencyModules;
using System.Reflection;

namespace Eferada.App_Start
{
    public static class AutofacConfig
    {
        public static IContainer BuildContainer()
        {
            //Create IoC container
            var containerBuilder = new ContainerBuilder();

            //Register controllers
            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Register web abstactions
            containerBuilder.RegisterModule<AutofacWebTypesModule>();

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