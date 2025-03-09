namespace WeatherAssignment.Web.Controllers.Forecasts.Data;

public record ForecastDto(
    DateTimeOffset Updated,
    ForecastDto.Value[] Values)
{
    public record Value(
        DateTimeOffset Time,
        float Temperature,
        int Precipitation,
        float Pressure);
}