using Eferada.Data.Model.Helpers;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Eferada.Data.Model.Entities.Identity
{
    public class ApplicationRole : IdentityRole<int,ApplicationUserRole>,IEntity
    {
        public bool IsPersisted() => EntityHelper.IsPersisted(Id);
    }
}