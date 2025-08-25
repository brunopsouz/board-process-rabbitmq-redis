using RabbitMQ.Client;

namespace ComponentConsumption.Model.Services.MessageQueue.RabbitMQ
{
    public interface IRabbitMqFactoryProvider
    {
        ConnectionFactory CreateFactory();
    }
}
