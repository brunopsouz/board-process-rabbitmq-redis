using ComponentConsumption.Model.Services.MessageQueue.RabbitMQ;
using ComponentConsumption.Model.SettingsExtensions;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace ComponentConsumption.Infrastructure.Services.MessageQueue.RabbitMQ
{
    public class RabbitMqFactoryProvider : IRabbitMqFactoryProvider
    {
        private readonly IOptions<RabbitMqSettings> _settings;

        public RabbitMqFactoryProvider(IOptions<RabbitMqSettings> settings)
        {
            _settings = settings;
        }

        public ConnectionFactory CreateFactory()
        {
            var cfg = _settings.Value;
            return new ConnectionFactory
            {
                HostName = cfg.HostName,
                UserName = cfg.UserName,
                Password = cfg.Password,
                Port = int.Parse(cfg.Port)
            };
        }
    }
}
