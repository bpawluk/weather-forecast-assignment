using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace WeatherAssignment.Infrastructure.Scheduling;

internal class MediatorHangfireBridge(IMediator mediator)
{
    private readonly IMediator _mediator = mediator;

    [DisplayName("{0}")]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Used by an Attribute")]
    public async Task Send(string jobName, IRequest command)
    {
        await _mediator.Send(command);
    }
}