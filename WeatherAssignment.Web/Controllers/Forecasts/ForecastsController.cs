using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherAssignment.Application.Queries.GetForecast;
using WeatherAssignment.Web.Controllers.Forecasts.Data;

namespace WeatherAssignment.Web.Controllers.Forecasts;

[ApiController]
[Route("[controller]")]
public class ForecastsController(IMediator mediator) : AppController(mediator)
{
    [HttpGet]
    [ProducesResponseType(typeof(ForecastDto), 200)]
    public async Task<ActionResult<ForecastDto>> GetForecastAsync([FromQuery] decimal latitude, [FromQuery] decimal longitude)
    {
        var request = new GetForecastQuery(latitude, longitude);
        var response = await _mediator.Send(request);
        var forecast = new ForecastDto(
            response.Forecast.Updated,
            response.Forecast.Values
                .Select(value => new ForecastDto.Value(
                    value.Time,
                    value.Temperature,
                    value.Precipitation,
                    value.Pressure))
                .ToArray());
        return Ok(forecast);
    }
}