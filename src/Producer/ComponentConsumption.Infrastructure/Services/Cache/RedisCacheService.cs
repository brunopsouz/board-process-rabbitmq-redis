using ComponentConsumption.Model.Services.Cache;
using StackExchange.Redis;

namespace ComponentConsumption.Infrastructure.Services.Cache
{
    public class RedisCacheService : IRedisCacheService
    {
        private IDatabase _database;

        public RedisCacheService(IDatabase database)
        {
            _database = database;
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
