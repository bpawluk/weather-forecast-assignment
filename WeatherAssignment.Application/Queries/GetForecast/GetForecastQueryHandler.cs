using MediatR;

namespace WeatherAssignment.Application.Queries.GetForecast;

internal class GetForecastQueryHandler : IRequestHandler<GetForecastQuery, GetForecastQuery.Result>
{
    public Task<GetForecastQuery.Result> Handle(GetForecastQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}