using ComponentConsumption.Model.Models;

namespace ComponentConsumption.Model.Services.MessageQueue
{
    public interface IMessageProducer
    {
        Task SendingMessage(ComponentConsumptionModel components);
    }
}
