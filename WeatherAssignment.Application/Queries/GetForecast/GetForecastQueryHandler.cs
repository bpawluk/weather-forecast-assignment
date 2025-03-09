using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherAssignment.Core;
using WeatherAssignment.Core.Interface;
using WeatherAssignment.Core.Values;

namespace WeatherAssignment.Application.Queries.GetForecast;

internal class GetForecastQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetForecastQuery, GetForecastQuery.Result>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<GetForecastQuery.Result> Handle(GetForecastQuery request, CancellationToken cancellationToken)
    {
        var forecasts = _unitOfWork.Set<Forecast>();

        var targetCoordinates = new Coordinates(request.Latitude, request.Longitude);
        var forecast = await forecasts.SingleOrDefaultAsync(x =>
            x.Location.Coordinates.Latitude == targetCoordinates.Latitude &&
            x.Location.Coordinates.Longitude == targetCoordinates.Longitude, cancellationToken);

        if (forecast is null)
        {
            throw new Exception("NOT FOUND");
        }

        return new(new(
            forecast.Updated,
            forecast.Values
                .Select(value => new GetForecastQuery.ForecastValue(
                    value.Time,
                    value.Temperature.Value,
                    value.Precipitation.Value,
                    value.Pressure.Value))
                .ToArray()));
    }
}