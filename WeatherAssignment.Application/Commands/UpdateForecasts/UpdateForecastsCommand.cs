using MediatR;

namespace WeatherAssignment.Application.Commands.UpdateForecasts;

public record UpdateForecastsCommand(IReadOnlySet<UpdateForecastsCommand.Coordinates> LocationsCoordinates) : IRequest
{
    public record Coordinates(decimal Latitude, decimal Longitude);
}