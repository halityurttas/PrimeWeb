using PrimeWeb.Core.Data;
using PrimeWeb.Data;
using System;
using System.Threading.Tasks;

namespace PrimeWeb.Repo
{
    public class UnitOfWork : IUnitOfWork<DBContext>
    {
        private DBContext context;

        public UnitOfWork(DBContext context)
        {
            this.context = context;
        }

        public DBContext Context => context;

        public bool SaveChanges()
        {
            try
            {
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
