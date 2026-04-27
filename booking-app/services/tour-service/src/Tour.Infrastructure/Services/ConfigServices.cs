using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Common;

namespace Infrastructure.Services
{
    public static class ConfigServices
    {
        public static IServiceCollection AddServicesExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IImageService, ImageService>();            
            return services;
        }
    }
}