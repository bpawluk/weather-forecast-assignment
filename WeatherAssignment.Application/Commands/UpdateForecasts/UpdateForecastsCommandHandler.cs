using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherAssignment.Core;
using WeatherAssignment.Core.Interface;
using WeatherAssignment.Core.Values;

namespace WeatherAssignment.Application.Commands.UpdateForecasts;

internal class UpdateForecastsCommandHandler(IUnitOfWork unitOfWork, IWeatherProvider weatherProvider) : IRequestHandler<UpdateForecastsCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IWeatherProvider _weatherProvider = weatherProvider;

    public async Task Handle(UpdateForecastsCommand request, CancellationToken cancellationToken)
    {
        var coordinates = request.LocationsCoordinates.Select(x => new Coordinates(x.Latitude, x.Longitude)).ToHashSet();
        var newWeatherForecasts = await _weatherProvider.GetWeatherAsync(coordinates, cancellationToken);

        var forecasts = _unitOfWork.Set<Forecast>();

        foreach(var (locationCoordinates, newForecastValues) in newWeatherForecasts)
        {
            var forecast = await forecasts
                .Include(x => x.Values)
                .SingleOrDefaultAsync(x =>
                    x.Location.Coordinates.Latitude == locationCoordinates.Latitude &&
                    x.Location.Coordinates.Longitude == locationCoordinates.Longitude, cancellationToken);

            if (forecast is not null)
            {
                forecast.Update(newForecastValues);
                try
                {
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateConcurrencyException) { }
            }
        } 
    }
}