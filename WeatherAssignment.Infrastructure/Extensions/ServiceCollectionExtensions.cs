using Hangfire;
using Hangfire.Storage.SQLite;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WeatherAssignment.Core.Interface;
using WeatherAssignment.Infrastructure.Meteo;
using WeatherAssignment.Infrastructure.Persistence;
using WeatherAssignment.Infrastructure.Scheduling;

namespace WeatherAssignment.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<WeatherDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork<WeatherDbContext>>();
        services.AddScoped<DatabaseSeeder>();

        services.AddHangfire(configuration =>
        {
            var jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            configuration.UseSerializerSettings(jsonSettings);
            configuration.UseSQLiteStorage();
        });
        services.AddHangfireServer();

        services.AddScoped<IBackgroundMediator, BackgroundMediator>();
        services.AddScoped<IWeatherProvider, WeatherProvider>();

        return services;
    }
}