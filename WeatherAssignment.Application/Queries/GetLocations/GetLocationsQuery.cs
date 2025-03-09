using MediatR;

namespace WeatherAssignment.Application.Queries.GetLocations;

public record GetLocationsQuery() : IRequest<GetLocationsQuery.Result>
{
    public record Result(IReadOnlyList<Location> Locations);

    public record Location(string Name, decimal Latitude, decimal Longitude);
}