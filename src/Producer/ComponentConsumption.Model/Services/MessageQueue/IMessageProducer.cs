namespace ComponentConsumption.Model.Services.MessageQueue
{
    public interface IMessageProducer
    {
        void SendingMessage<T>(T message);
    }
}
