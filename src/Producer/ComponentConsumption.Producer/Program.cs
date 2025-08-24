using ComponentConsumption.Application.Service;
using ComponentConsumption.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

        //services.AddSingleton<IComponentRepository, ComponentRepository>();
        services.AddInfrastructure(configuration);

        //services.AddSingleton<IRabbitMqPublisher, RabbitMqPublisher>();
        //services.AddSingleton<IRedisCacheService, RedisCacheService>();
        //services.AddScoped<ComponentService>();


       
        

    }).Build();



var service = builder.Services.GetRequiredService<GetComponentConsumption>();
await service.RunAsync();