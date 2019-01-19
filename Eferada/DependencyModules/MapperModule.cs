using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;

namespace Eferada.DependencyModules
{
    public class MapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
                {
                    foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                    {
                        cfg.AddProfile(profile);
                    }
                }))
                .AsSelf()
                .SingleInstance()
                .AutoActivate();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                    .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}