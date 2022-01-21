using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xtramile.Application.Resources;
using Xtramile.Application.Services.Abstractions;

namespace XtramileWeather.WebApi.Controllers
{
    [ApiController]
    [Route("countries")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public ActionResult<List<CountryResource>> GetAll()
        {
            var result = countryService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<CountryResource> Get(Guid id)
        {
            var result = countryService.Get(id);
            return Ok(result);
        }

        [HttpGet("{id}/cities")]
        public ActionResult<List<CityResource>> GetCities(Guid id)
        {
            var result = countryService.GetCities(id);
            return Ok(result);
        }
    }
}
