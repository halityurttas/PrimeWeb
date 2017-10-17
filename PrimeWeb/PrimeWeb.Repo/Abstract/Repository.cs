using PrimeWeb.Core.Data;
using PrimeWeb.Data;
using System.Collections.Generic;
using System.Linq;

namespace PrimeWeb.Repo.Abstract
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IIdentityEntity
    {

        readonly IUnitOfWork<DBContext> unitOfWork;

        public Repository(IUnitOfWork<DBContext> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<TEntity> AsTable()
        {
            return unitOfWork.Context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> AsTableNoTracking()
        {
            return unitOfWork.Context.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetEntityById(int Id)
        {
            return unitOfWork.Context.Set<TEntity>().SingleOrDefault(s => s.Id == Id);
        }

        public void InsertEntities(IList<TEntity> entities)
        {
            
            unitOfWork.Context.Set<TEntity>().AddRange(entities);
        }

        public void InsertEntity(TEntity entity)
        {
            unitOfWork.Context.Set<TEntity>().Add(entity);
        }

        public void RemoveEntity(int Id)
        {
            var entity = GetEntityById(Id);
            unitOfWork.Context.Set<TEntity>().Remove(entity);
        }

        public void UpdateEntities(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                unitOfWork.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void UpdateEntity(TEntity entity)
        {
            unitOfWork.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
