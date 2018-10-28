using Eferada.Data.Model.Helpers;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Eferada.Data.Model.Entities.Identity
{
    public class ApplicationUserRole : IdentityUserRole<int>,IEntity
    {
        public virtual int  Id { get; set; }
        public virtual ApplicationRole Role { get; set; }
        public virtual ApplicationUser User { get; set; }

        public bool IsPersisted() => EntityHelper.IsPersisted(Id);
    }
}