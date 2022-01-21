using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xtramile.Application.Resources;
using Xtramile.Application.Services.Abstractions;

namespace XtramileWeather.WebApi.Controllers
{
    [ApiController]
    [Route("weatheer")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpGet]
        public ActionResult<WeatherResource> Get(string city)
        {
            var result = weatherService.Get(city);
            return Ok(result);
        }
    }
}
