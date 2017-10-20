using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeWeb.Service.CacheService
{
    public class RedisCacheService : ICacheService
    {
        ConnectionMultiplexer con;
        IDatabase database;

        public RedisCacheService(string options, ILogService logService, int dbId = -1)
        {
            var configOption = ConfigurationOptions.Parse(options);
            con = ConnectionMultiplexer.Connect(configOption);
            database = con.GetDatabase(dbId);
        }

        public bool AddCache<TObject>(string key, TObject data, DateTimeOffset expireOffset)
        {
            throw new NotImplementedException();
        }

        public TObject GetCached<TObject>(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveCached(string key)
        {
            throw new NotImplementedException();
        }
    }
}
