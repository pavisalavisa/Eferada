using System;
using System.Web.Http;

namespace Eferada.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class EferadaRoutePrefixAttribute : RoutePrefixAttribute
    {
        public static string GetControllerName(string controllerName) => $"{controllerName.Replace("Controller", "")}";

        public EferadaRoutePrefixAttribute(string controllerName)
            : base(GetControllerName(controllerName))
        {

        }
    }
}