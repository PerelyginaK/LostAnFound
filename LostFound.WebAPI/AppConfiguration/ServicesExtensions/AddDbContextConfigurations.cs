using LostFound.Entity;
using Microsoft.EntityFrameworkCore;

namespace LostFound.WebAPI.AppConfiguration.ServicesExtensions;

public static partial class ServicesExtensions
{
    /// <summary>
    /// Add serilog configuration
    /// </summary>
    /// <param name="builder"></param>
    public static void AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Context");
        services.AddDbContext<Context>(options =>
        {
            options
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString, sqlServerOption =>
                        {
                            sqlServerOption.CommandTimeout(60 * 60); // 1 hour
                        });

        });
    }
}