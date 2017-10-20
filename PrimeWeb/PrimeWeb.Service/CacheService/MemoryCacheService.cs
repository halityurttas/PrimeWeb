using PrimeWeb.Core.Caching;
using System;

namespace PrimeWeb.Service.CacheService
{
    public class MemoryCacheService : ICacheService
    {
        private ICache _cache;
        private ILogService _logService;

        public MemoryCacheService(ICache cache, ILogService logService)
        {
            _cache = cache;
            _logService = logService;
        }

        public bool AddCache<TObject>(string key, TObject data, DateTimeOffset expireOffset)
        {
            try
            {
                return _cache.AddCache(key, data, expireOffset);
            }
            catch (Exception ex)
            {
                _logService.Error("Cache error", ex);
                return false;
            }
        }

        public TObject GetCached<TObject>(string key)
        {
            try
            {
                return _cache.GetCached<TObject>(key);
            }
            catch (Exception ex)
            {
                _logService.Error("Cache error", ex);
                return default(TObject);
            }
        }

        public void RemoveCached(string key)
        {
            try
            {
                _cache.RemoveCached(key);
            }
            catch (Exception ex)
            {
                _logService.Error("Cache error", ex);
            }
        }
    }
}
