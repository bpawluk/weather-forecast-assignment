using Hangfire;
using MediatR;
using WeatherAssignment.Core.Interface;

namespace WeatherAssignment.Infrastructure.Scheduling;

internal class BackgroundMediator(
    IBackgroundJobClient backgroundJobClient, 
    IRecurringJobManager recurringJobManager) 
    : IBackgroundMediator
{
    private readonly IBackgroundJobClient _backgroundJobClient = backgroundJobClient;
    private readonly IRecurringJobManager _recurringJobManager = recurringJobManager;

    public void Enqueue<TRequest>(TRequest request) where TRequest : IRequest
    {
        var jobName = request.GetType().Name;
        _backgroundJobClient.Enqueue<MediatorHangfireBridge>(bridge => bridge.Send(jobName, request));
    }

    public void Schedule<TRequest>(TRequest request, string jobId, string jobCron) where TRequest : IRequest
    {
        var jobName = request.GetType().Name;
        _recurringJobManager.AddOrUpdate<MediatorHangfireBridge>(
            jobId,
            bridge => bridge.Send(jobName, request),
            jobCron);
    }
}