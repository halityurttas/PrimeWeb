using System;

namespace PrimeWeb.Core.Caching
{
    public interface ICache
    {
        bool AddCache<TObject>(string key, TObject data, DateTimeOffset offset);
        TObject GetCached<TObject>(string key);
        void RemoveCached(string key);
    }
}
