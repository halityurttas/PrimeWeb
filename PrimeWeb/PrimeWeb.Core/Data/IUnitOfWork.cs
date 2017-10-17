using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeWeb.Core.Data
{
    public interface IUnitOfWork<TContext>
    {
        TContext Context { get; }

        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}
