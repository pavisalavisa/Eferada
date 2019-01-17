using Eferada.Data.DatabaseContext;
using Eferada.Data.Model.Contracts;
using Eferada.Data.Model.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace Eferada.Data.Interceptors.Auditable
{
    public class AuditableInterceptor:IEntityInterceptor
    {
        public int Order =>int.MinValue;
        public void OnEntityChanged(IEferadaDbContext eferadaDbContext, IEntity entity, EntityState entityState)
        {
            if (entity is ICreatedTimestampAuditable)
            {
                if (entityState == EntityState.Added)
                {
                    ((ICreatedTimestampAuditable) entity).CreatedTimestamp = DateTime.UtcNow;
                }
            }

            if (entity is ILastUpdatedTimestampAuditable)
            {
                if (new[] {EntityState.Added, EntityState.Modified}.Contains(entityState))
                {
                    ((ILastUpdatedTimestampAuditable) entity).LastUpdatedTimestamp = DateTime.UtcNow;
                }
            }
        }
    }
}
