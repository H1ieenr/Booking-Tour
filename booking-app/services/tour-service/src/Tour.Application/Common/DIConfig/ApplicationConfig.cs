using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Common;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Application.Common
{
    public static class ApplicationConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.Configure<ImageSettings>(configuration.GetSection("SettingConfig:Image"));
            return services;
        }
    }
}