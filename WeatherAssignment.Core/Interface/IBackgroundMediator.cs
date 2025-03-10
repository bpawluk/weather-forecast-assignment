using MediatR;

namespace WeatherAssignment.Core.Interface;

public interface IBackgroundMediator
{
    void Enqueue<TRequest>(TRequest request) where TRequest : IRequest;

    void Schedule<TRequest>(TRequest request, string jobId, string jobCron) where TRequest : IRequest;
}