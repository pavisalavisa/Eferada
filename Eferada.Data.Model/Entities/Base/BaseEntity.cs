using Eferada.Data.Model.Helpers;
using System;

namespace Eferada.Data.Model.Entities.Base
{
    public abstract class BaseEntity<TKey> : IEntity
    {
        public virtual TKey Id { get; set; }

        public bool IsPersisted()=>EntityHelper.IsPersisted(Id);

        int IEntity.Id => Convert.ToInt32(Id);
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }

    public abstract class BaseNameEntity : BaseEntity, INameEntity
    {
        public string Name { get; set; }
    }

    public abstract class BaseAbbreviationAndNameEntity : BaseEntity, IAbbreviationAndNameEntity
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}