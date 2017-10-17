using System;
using System.Collections.Generic;

namespace PrimeWeb.Core.Caching
{
    /// <summary>
    /// Especially cache for Domain Models
    /// </summary>
    public class DomainCache<TDomain> : MemoryCache
        where TDomain : class
    {

        /// <summary>
        /// Add Domain Model instance into cache
        /// </summary>
        /// <param name="domain">TDomain instance</param>
        /// <param name="offset">Expire offset</param>
        /// <returns>true if success</returns>
        public bool Add(TDomain domain, DateTimeOffset offset)
        {
            List<TDomain> list = base.GetCached<List<TDomain>>(typeof(TDomain).Name);
            if (list == null)
            {
                list = new List<TDomain>();
            }
            list.Add(domain);
            return base.AddCache(typeof(TDomain).Name, list, offset);
        }

        /// <summary>
        /// Add multiple Domain Model instance into cache
        /// Warning: Replace if exists
        /// </summary>
        /// <param name="domains">List of TDomain instances</param>
        /// <param name="offset">Expire offset</param>
        /// <returns>true if success</returns>
        public bool Set(List<TDomain> domains, DateTimeOffset offset)
        {
            return base.AddCache(typeof(TDomain).Name, domains, offset);
        }

        /// <summary>
        /// Get the current list of TDomain instances
        /// </summary>
        /// <returns>List of TDomain instances</returns>
        public List<TDomain> GetList()
        {
            return base.GetCached<List<TDomain>>(typeof(TDomain).Name);
        }

        /// <summary>
        /// Remove all instance of TDomain
        /// </summary>
        public void Remove()
        {
            base.RemoveCached(typeof(TDomain).Name);
        }
    }
}
