using MediatR;

namespace WeatherAssignment.Application.Queries.GetForecast;

public record GetForecastQuery(
    decimal Latitude,
    decimal Longitude) 
    : IRequest<GetForecastQuery.Result>
{
    public record Result(Forecast Forecast);

    public record Forecast(
        DateTimeOffset Updated,
        IReadOnlyList<ForecastValue> Values);

    public record ForecastValue(
        DateTimeOffset Time,
        float Temperature,
        int Precipitation,
        float Pressure);
}