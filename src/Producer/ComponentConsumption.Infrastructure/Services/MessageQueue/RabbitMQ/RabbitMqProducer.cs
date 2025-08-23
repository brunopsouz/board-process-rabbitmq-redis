using ComponentConsumption.Model.Services.MessageQueue;
using ComponentConsumption.Model.Services.MessageQueue.RabbitMQ;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ComponentConsumption.Infrastructure.Services.MessageQueue.RabbitMQ
{
    public class RabbitMqProducer : IMessageProducer
    {
        private readonly IRabbitMqConnection _connection;

        public RabbitMqProducer(IRabbitMqConnection connection)
        {
            _connection = connection;
        }

        public async void SendingMessage<T>(T message)
        {
            using var channel = await _connection.GetConnection().CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: "component-consumption",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            await channel.BasicPublishAsync(
                exchange: string.Empty,
                routingKey: "component-consumption",
                mandatory: true,
                basicProperties: new BasicProperties { Persistent = true },
                body: body);

            Console.WriteLine($"Sent - {message}");
            await Task.Delay(3000);

        }

        
    }
}
