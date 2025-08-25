using ComponentConsumption.Infrastructure.DataAccess;
using ComponentConsumption.Infrastructure.Repositories;
using ComponentConsumption.Infrastructure.Services.Cache;
using ComponentConsumption.Infrastructure.Services.MessageQueue.RabbitMQ;
using ComponentConsumption.Model.Repositories;
using ComponentConsumption.Model.Services.Cache;
using ComponentConsumption.Model.Services.MessageQueue;
using ComponentConsumption.Model.Services.MessageQueue.RabbitMQ;
using ComponentConsumption.Model.SettingsExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComponentConsumption.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddQueue(services, configuration);
            AddDbContext(services);
            AddCache(services, configuration);
        }

        private static void AddDbContext(IServiceCollection services)
        {
            services.AddScoped<DatabaseFactory>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IComponentConsumptionRepository, ComponentConsumptionRepository>();
        }

        private static void AddQueue(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMqSettings>(configuration.GetSection("RabbitMq"));

            services.AddHostedService<RabbitMqInitializer>();

            services.AddSingleton<IRabbitMqFactoryProvider, RabbitMqFactoryProvider>();
            services.AddSingleton<IRetryPolicyProvider, RabbitMqRetryPolicyProvider>();

            services.AddSingleton<IRabbitMqConnection, RabbitMqConnection>();

            services.AddScoped<IMessageProducer, RabbitMqProducer>();
        }

        private static void AddCache(IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<RedisSettings>(options =>
            {
                options.Database = configuration["ConnectionStrings:Redis"]!;
            });

            services.AddSingleton<IRedisCacheService, RedisCacheService>();
        }
    }
}
