using ComponentConsumption.Model.Services.Cache;
using ComponentConsumption.Model.SettingsExtensions;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace ComponentConsumption.Infrastructure.Services.Cache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDatabase _database;
        private readonly IOptions<RedisSettings> _options;


        public RedisCacheService(
            IOptions<RedisSettings> options)
        {
            _options = options;

            var settings = _options.Value;
            var redis = ConnectionMultiplexer.Connect(settings.Database);
            _database = redis.GetDatabase();
        }

        public async Task<int> GetLastConsumedIdAsync()
        {
            var value = await _database.StringGetAsync("LastConsumedId");
            return value.HasValue ? (int)value : 0;
        }

        public async Task SetLastConsumedIdAsync(int id)
        {
            await _database.StringSetAsync("LastConsumedId", id);
        }

        
    }
}
