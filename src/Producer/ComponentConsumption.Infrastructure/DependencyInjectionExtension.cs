using ComponentConsumption.Infrastructure.DataAccess;
using ComponentConsumption.Infrastructure.Services.MessageQueue.RabbitMQ;
using ComponentConsumption.Model;
using ComponentConsumption.Model.Services;
using ComponentConsumption.Model.Services.MessageQueue.RabbitMQ;
using ComponentConsumption.Model.SettingsExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace ComponentConsumption.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddQueue(services, configuration);
            AddDbContext(services);
        }

        private static void AddDbContext(IServiceCollection services)
        {
            services.AddScoped<DatabaseFactory>();
        }

        private static void AddQueue(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMqSettings>(options =>
            {
                options.HostName = configuration["RabbitMq:HostName"]!;
                options.UserName = configuration["RabbitMq:UserName"]!;
                options.Password = configuration["RabbitMq:Password"]!;
            });

            services.AddSingleton<IRabbitMqConnection, RabbitMqConnection>();

            services.AddScoped<IMessageProducer, RabbitMqProducer>();
        }
    }
}
