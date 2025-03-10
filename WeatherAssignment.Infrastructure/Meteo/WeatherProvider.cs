using WeatherAssignment.Core;
using WeatherAssignment.Core.Interface;
using WeatherAssignment.Core.Values;

namespace WeatherAssignment.Infrastructure.Meteo;

internal class WeatherProvider : IWeatherProvider
{
    public Task<IReadOnlyList<ForecastValue>> GetWeatherAsync(IReadOnlySet<Coordinates> locationsCoordinates)
    {
        throw new NotImplementedException();
    }
}