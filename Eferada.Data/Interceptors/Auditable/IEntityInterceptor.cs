using Eferada.Data.DatabaseContext;
using Eferada.Data.Model.Entities;
using System.Data.Entity;

namespace Eferada.Data.Interceptors.Auditable
{
    public interface IEntityInterceptor
    {
        int Order { get; }

        void OnEntityChanged(IEferadaDbContext eferadaDbContext, IEntity entity, EntityState entityState);
    }
}
