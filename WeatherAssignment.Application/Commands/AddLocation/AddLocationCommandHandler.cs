using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherAssignment.Core;
using WeatherAssignment.Core.Exceptions;
using WeatherAssignment.Core.Interface;
using WeatherAssignment.Core.Values;

namespace WeatherAssignment.Application.Commands.AddLocation;

internal class AddLocationCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddLocationCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(AddLocationCommand request, CancellationToken cancellationToken)
    {
        var locations = _unitOfWork.Set<Location>();

        var targetCoordinates = new Coordinates(request.Latitude, request.Longitude);
        var location = await locations.SingleOrDefaultAsync(x =>
            x.Coordinates.Latitude == targetCoordinates.Latitude &&
            x.Coordinates.Longitude == targetCoordinates.Longitude, cancellationToken);

        if (location is not null)
        {
            throw new EntityAlreadyExistsException($"A Location with Coordinates {targetCoordinates} already exists.");
        }

        var locationToAdd = new Location(
            request.Name,
            request.Latitude,
            request.Longitude);
        locations.Add(locationToAdd);

        var forecasts = _unitOfWork.Set<Forecast>();
        var forecastToAdd = Forecast.Empty(locationToAdd);
        forecasts.Add(forecastToAdd);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}