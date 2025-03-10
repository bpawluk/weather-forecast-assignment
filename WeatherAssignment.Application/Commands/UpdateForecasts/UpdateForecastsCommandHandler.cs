using MediatR;
using WeatherAssignment.Core.Interface;

namespace WeatherAssignment.Application.Commands.UpdateForecasts;

internal class UpdateForecastsCommandHandler(IUnitOfWork unitOfWork, IWeatherProvider weatherProvider) : IRequestHandler<UpdateForecastsCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IWeatherProvider _weatherProvider = weatherProvider;

    public Task Handle(UpdateForecastsCommand request, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}