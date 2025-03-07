using MediatR;

namespace WeatherAssignment.Application.Commands.AddLocation;

public record AddLocationCommand(
    string Name, 
    decimal Latitude, 
    decimal Longitude) 
    : IRequest;