using System;
using System.Linq;

namespace PrimeWeb.Core.Caching
{
    /// <summary>
    /// System.Runtime.Caching.MemoryCache manager
    /// </summary>
    public class MemoryCache : ICache
    {
        System.Runtime.Caching.MemoryCache _cache;

        public MemoryCache()
        {
            _cache = System.Runtime.Caching.MemoryCache.Default;
        }

        /// <summary>
        /// Add TObject instance into cache
        /// </summary>
        /// <typeparam name="TObject">Type of data</typeparam>
        /// <param name="key">Unique key</param>
        /// <param name="data">Instance of TObject</param>
        /// <param name="offset">Expire offset</param>
        /// <returns>true if success</returns>
        public bool AddCache<TObject>(string key, TObject data, DateTimeOffset offset)
        {
            if (_cache.Any(w => w.Key == key))
            {
                _cache.Remove(key);
            }
            return _cache.Add(key, data, offset);
        }

        /// <summary>
        /// Get cached instance
        /// </summary>
        /// <typeparam name="TObject">Type of data</typeparam>
        /// <param name="key">Unique key</param>
        /// <returns>Instance of TObject</returns>
        public TObject GetCached<TObject>(string key)
        {
            if (_cache.Any(w => w.Key == key))
            {
                return (TObject)_cache.Get(key);
            }
            return default(TObject);
        }

        /// <summary>
        /// Remove an instance of TObject
        /// </summary>
        /// <param name="key">Unique key</param>
        public void RemoveCached(string key)
        {
            if (_cache.Any(w => w.Key == key))
            {
                _cache.Remove(key);
            }
        }
    }
}
