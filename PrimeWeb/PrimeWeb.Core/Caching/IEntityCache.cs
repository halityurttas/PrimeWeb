using System;
using System.Collections.Generic;

namespace PrimeWeb.Core.Caching
{
    public interface IEntityCache<TEntity>
    {
        void Set(IList<TEntity> entity, DateTimeOffset expireOffset);
        IList<TEntity> Get();
    }
}
