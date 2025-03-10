using Microsoft.EntityFrameworkCore;
using WeatherAssignment.Core;

namespace WeatherAssignment.Infrastructure.Persistence;

public class DatabaseSeeder(WeatherDbContext dbContext)
{
    private readonly WeatherDbContext _dbContext = dbContext;

    public async Task SeedAsync()
    {
        await _dbContext.Database.EnsureCreatedAsync();

        if (!await _dbContext.Locations.AnyAsync())
        {
            var locations = new List<Location>
            {
                new("Moscow", 55.7558m, 37.6176m),
                new("London", 51.5074m, -0.1278m),
                new("Berlin", 52.5200m, 13.4050m),
                new("Madrid", 40.4168m, -3.7038m),
                new("Rome", 41.9028m, 12.4964m),
                new("Paris", 48.8566m, 2.3522m),
                new("Bucharest", 44.4268m, 26.1025m),
                new("Vienna", 48.2082m, 16.3738m),
                new("Hamburg", 53.5511m, 9.9937m),
                new("Budapest", 47.4979m, 19.0402m),
                new("Warsaw", 52.2297m, 21.0122m),
                new("Barcelona", 41.3851m, 2.1734m),
                new("Munich", 48.1351m, 11.5820m),
                new("Milan", 45.4642m, 9.1900m),
                new("Prague", 50.0755m, 14.4378m),
                new("Sofia", 42.6977m, 23.3219m),
                new("Brussels", 50.8503m, 4.3517m),
                new("Birmingham", 52.4862m, -1.8904m),
                new("Cologne", 50.9375m, 6.9603m),
                new("Naples", 40.8518m, 14.2681m)
            };
            await _dbContext.Locations.AddRangeAsync(locations);

            var forecasts = locations.Select(Forecast.Empty);
            await _dbContext.Forecasts.AddRangeAsync(forecasts);

            await _dbContext.SaveChangesAsync();
        }
    }
}