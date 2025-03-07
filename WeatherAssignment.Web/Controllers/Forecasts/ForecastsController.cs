using Microsoft.AspNetCore.Mvc;
using WeatherAssignment.Web.Controllers.Forecasts.Model;

namespace WeatherAssignment.Web.Controllers.Forecasts;

[ApiController]
[Route("[controller]")]
public class ForecastsController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Forecast), 200)]
    public ActionResult<Forecast> GetForecast([FromQuery] decimal latitude, [FromQuery] decimal longitude)
    {
        var forecast = new Forecast();
        return Ok(forecast);
    }
}