using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAssignment.Web.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class ApiController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator _mediator = mediator;
}