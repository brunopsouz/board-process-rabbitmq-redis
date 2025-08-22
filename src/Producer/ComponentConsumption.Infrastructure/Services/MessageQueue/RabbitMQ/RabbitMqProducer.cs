using ComponentConsumption.Model.Services;

namespace ComponentConsumption.Infrastructure.Services.MessageQueue.RabbitMQ
{
    public class RabbitMqProducer : IMessageProducer
    {
        public void SendingMessage<T>(T message)
        {
            throw new NotImplementedException();
        }
    }
}
