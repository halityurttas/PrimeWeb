using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace PrimeWeb.Service.CacheService
{

    /// <summary>
    /// Redis cache service
    /// implements ICacheService
    /// https://redis.io/
    /// The client is StackExchange Redis api
    /// https://github.com/StackExchange/StackExchange.Redis
    /// </summary>
    public class RedisCacheService : ICacheService
    {
        ConnectionMultiplexer con;
        IDatabase database;
        ILogService logService;

        public RedisCacheService(string options, ILogService logService, int dbId = -1)
        {
            var configOption = ConfigurationOptions.Parse(options);
            con = ConnectionMultiplexer.Connect(configOption);
            database = con.GetDatabase(dbId);
            this.logService = logService;
        }

        public bool AddCache<TObject>(string key, TObject data, DateTimeOffset expireOffset)
        {
            try
            {
                return database.StringSet(key, JsonConvert.SerializeObject(data), expiry: expireOffset.Offset);
            }
            catch (Exception ex)
            {
                logService.Error("Cache error", ex);
                return false;
            }
        }

        public TObject GetCached<TObject>(string key)
        {
            try
            {
                var result = database.StringGet(key);
                return JsonConvert.DeserializeObject<TObject>(result.ToString());
            }
            catch (Exception ex)
            {
                logService.Error("Cache error", ex);
                return default(TObject);
            }
        }

        public void RemoveCached(string key)
        {
            throw new NotImplementedException();
        }
    }
}
