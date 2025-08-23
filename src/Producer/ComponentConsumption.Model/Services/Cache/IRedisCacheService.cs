namespace ComponentConsumption.Model.Services.Cache
{
    public interface IRedisCacheService
    {
        Task<int> GetLastConsumedIdAsync();
        Task SetLastConsumedIdAsync(int id);

    }
}
