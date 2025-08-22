using RabbitMQ.Client;

namespace ComponentConsumption.Model.Services.MessageQueue.RabbitMQ
{
    public interface IRabbitMqConnection : IDisposable
    {
        IConnection GetConnection();
    }
}
