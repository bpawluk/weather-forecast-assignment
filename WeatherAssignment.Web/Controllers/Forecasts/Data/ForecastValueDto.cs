namespace WeatherAssignment.Web.Controllers.Forecasts.Data;

public record ForecastValueDto(
    DateTimeOffset Time,
    float Temperature,
    int Precipitation,
    float Pressure);