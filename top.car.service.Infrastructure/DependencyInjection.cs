namespace top.car.service.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using top.car.service.Domain.Interface.Repositories;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Register DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"))
            .EnableSensitiveDataLogging()
            
            );

        // Register repositories
        services.AddScoped<ICarServiceRepositoryManager, CarServiceRepositoryManager>();

        return services;
    }
}