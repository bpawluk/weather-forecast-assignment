using MediatR;

namespace WeatherAssignment.Application.Queries.GetLocations;

internal class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, GetLocationsQuery.Result>
{
    public Task<GetLocationsQuery.Result> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}