
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Domain.Interfaces;

namespace Infrastructure.Persistence
{
    public static class ConfigSQLServer
    {
        public static IServiceCollection AddConfigSQLServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TourDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b =>
                {
                    b.MigrationsAssembly("Tour.Infrastructure");
                    b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });

                options.ConfigureWarnings(w =>
                    w.Ignore(RelationalEventId.PendingModelChangesWarning));
            });
            services.AddScoped<DbContext>(provider => provider.GetRequiredService<TourDbContext>());
            services.AddScoped<ITravelTourRepository, TravelTourRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            return services;
        }
    }
}