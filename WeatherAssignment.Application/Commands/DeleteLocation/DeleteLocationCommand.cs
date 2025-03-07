using MediatR;

namespace WeatherAssignment.Application.Commands.DeleteLocation;

public record DeleteLocationCommand(
    decimal Latitude,
    decimal Longitude)
    : IRequest;