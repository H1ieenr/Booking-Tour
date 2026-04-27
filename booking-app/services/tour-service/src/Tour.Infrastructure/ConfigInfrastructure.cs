using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigInfrastructure
    {
        public static IServiceCollection AddTourInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConfigSQLServer(configuration);
            services.AddServicesExtensions(configuration);
            return services;
        }
    }
}