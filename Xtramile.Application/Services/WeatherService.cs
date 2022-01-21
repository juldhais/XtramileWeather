using System;
using System.Collections.Generic;
using System.Text;
using Xtramile.Application.Extensions;
using Xtramile.Application.Resources;
using Xtramile.Application.Services.Abstractions;
using XtramileWeather.Domain.Repositories;

namespace Xtramile.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            this.weatherRepository = weatherRepository;
        }

        // 5441d3fdf371995af5f6b7b987520faf

        public WeatherResource Get(string city)
        {
            var entity = weatherRepository.Get(city);

            var resource = new WeatherResource();

            // map Entity to Resource
            resource.MapFrom(entity);

            return resource;
        }
    }
}
