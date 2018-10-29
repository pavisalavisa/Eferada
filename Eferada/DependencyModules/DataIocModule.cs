using Autofac;
using Eferada.DatabaseContext;
using Eferada.Interceptors;
using Eferada.Interceptors.Auditable;
using Eferada.Repository;

namespace Eferada.DependencyModules
{
    public class DataIocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterContext(builder);
            RegisterInterceptors(builder);

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        private void RegisterInterceptors(ContainerBuilder builder)
        {
            builder.RegisterType<EntityInterceptorsDispatcher>().InstancePerLifetimeScope();
            builder.RegisterType<AuditableInterceptor>().AsImplementedInterfaces().InstancePerLifetimeScope();
            //Missing dbset interceptor
        }

        private void RegisterContext(ContainerBuilder builder)
        {
            builder.Register(c =>
                {
                    var entityChangeInterceptorsDispatcher = c.Resolve<EntityInterceptorsDispatcher>();

                    return new EferadaDbContext(entityChangeInterceptorsDispatcher);
                })
                .AsSelf()
                .As<IEferadaDbContext>()
                .InstancePerLifetimeScope();
        }
    }
}