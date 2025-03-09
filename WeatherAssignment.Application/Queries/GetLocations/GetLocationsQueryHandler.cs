using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherAssignment.Core;
using WeatherAssignment.Core.Interface;

namespace WeatherAssignment.Application.Queries.GetLocations;

internal class GetLocationsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetLocationsQuery, GetLocationsQuery.Result>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<GetLocationsQuery.Result> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
    {
        var locations = _unitOfWork.Set<Location>();
        var result = await locations
            .Select(location => new GetLocationsQuery.Location(
                location.Name, 
                location.Coordinates.Latitude, 
                location.Coordinates.Longitude))
            .ToListAsync(cancellationToken);
        return new(result);
    }
}