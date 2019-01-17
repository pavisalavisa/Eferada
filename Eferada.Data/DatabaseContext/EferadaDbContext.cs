using Eferada.Common.Exceptions;
using Eferada.Data.EntitiyConfigurations.Identity;
using Eferada.Data.Interceptors;
using Eferada.Data.Interceptors.Auditable;
using Eferada.Data.Model.Entities;
using Eferada.Data.Model.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace Eferada.Data.DatabaseContext
{
    public class EferadaDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IEferadaDbContext
    {
        private readonly EntityInterceptorsDispatcher _entityChangEntityInterceptorsDispatcher;

        [SuppressDbSetInitialization]
        public override IDbSet<ApplicationRole> Roles
        {
            get { return Set<ApplicationRole>(); }
            set { base.Roles = value; }
        }

        public override IDbSet<ApplicationUser> Users
        {
            get { return Set<ApplicationUser>(); }
            set { base.Users = value; }
        }

        public EferadaDbContext(DbConnection connection) : base(connection, true)
        {

        }

        static EferadaDbContext()
        {
            Database.SetInitializer<EferadaDbContext>(null);
        }

        public EferadaDbContext() : base("Name=EferadaDbContext")
        {
            var interceptors = new[]
            {
                new AuditableInterceptor()
            };

            _entityChangEntityInterceptorsDispatcher=new EntityInterceptorsDispatcher(interceptors);
        }

        public EferadaDbContext(EntityInterceptorsDispatcher entityChangeInterceptorsDispatcher) : base("EferadaDbContext")
        {
            _entityChangEntityInterceptorsDispatcher = entityChangeInterceptorsDispatcher;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Add configurations here!

            AddIdentityConfigurations(modelBuilder);
        }

        public override int SaveChanges()
        {
            var currentTransaction = Database.CurrentTransaction;

            if (currentTransaction != null)
            {
                return Save();
            }

            using (var transaction = this.BeginTransaction())
            {
                var changes = Save();

                transaction.Commit();

                return changes;
            }
        }

        public override Task<int> SaveChangesAsync()
        {
            return Task.Run(() => SaveChanges());
        }

        public IDbAsyncEnumerable<DbEntityValidationResult> GetValidationErrors()
        {
            throw new NotImplementedException();
        }

        private int Save()
        {
            var entries = ChangeTracker.Entries().Where(x =>new[] {EntityState.Added, EntityState.Modified, EntityState.Deleted}.Contains(x.State)).ToList();

            var processedEntitiesDictionary = new Dictionary<IEntity, EntityState>();

            foreach (var entry in entries)
            {
                if (processedEntitiesDictionary.ContainsKey((IEntity)entry.Entity))
                {
                    continue;
                }

                if (entry.State == EntityState.Modified && AreRecordsSame(entry.CurrentValues, entry.OriginalValues))
                {
                    entry.State = EntityState.Unchanged;
                    continue;
                }

                processedEntitiesDictionary.Add((IEntity) entry.Entity, entry.State);
            }

            foreach (var processedEntityRecord in processedEntitiesDictionary)
            {
                _entityChangEntityInterceptorsDispatcher.Dispatch(this,processedEntityRecord.Key,processedEntityRecord.Value);
            }

            try
            {
                return base.SaveChanges();
            }

            catch (Exception e)
            {
                if (e is DbUpdateException )
                {
                    throw new DatabaseConcurrencyException(((DbUpdateException)e).Entries);
                }

                throw;
            }
        }

        private bool AreRecordsSame(DbPropertyValues currentValues, DbPropertyValues originalValues)
        {
            foreach (var propertyName in currentValues.PropertyNames)
            {
                var current = currentValues[propertyName];
                var original = originalValues[propertyName];

                if (!Equals(original, current))
                {
                    return false;
                }
            }

            return true;
        }

        private void AddIdentityConfigurations(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationRoleConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserClaimConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserLoginConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserRoleConfiguration());
        }
    }
}