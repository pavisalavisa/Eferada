

using Autofac;

namespace Business.DependecyModules
{
    public class BusinessIocModule: Module
    {
        private readonly bool _registerComponentsAsInstancePerDependency;

        public BusinessIocModule(bool registerComponentsAsInstancePerDependency1, bool registerComponentsAsInstancePerDependency=false)
        {
            _registerComponentsAsInstancePerDependency = registerComponentsAsInstancePerDependency1;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new BusinessServicesModule(_registerComponentsAsInstancePerDependency));
        }
    }
}