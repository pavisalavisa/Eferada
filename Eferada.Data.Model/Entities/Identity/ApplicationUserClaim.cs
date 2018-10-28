using Eferada.Data.Model.Helpers;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Eferada.Data.Model.Entities.Identity
{
    public class ApplicationUserClaim : IdentityUserClaim<int>,IEntity
    {
        public virtual ApplicationUser User { get; set; }

        public bool IsPersisted() => EntityHelper.IsPersisted(Id);
    }
}