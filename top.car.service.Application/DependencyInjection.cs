
namespace top.car.service.Application;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using top.car.service.Application.Interface;
using top.car.service.Application.Services;
using top.car.service.Domain.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        // Register Services
        // services.AddDbContext<AppDbContext>(options =>
        //     options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        services.AddScoped<IReqFromService, ReqFromService>();
        services.AddScoped<IMasterDataService, MasterDataService>();



   

        return services;
    }
}