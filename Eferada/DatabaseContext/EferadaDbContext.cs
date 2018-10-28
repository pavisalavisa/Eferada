using Eferada.Data.Model.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;


namespace Eferada.DatabaseContext
{
    public class EferadaDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IEferadaDbContext
    {
        //private readonly EntityInterceptorsDispacher
        public IDbSet<Models.ApplicationUser> Users { get; set; }

        public Database database
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IDbAsyncEnumerable<DbEntityValidationResult> IEferadaDbContext.GetValidationErrors()
        {
            throw new NotImplementedException();
        }
    }
}