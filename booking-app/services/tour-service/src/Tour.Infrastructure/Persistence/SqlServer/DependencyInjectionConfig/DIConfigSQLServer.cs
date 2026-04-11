

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Domain.Interfaces;
using Shared.Persistence;

namespace Infrastructure.Persistence
{
    public static class DIConfigSQLServer
    {
        public static IServiceCollection AddTourInfrastructure(this IServiceCollection services, IConfiguration configuration)
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
        
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<,>));
            services.AddScoped<ITravelTourRepository, TravelTourRepository>();
            
            return services;
        }
    }
}