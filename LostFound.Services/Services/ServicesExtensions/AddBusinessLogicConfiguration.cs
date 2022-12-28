using LostFound.Services.Abstract;
using LostFound.Services.Implementation;
using LostFound.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;

namespace LostFound.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));

        //services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IBureauService, BureauService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IFindingService, FindingService>();
    }
}