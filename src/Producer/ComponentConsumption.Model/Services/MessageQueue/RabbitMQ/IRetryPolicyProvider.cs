using Polly.Retry;

namespace ComponentConsumption.Model.Services.MessageQueue.RabbitMQ
{
    public interface IRetryPolicyProvider
    {
        AsyncRetryPolicy CreatePolicy();
    }
}
