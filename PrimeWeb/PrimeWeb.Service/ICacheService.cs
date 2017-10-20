using System;

namespace PrimeWeb.Service
{
    /// <summary>
    /// Cache service
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// Add object to cache
        /// </summary>
        /// <typeparam name="TObject">Type of object</typeparam>
        /// <param name="key">string unique key</param>
        /// <param name="data">Instance of TObject</param>
        /// <param name="expireOffset">Cache expire from offset</param>
        /// <returns>true is success</returns>
        bool AddCache<TObject>(string key, TObject data, DateTimeOffset expireOffset);

        /// <summary>
        /// Get object from cache
        /// </summary>
        /// <typeparam name="TObject">Type of return object</typeparam>
        /// <param name="key">string unique key</param>
        /// <returns>Instance of TObject</returns>
        TObject GetCached<TObject>(string key);

        /// <summary>
        /// Remove object by unique string key from cache
        /// </summary>
        /// <param name="key">string unique key</param>
        void RemoveCached(string key);
    }
}
