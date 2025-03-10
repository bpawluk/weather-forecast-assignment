using System.Globalization;
using System.Net.Http.Json;
using WeatherAssignment.Core;
using WeatherAssignment.Core.Interface;
using WeatherAssignment.Core.Values;

namespace WeatherAssignment.Infrastructure.Meteo;

internal class WeatherProvider(HttpClient httpClient) : IWeatherProvider
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IReadOnlyDictionary<Coordinates, IReadOnlyList<ForecastValue>>> GetWeatherAsync(IReadOnlySet<Coordinates> locationsCoordinates, CancellationToken cancellationToken)
    {
        var weatherData = new Dictionary<Coordinates, IReadOnlyList<ForecastValue>>();

        var coordinates = locationsCoordinates.ToArray();
        var latitudes = string.Join(",", coordinates.Select(c => c.Latitude.ToString(CultureInfo.InvariantCulture)));
        var longitudes = string.Join(",", coordinates.Select(c => c.Longitude.ToString(CultureInfo.InvariantCulture)));

        var responses = await _httpClient.GetFromJsonAsync<OpenMeteoResponse[]>(
            $"https://api.open-meteo.com/v1/forecast" +
            $"?latitude={latitudes}" +
            $"&longitude={longitudes}" +
            $"&hourly=temperature_2m,precipitation_probability,surface_pressure",
            cancellationToken);

        if (responses != null)
        {
            for (int i = 0; i < responses.Length; i++)
            {
                var response = responses[i];
                var forecastValues = response.Hourly.Time
                    .Select((time, index) => new ForecastValue(
                        DateTimeOffset.Parse(time, null, DateTimeStyles.AssumeUniversal),
                        response.Hourly.Temperature[index],
                        response.Hourly.Precipitation[index],
                        response.Hourly.Pressure[index]))
                    .ToList();
                weatherData.Add(coordinates[i], forecastValues);
            }
        }

        return weatherData;
    }
}