using MediatR;
using WeatherAssignment.Core;
using WeatherAssignment.Core.Interface;

namespace WeatherAssignment.Application.Commands.AddLocation;

internal class AddLocationCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddLocationCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(AddLocationCommand request, CancellationToken cancellationToken)
    {
        var locations = _unitOfWork.Set<Location>();
        var locationToAdd = new Location(
            request.Name,
            request.Latitude,
            request.Longitude);
        locations.Add(locationToAdd);

        var forecasts = _unitOfWork.Set<Forecast>();
        var forecastToAdd = Forecast.Empty(locationToAdd);
        forecasts.Add(forecastToAdd);

        await _unitOfWork.SaveChanges(cancellationToken);
    }
}