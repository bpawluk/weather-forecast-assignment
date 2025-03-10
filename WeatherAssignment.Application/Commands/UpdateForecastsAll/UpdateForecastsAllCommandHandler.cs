using MediatR;
using WeatherAssignment.Core.Interface;

namespace WeatherAssignment.Application.Commands.UpdateForecastsAll;

internal class UpdateForecastsAllCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateForecastsAllCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public Task Handle(UpdateForecastsAllCommand request, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}