using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherAssignment.Core;
using WeatherAssignment.Core.Interface;
using WeatherAssignment.Core.Values;

namespace WeatherAssignment.Application.Commands.DeleteLocation;

internal class DeleteLocationCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteLocationCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var locations = _unitOfWork.Set<Location>();

        var targetCoordinates = new Coordinates(request.Latitude, request.Longitude);
        var location = await locations.SingleOrDefaultAsync(x =>
            x.Coordinates.Latitude == targetCoordinates.Latitude &&
            x.Coordinates.Longitude == targetCoordinates.Longitude, cancellationToken);

        if (location is not null)
        {
            locations.Remove(location);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}