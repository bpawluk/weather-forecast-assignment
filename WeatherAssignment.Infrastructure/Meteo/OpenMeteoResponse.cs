using System.Text.Json.Serialization;

namespace WeatherAssignment.Infrastructure.Meteo;

internal record OpenMeteoResponse(
    [property: JsonPropertyName("latitude")] decimal Latitude,
    [property: JsonPropertyName("longitude")] decimal Longitude,
    [property: JsonPropertyName("hourly")] OpenMeteoResponse.HourlyData Hourly)
{
    public record HourlyData(
        [property: JsonPropertyName("time")] string[] Time,
        [property: JsonPropertyName("temperature_2m")] float[] Temperature,
        [property: JsonPropertyName("precipitation_probability")] int[] Precipitation,
        [property: JsonPropertyName("surface_pressure")] float[] Pressure
    );
}