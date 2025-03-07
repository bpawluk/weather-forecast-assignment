using System.Collections.Immutable;
using MediatR;

namespace WeatherAssignment.Application.Queries.GetForecast;

public record GetForecastQuery(
    decimal Latitude,
    decimal Longitude) 
    : IRequest<GetForecastQuery.Response>
{
    public record Response(Forecast Forecast);

    public record Forecast(
        DateTimeOffset Updated,
        IImmutableList<ForecastValue> Values);

    public record ForecastValue(
        DateTimeOffset Time,
        float Temperature,
        float Precipitation,
        float Pressure);
}