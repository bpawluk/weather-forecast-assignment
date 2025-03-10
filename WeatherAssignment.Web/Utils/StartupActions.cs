using WeatherAssignment.Infrastructure.Persistence;

namespace WeatherAssignment.Web.Utils;

public interface IStartupActions
{
    Task ExecuteAsync();
}

public class StartupActions(DatabaseSeeder databaseSeeder) : IStartupActions
{
    private readonly DatabaseSeeder _databaseSeeder = databaseSeeder;

    public async Task ExecuteAsync()
    {
        await _databaseSeeder.SeedAsync();
    }
}