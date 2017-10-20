using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

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

        public async Task<bool> AddCache<TObject>(string key, TObject data, DateTimeOffset expireOffset)
        {
            try
            {
                return await database.StringSetAsync(key, JsonConvert.SerializeObject(data), expiry: expireOffset.Offset);
            }
            catch (Exception ex)
            {
                logService.Error("Cache error", ex);
                return await Task.FromResult(false);
            }
        }

        public async Task<TObject> GetCached<TObject>(string key)
        {
            try
            {
                var result = await database.StringGetAsync(key);
                return JsonConvert.DeserializeObject<TObject>(result.ToString());
            }
            catch (Exception ex)
            {
                logService.Error("Cache error", ex);
                return await Task.FromResult(default(TObject));
            }
        }

        public void RemoveCached(string key)
        {
            throw new NotImplementedException();
        }
    }
}
