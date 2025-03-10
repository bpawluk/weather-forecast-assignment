using System.Net;
using WeatherAssignment.Core.Exceptions;

namespace WeatherAssignment.Web.Middleware;

internal class CustomExceptionHandlingMiddleware(RequestDelegate next, IProblemDetailsService problemDetailsService)
{
    private readonly RequestDelegate _next = next;
    private readonly IProblemDetailsService _problemDetailsService = problemDetailsService;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode status;
        string title;

        switch (exception)
        {
            case EntityAlreadyExistsException:
                status = HttpStatusCode.Conflict;
                title = "Entity already exists.";
                break;
            case EntityNotFoundException:
                status = HttpStatusCode.NotFound;
                title = "Entity not found.";
                break;
            case ValidationException:
                status = HttpStatusCode.BadRequest;
                title = "Validation failed.";
                break;
            default:
                status = HttpStatusCode.InternalServerError;
                title = "An unexpected error occurred.";
                break;
        }

        context.Response.StatusCode = (int)status;
        await _problemDetailsService.WriteAsync(new ProblemDetailsContext
        {
            HttpContext = context,
            ProblemDetails =
            {
                Status = (int)status,
                Title = title,
                Detail = exception.Message,
            }
        });
    }
}