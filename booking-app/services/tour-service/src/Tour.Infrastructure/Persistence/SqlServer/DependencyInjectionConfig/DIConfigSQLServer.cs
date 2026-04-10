

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Persistence
{
    public static class DIConfigSQLServer
    {
        public static IServiceCollection UseSqlServer(this IServiceCollection services, IConfiguration configuration)
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
        
            // Bạn nên khai báo đăng ký Repository tại đây để tập trung quản lý
            // services.AddScoped<ITourRepository, TourRepository>();

            return services;
        }
    }
}