using System.Collections.Generic;
using System.Linq;

namespace PrimeWeb.Core.Data
{
    public interface IRepository<TEntity>
    {
        TEntity GetEntityById(int Id);

        bool InsertEntity(TEntity entity);

        bool InsertEntities(IList<TEntity> entities);

        bool UpdateEntity(TEntity entity);

        bool UpdateEntities(IList<TEntity> entities);

        bool RemoveEntity(int Id);

        IQueryable<TEntity> AsTable();

        IQueryable<TEntity> AsTableNoTracking();
    }
}
