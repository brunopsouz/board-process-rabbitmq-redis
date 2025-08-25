using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ComponentConsumption.Application.Service;

namespace ComponentConsumption.Application
{
    public static class DependencyInjectionExtensions
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddServices(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IGetComponentConsumption, GetComponentConsumption>();
        }
    }
}
