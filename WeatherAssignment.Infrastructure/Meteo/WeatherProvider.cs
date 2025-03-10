using WeatherAssignment.Core;
using WeatherAssignment.Core.Interface;
using WeatherAssignment.Core.Values;

namespace WeatherAssignment.Infrastructure.Meteo;

internal class WeatherProvider : IWeatherProvider
{
    public Task<IReadOnlyDictionary<Coordinates, IReadOnlyList<ForecastValue>>> GetWeatherAsync(IReadOnlySet<Coordinates> locationsCoordinates, CancellationToken cancellationToken)
    {
        var weather = locationsCoordinates.Select(x => new KeyValuePair<Coordinates, IReadOnlyList<ForecastValue>>(x,
        [
            new(DateTimeOffset.UtcNow, 10, 50, 1000),
            new(DateTimeOffset.UtcNow.AddHours(1), 5, 70, 1005),
            new(DateTimeOffset.UtcNow.AddHours(2), 2, 90, 1010)
        ])).ToDictionary(x => x.Key, x => x.Value);
        return Task.FromResult<IReadOnlyDictionary<Coordinates, IReadOnlyList<ForecastValue>>>(weather);
    }
}