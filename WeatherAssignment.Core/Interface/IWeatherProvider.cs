using WeatherAssignment.Core.Values;

namespace WeatherAssignment.Core.Interface;

public interface IWeatherProvider
{
    Task<IReadOnlyDictionary<Coordinates, IReadOnlyList<ForecastValue>>> GetWeatherAsync(IReadOnlySet<Coordinates> locationsCoordinates, CancellationToken cancellationToken);
}