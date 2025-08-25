using ComponentConsumption.Model.Services.MessageQueue.RabbitMQ;
using ComponentConsumption.Model.SettingsExtensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;

public class RabbitMqConnection : IRabbitMqConnection
{
    private readonly ILogger<RabbitMqConnection> _logger;
    private readonly IRabbitMqFactoryProvider _factoryProvider;
    private readonly IRetryPolicyProvider _retryPolicyProvider;

    private IConnection? _connection;

    public RabbitMqConnection(
        ILogger<RabbitMqConnection> logger,
        IRabbitMqFactoryProvider factoryProvider,
        IRetryPolicyProvider retryPolicyProvider)
    {
        _logger = logger;
        _factoryProvider = factoryProvider;
        _retryPolicyProvider = retryPolicyProvider;
    }

    public async Task ConnectAsync()
    {
        var factory = _factoryProvider.CreateFactory();
        var policy = _retryPolicyProvider.CreatePolicy();

        await policy.ExecuteAsync( async () =>
        {
            _connection = await factory.CreateConnectionAsync();
            _logger.LogInformation($"[RabbitMQ] Conexão estabelecida com sucesso em {factory.HostName}:{factory.Port}",
            factory.HostName, factory.Port);
        });
    }

    public IConnection GetConnection() => _connection
        ?? throw new InvalidOperationException("RabbitMQ não conectado ainda");

    public void Dispose() => _connection?.Dispose();
}
