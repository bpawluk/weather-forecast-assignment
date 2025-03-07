using Microsoft.AspNetCore.Mvc;
using WeatherAssignment.Web.Controllers.Locations.Model;

namespace WeatherAssignment.Web.Controllers.Locations;

[ApiController]
[Route("[controller]")]
public class LocationsController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Location[]), 200)]
    public ActionResult<Location[]> GetLocations()
    {
        var locations = Array.Empty<Location>();
        return Ok(locations);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public IActionResult AddLocation([FromBody] Location newLocation)
    {
        return Created();
    }

    [HttpDelete]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteLocation([FromQuery] decimal latitude, [FromQuery] decimal longitude)
    {
        return NoContent();
    }
}