using MediatR;

namespace WeatherAssignment.Application.Queries.GetLocations;

internal class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, GetLocationsQuery.Response>
{
    public Task<GetLocationsQuery.Response> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}