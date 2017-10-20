using System;
using System.Threading.Tasks;

namespace PrimeWeb.Service.CacheService
{
    /// <summary>
    /// Memory based cache service
    /// implemented ICacheService
    /// </summary>
    public class MemoryCacheService : ICacheService
    {
        private System.Runtime.Caching.MemoryCache cache;
        private ILogService _logService;

        public MemoryCacheService(string options, ILogService logService)
        {
            cache = new System.Runtime.Caching.MemoryCache(options);
            _logService = logService;
        }

        public async Task<bool> AddCache<TObject>(string key, TObject data, DateTimeOffset expireOffset)
        {
            try
            {
                return await Task.Run(() => cache.Add(key, data, expireOffset));
            }
            catch (Exception ex)
            {
                _logService.Error("Cache error", ex);
                return await Task.FromResult(false);
            }
        }

        public async Task<TObject> GetCached<TObject>(string key)
        {
            try
            {
                return await Task.Run(() => (TObject)cache.Get(key));
            }
            catch (Exception ex)
            {
                _logService.Error("Cache error", ex);
                return await Task.FromResult(default(TObject));
            }
        }

        public void RemoveCached(string key)
        {
            try
            {
                cache.Remove(key);
            }
            catch (Exception ex)
            {
                _logService.Error("Cache error", ex);
            }
        }
    }
}
