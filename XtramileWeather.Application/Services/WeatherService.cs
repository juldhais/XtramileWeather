﻿using System.Threading.Tasks;
using XtramileWeather.Application.Extensions;
using XtramileWeather.Application.Resources;
using XtramileWeather.Application.Services.Abstractions;
using XtramileWeather.Domain.Exceptions;
using XtramileWeather.Domain.Repositories;

namespace XtramileWeather.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            this.weatherRepository = weatherRepository;
        }

        public async Task<WeatherResource> Get(string city)
        {
            if (string.IsNullOrEmpty(city))
                throw new BadRequestException("City cannot be empty.");

            var entity = await weatherRepository.Get(city);

            if (entity == null)
                throw new NotFoundException("City not found.");

            var resource = new WeatherResource();

            // map Entity to Resource
            resource.MapFrom(entity);

            resource.TemperatureCelcius = ConvertFahrenheitToCelcius(resource.TemperatureFahrenheit);

            return resource;
        }

        private double ConvertFahrenheitToCelcius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}