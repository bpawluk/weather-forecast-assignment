using System.Collections.Immutable;
using MediatR;

namespace WeatherAssignment.Application.Queries.GetLocations;

public record GetLocationsQuery() : IRequest<GetLocationsQuery.Response>
{
    public record Response(IImmutableList<Location> Locations);

    public record Location(string Name, decimal Latitude, decimal Longitude);
}