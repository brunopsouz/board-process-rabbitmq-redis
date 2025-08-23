using ComponentConsumption.Infrastructure.DataAccess;
using ComponentConsumption.Infrastructure.Services.Cache;
using ComponentConsumption.Infrastructure.Services.MessageQueue.RabbitMQ;
using ComponentConsumption.Model.Services.Cache;
using ComponentConsumption.Model.Services.MessageQueue;
using ComponentConsumption.Model.Services.MessageQueue.RabbitMQ;
using ComponentConsumption.Model.SettingsExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace ComponentConsumption.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IDatabase database)
        {
            AddQueue(services, configuration);
            AddDbContext(services);
            AddCache(services, configuration, database);
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

        private static void AddCache(IServiceCollection services, IConfiguration configuration, IDatabase database)
        {
            
            var connectionString = configuration.GetValue<string>("ConnectionStrings:Redis");
            
            if (string.IsNullOrWhiteSpace(connectionString))
                return;
            
            var redis = ConnectionMultiplexer.Connect(connectionString);

            database = redis.GetDatabase();

            services.AddSingleton<IRedisCacheService>(c =>
                new RedisCacheService(database)
            );
        }
    }
}
