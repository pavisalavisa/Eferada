using Autofac;
using Business.Services.Contracts;

namespace Business.DependecyModules
{
    public class BusinessServicesModule : Module
    {
        private readonly bool _registerComponentsAsPerDependency;

        public BusinessServicesModule(bool registerComponentsAsPerDependency)
        {
            _registerComponentsAsPerDependency = registerComponentsAsPerDependency;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //Register business services
            var businessServicesRegistraionBuilder = builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<IBusinessServiceMarker>());

            if (_registerComponentsAsPerDependency)
            {
                businessServicesRegistraionBuilder
                    .AsImplementedInterfaces()
                    .InstancePerDependency();
            }
            else
            {
                businessServicesRegistraionBuilder
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            }

            //Other custom registrations go here.
        }
    }
}