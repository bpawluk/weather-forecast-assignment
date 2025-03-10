﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherAssignment.Application.Commands.AddLocation;
using WeatherAssignment.Application.Commands.DeleteLocation;
using WeatherAssignment.Application.Queries.GetLocations;
using WeatherAssignment.Web.Controllers.Locations.Data;

namespace WeatherAssignment.Web.Controllers.Locations;

public class LocationsController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet]
    [ProducesResponseType(typeof(LocationDto[]), 200)]
    public async Task<ActionResult<LocationDto[]>> GetLocationsAsync()
    {
        var request = new GetLocationsQuery();
        var response = await _mediator.Send(request);
        var locations = response.Locations
            .Select(location => new LocationDto(
                location.Name, 
                location.Latitude, 
                location.Longitude))
            .ToArray();
        return Ok(locations);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> AddLocationAsync([FromBody] LocationDto newLocation)
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
    public async Task<IActionResult> DeleteLocationAsync([FromQuery] decimal latitude, [FromQuery] decimal longitude)
    {
        var request = new DeleteLocationCommand(latitude, longitude);
        await _mediator.Send(request);
        return NoContent();
    }
}