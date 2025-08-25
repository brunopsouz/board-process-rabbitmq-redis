
using ComponentConsumption.Model.Repositories;
using ComponentConsumption.Model.Services.Cache;
using ComponentConsumption.Model.Services.MessageQueue;

namespace ComponentConsumption.Application.Service
{
    public class GetComponentConsumption : IGetComponentConsumption
    {
        private readonly IComponentConsumptionRepository _repository;
        private readonly IMessageProducer _producer;
        private readonly IRedisCacheService _cache;

        public GetComponentConsumption(
            IComponentConsumptionRepository repository,
            IMessageProducer producer,
            IRedisCacheService cache)
        {
            _repository = repository;
            _producer = producer;
            _cache = cache;
        }

        public async Task RunAsync()
        {
            while (true) 
            {
                var lastId = await _cache.GetLastConsumedIdAsync();

                if (lastId == 0)
                    lastId = 0;

                var components = await _repository.GetConsumedComponentsAsync(lastId);

                foreach (var component in components) 
                {
                    await _producer.SendingMessage(component);
                    await _cache.SetLastConsumedIdAsync(component.Id);

                    Console.WriteLine($"Sent message: {component.BoardType},{component.ComponentDescription} ");

                }

            }
        }
    }
}
