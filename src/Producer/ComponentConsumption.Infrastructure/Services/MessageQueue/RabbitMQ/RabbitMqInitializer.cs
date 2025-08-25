using ComponentConsumption.Model.Services.MessageQueue.RabbitMQ;
using Microsoft.Extensions.Hosting;

namespace ComponentConsumption.Infrastructure.Services.MessageQueue.RabbitMQ
{
    public class RabbitMqInitializer : IHostedService
    {
        private readonly IRabbitMqConnection _connection;

        public RabbitMqInitializer(IRabbitMqConnection connection)
        {
            _connection = connection;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _connection.ConnectAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // fechar a conexão ao parar a aplicação:
            _connection.Dispose();
            return Task.CompletedTask;
        }
    }
}
