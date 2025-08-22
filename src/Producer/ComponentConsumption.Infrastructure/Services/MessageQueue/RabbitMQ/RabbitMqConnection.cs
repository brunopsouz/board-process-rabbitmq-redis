using ComponentConsumption.Model.Services.MessageQueue.RabbitMQ;
using ComponentConsumption.Model.SettingsExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace ComponentConsumption.Infrastructure.Services.MessageQueue.RabbitMQ
{
    public class RabbitMqConnection : IRabbitMqConnection
    {
        private readonly IConnection _connection;

        public RabbitMqConnection(IOptions<RabbitMqSettings> options, IConnection connection)
        {
            var settings = options.Value;
            var factory = new ConnectionFactory
            {
                HostName = settings.HostName,
                UserName = settings.UserName,
                Password = settings.Password,
            };

            _connection = connection = (IConnection)factory.CreateConnectionAsync();
        }

        public IConnection GetConnection() => _connection;

        public void Dispose()
        {
            _connection?.Dispose();
        }

    }
}
