using System.Linq;
using System.Web.Http.Validation;
using Autofac;
using Eferada.Infrastructure.Validation;
using FluentValidation;
using FluentValidation.WebApi;

namespace Eferada.DependencyModules
{
    public class ValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<FluentValidationModelValidatorProvider>()
                .As<ModelValidatorProvider>();

            builder.Register(c => new PrefixlessBodyModelValidator(new FluentValidationBodyModelValidator()))
                .As<IBodyModelValidator>();

            builder.RegisterType<AutofacValidatorFactory>()
                .As<IValidatorFactory>();
        }
    }
}