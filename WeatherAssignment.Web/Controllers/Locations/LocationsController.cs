using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherAssignment.Application.Commands.AddLocation;
using WeatherAssignment.Application.Commands.DeleteLocation;
using WeatherAssignment.Application.Queries.GetLocations;
using WeatherAssignment.Web.Controllers.Locations.Model;

namespace WeatherAssignment.Web.Controllers.Locations;

[ApiController]
[Route("[controller]")]
public class LocationsController(IMediator mediator) : AppController(mediator)
{
    [HttpGet]
    [ProducesResponseType(typeof(Location[]), 200)]
    public async Task<ActionResult<Location[]>> GetLocationsAsync()
    {
        var request = new GetLocationsQuery();
        var response = await _mediator.Send(request);
        var locations = response.Locations
            .Select(location => new Location(
                location.Name, 
                location.Latitude, 
                location.Longitude))
            .ToArray();
        return Ok(locations);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> AddLocationAsync([FromBody] Location newLocation)
    {
        var request = new AddLocationCommand(
            newLocation.Name,
            newLocation.Latitude,
            newLocation.Longitude);
        await _mediator.Send(request);
        return Created();
    }

    [HttpDelete]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteLocationAsync([FromQuery] decimal latitude, [FromQuery] decimal longitude)
    {
        var request = new DeleteLocationCommand(latitude, longitude);
        await _mediator.Send(request);
        return NoContent();
    }
}