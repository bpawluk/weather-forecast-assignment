using MediatR;

namespace WeatherAssignment.Application.Commands.DeleteLocation;

internal class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
{
    public Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}