using System;
using Autofac;
using FluentValidation;

namespace Eferada.Infrastructure.Validation
{
    public class AutofacValidatorFactory : ValidatorFactoryBase
    {
        private readonly IComponentContext _context;

        public AutofacValidatorFactory(IComponentContext context)
        {
            _context = context;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            if (_context.TryResolve(validatorType, out var instance))
            {
                return instance as IValidator;
            }

            return null;
        }
    }
}