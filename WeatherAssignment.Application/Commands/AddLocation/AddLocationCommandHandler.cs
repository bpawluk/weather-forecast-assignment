using MediatR;

namespace WeatherAssignment.Application.Commands.AddLocation;

internal class AddLocationCommandHandler : IRequestHandler<AddLocationCommand>
{
    public Task Handle(AddLocationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}