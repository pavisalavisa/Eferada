using Eferada.Data.Model.Entities;
using Eferada.DatabaseContext;
using System.Collections.Generic;
using System.Data.Entity;

namespace Eferada.Interceptors
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