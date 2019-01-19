using System;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using System.Web.Http.Validation;

namespace Eferada.Infrastructure.Validation
{
    public class PrefixlessBodyModelValidator : IBodyModelValidator
    {
        private readonly IBodyModelValidator _innerValidator;

        public PrefixlessBodyModelValidator(IBodyModelValidator innerValidator)
        {
            _innerValidator = innerValidator ?? throw new Exception("Inner validator cannot be null.");
        }

        public bool Validate(object model, Type type, ModelMetadataProvider metadataProvider, HttpActionContext actionContext,
            string keyPrefix)
        {
            return _innerValidator.Validate(model, type, metadataProvider, actionContext, string.Empty);
        }
    }
}