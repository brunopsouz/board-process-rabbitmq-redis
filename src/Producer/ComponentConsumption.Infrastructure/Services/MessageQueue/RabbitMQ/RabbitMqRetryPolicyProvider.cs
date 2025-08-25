using ComponentConsumption.Model.Services.MessageQueue.RabbitMQ;
using ComponentConsumption.Model.SettingsExtensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;

namespace ComponentConsumption.Infrastructure.Services.MessageQueue.RabbitMQ
{
    public class RabbitMqRetryPolicyProvider : IRetryPolicyProvider
    {
        private readonly ILogger<RabbitMqConnection> _logger;
        private readonly IOptions<RabbitMqSettings> _settings;

        public RabbitMqRetryPolicyProvider(
            IOptions<RabbitMqSettings> settings,
            ILogger<RabbitMqConnection> logger)
        {
            _logger = logger;
            _settings = settings;
        }

        public AsyncRetryPolicy CreatePolicy()
        {
            return Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(
                    retryCount: _settings.Value.RetryCount,
                    sleepDurationProvider: attempt => TimeSpan.FromSeconds(
                        Math.Pow(_settings.Value.RetryBaseDelaySeconds, attempt)),
                    onRetry: (ex, ts, attempt, _) =>
                    {
                        _logger.LogWarning(ex,
                            "[RabbitMQ] Tentativa {Attempt} falhou. Retentando em {Delay}s...",
                            attempt, ts.TotalSeconds);
                    });
        }
    }
}
