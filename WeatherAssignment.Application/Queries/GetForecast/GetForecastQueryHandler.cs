using MediatR;

namespace WeatherAssignment.Application.Queries.GetForecast;

internal class GetForecastQueryHandler : IRequestHandler<GetForecastQuery, GetForecastQuery.Response>
{
    public Task<GetForecastQuery.Response> Handle(GetForecastQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}