using Hangfire;
using WeatherAssignment.Application.Commands.UpdateForecastsAll;
using WeatherAssignment.Core.Interface;
using WeatherAssignment.Infrastructure.Persistence;

namespace WeatherAssignment.Web.Utils;

public interface IStartupActions
{
    Task ExecuteAsync();
}

public class StartupActions(IBackgroundMediator mediator, DatabaseSeeder databaseSeeder) : IStartupActions
{
    private readonly IBackgroundMediator _mediator = mediator;
    private readonly DatabaseSeeder _databaseSeeder = databaseSeeder;

    public async Task ExecuteAsync()
    {
        await _databaseSeeder.SeedAsync();
        _mediator.Enqueue(new UpdateForecastsAllCommand());
        _mediator.Schedule(new UpdateForecastsAllCommand(), "hourly-weather-update", Cron.Hourly());
    }
}