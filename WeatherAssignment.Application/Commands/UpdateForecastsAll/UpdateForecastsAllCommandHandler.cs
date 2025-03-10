using MediatR;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using WeatherAssignment.Application.Commands.UpdateForecasts;
using WeatherAssignment.Core;
using WeatherAssignment.Core.Interface;

namespace WeatherAssignment.Application.Commands.UpdateForecastsAll;

internal class UpdateForecastsAllCommandHandler(IUnitOfWork unitOfWork, IBackgroundMediator mediator) : IRequestHandler<UpdateForecastsAllCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IBackgroundMediator _mediator = mediator;

    public async Task Handle(UpdateForecastsAllCommand request, CancellationToken cancellationToken)
    {
        var locations = _unitOfWork.Set<Location>();

        var coordinates = await locations
            .Select(location => new UpdateForecastsCommand.Coordinates(
                location.Coordinates.Latitude, 
                location.Coordinates.Longitude))
            .ToListAsync(cancellationToken);

        foreach (var batch in coordinates.Batch(5))
        {
            _mediator.Enqueue(new UpdateForecastsCommand(batch.ToHashSet()));
        }
    }
}