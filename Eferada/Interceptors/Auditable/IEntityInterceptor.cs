﻿using Eferada.Data.Model.Entities;
using Eferada.DatabaseContext;
using System.Data.Entity;

namespace Eferada.Interceptors.Auditable
{
    interface IEntityInterceptor
    {
        int Order { get; }

        void OnEntityChanged(IEferadaDbContext eferadaDbContext, IEntity entity, EntityState entityState);
    }
}
