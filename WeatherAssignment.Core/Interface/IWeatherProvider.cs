using WeatherAssignment.Core.Values;

namespace WeatherAssignment.Core.Interface;

public interface IWeatherProvider
{
    Task<IReadOnlyList<ForecastValue>> GetWeatherAsync(IReadOnlySet<Coordinates> locationsCoordinates);
}