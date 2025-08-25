using ComponentConsumption.Application;
using ComponentConsumption.Application.Service;
using ComponentConsumption.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        // Injeção de dependências da Application e Infrastructure
        services.AddApplication(configuration);
        services.AddInfrastructure(configuration);
    })
    .Build();

// Criamos um escopo para pegar serviços Scoped
using var scope = host.Services.CreateScope();

// Resolve pelo contrato (IGetComponentConsumption) registrado no DI
var service = scope.ServiceProvider.GetRequiredService<IGetComponentConsumption>();

await service.RunAsync();