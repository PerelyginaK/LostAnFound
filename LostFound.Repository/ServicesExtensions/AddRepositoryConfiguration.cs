using LostFound.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LostFound.Repository;

public static partial class ServicesExtensions
{
    public static void AddRepositoryConfiguration(this IServiceCollection services)
    {
        services.AddScoped<DbContext, Context>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}