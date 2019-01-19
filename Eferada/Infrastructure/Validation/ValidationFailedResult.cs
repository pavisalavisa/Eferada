using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ModelBinding;
using Eferada.Common.Extensions;

namespace Eferada.Infrastructure.Validation
{
    public class ValidationFailedResult
    {
        public string Message { get; set; }
        public IDictionary<string, IEnumerable<string>> Errors { get; } = new Dictionary<string, IEnumerable<string>>();

        public ValidationFailedResult(ModelStateDictionary modelState)
        {
            Message = "The request is invalid.";

            foreach (var keyModelStatePair in modelState)
            {
                var key = keyModelStatePair.Key.ToCamelCase();
                var errors = keyModelStatePair.Value.Errors.Where(x => x.ErrorMessage.IsNotNullOrWhiteSpace()).ToArray();
                if (errors.Length > 0)
                {
                    Errors.Add(key, errors.Select(x => x.ErrorMessage));
                }
            }
        }

    }
}