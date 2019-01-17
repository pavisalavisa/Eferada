using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Threading;
using System.Threading.Tasks;
using ApplicationUser = Eferada.Data.Model.Entities.Identity.ApplicationUser;

namespace Eferada.Data.DatabaseContext
{
    public interface IEferadaDbContext : IDisposable
    {
        IDbSet<ApplicationUser> Users { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbChangeTracker ChangeTracker { get; }
        DbContextConfiguration Configuration { get; }
        Database Database { get; }
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);
        IDbAsyncEnumerable<DbEntityValidationResult> GetValidationErrors();
        DbSet Set(Type entityType);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
    }
}