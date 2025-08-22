namespace ComponentConsumption.Model.Services
{
    public interface IMessageProducer
    {
        void SendingMessage<T>(T message);
    }
}
