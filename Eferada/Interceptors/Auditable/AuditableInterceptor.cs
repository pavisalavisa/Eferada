using Eferada.Data.Model.Contracts;
using Eferada.Data.Model.Entities;
using Eferada.DatabaseContext;
using System;
using System.Data.Entity;
using System.Linq;

namespace Eferada.Interceptors.Auditable
{
    public class AuditableInterceptor:IEntityInterceptor
    {
        public int Order =>int.MinValue;
        public void OnEntityChanged(IEferadaDbContext eferadaDbContext, IEntity entity, EntityState entityState)
        {
            if (entity is ICreatedTimestampAuditable createdTrackedEntity)
            {
                if (entityState == EntityState.Added)
                {
                    createdTrackedEntity.CreatedTimestamp = DateTime.UtcNow;
                }
            }

            if (entity is ILastUpdatedTimestampAuditable updatedTrackedEntity)
            {
                if (new[] {EntityState.Added, EntityState.Modified}.Contains(entityState))
                {
                    updatedTrackedEntity.LastUpdatedTimestamp = DateTime.UtcNow;
                }
            }
        }
    }
}
