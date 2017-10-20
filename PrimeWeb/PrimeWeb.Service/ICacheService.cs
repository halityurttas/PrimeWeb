using System;

namespace PrimeWeb.Service
{
    public interface ICacheService
    {
        bool AddCache<TObject>(string key, TObject data, DateTimeOffset expireOffset);
        TObject GetCached<TObject>(string key);
        void RemoveCached(string key);
    }
}
