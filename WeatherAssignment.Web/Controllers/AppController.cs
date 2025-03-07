using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAssignment.Web.Controllers;

public class AppController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator _mediator = mediator;
}