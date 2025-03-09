using Microsoft.Extensions.DependencyInjection;
using WeatherAssignment.Core.Interface;
using WeatherAssignment.Infrastructure.Persistence;

namespace WeatherAssignment.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<WeatherDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork<WeatherDbContext>>();
        return services;
    }
}