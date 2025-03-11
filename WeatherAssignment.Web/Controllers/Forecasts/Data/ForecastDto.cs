namespace WeatherAssignment.Web.Controllers.Forecasts.Data;

public record ForecastDto(
    DateTimeOffset Updated,
    ForecastValueDto[] Values);