using System.Collections.Generic;
using System.Linq;

namespace PrimeWeb.Core.Data
{
    public interface IRepository<TEntity>
    {
        TEntity GetEntityById(int Id);

        void InsertEntity(TEntity entity);

        void InsertEntities(IList<TEntity> entities);

        void UpdateEntity(TEntity entity);

        void UpdateEntities(IList<TEntity> entities);

        void RemoveEntity(int Id);

        IQueryable<TEntity> AsTable();

        IQueryable<TEntity> AsTableNoTracking();
    }
}
