using Eferada.Data.Model.Helpers;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Eferada.Data.Model.Entities.Identity
{
    public class ApplicationUser:IdentityUser<int,ApplicationUserLogin,ApplicationUserRole,ApplicationUserClaim>,IEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string  Title { get; set; }
        public string FullName() => $"{FirstName} {LastName}";
        public virtual DateTime CreatedTimestamp { get; set; }
        public virtual DateTime LastUpdatedTimestamp { get; set; }
        public bool Pending { get; set; }

        public bool IsPersisted() => EntityHelper.IsPersisted(Id);
    }
}