using System.Collections.Generic;
using System.Data.Entity;
using Eferada.Data.DatabaseContext;
using Eferada.Data.Interceptors.Auditable;
using Eferada.Data.Model.Entities;

namespace Eferada.Data.Interceptors
{
    public class EntityInterceptorsDispatcher
    {
        private readonly IEnumerable<IEntityInterceptor> _entityChangeInterceptors;

        public EntityInterceptorsDispatcher(IEnumerable<IEntityInterceptor> entityChangeInterceptors)
        {
            _entityChangeInterceptors = entityChangeInterceptors;
        }

        public void Dispatch(IEferadaDbContext context, IEntity entity, EntityState state)
        {
            foreach (var entityChangeInterceptor in _entityChangeInterceptors)
            {
                entityChangeInterceptor.OnEntityChanged(context, entity, state);
            }
        }
    }
}