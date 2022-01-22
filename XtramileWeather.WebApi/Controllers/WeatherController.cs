using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XtramileWeather.Application.Resources;
using XtramileWeather.Application.Services.Abstractions;

namespace XtramileWeather.WebApi.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpGet]
        public async Task<ActionResult<WeatherResource>> Get(string city)
        {
            var result = await weatherService.Get(city);
            return Ok(result);
        }
    }
}
