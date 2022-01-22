using Moq;
using System;
using System.Collections.Generic;
using XtramileWeather.Application.Services;
using XtramileWeather.Domain.Entities;
using XtramileWeather.Domain.Exceptions;
using XtramileWeather.Domain.Repositories;
using Xunit;

namespace XtramileWeather.Test
{
    public class ServiceTest
    {
        [Fact]
        public async void TemperatureConversionTest()
        {
            var weatherRepository = new Mock<IWeatherRepository>();

            weatherRepository.Setup(x => x.Get("Jakarta"))
               .ReturnsAsync(new Weather
               {
                   TemperatureKelvin = 298.15,
               });

            var service = new WeatherService(weatherRepository.Object);
            var weather = await service.Get("Jakarta");

            Assert.Equal(25, weather.TemperatureCelcius);
            Assert.Equal(77, weather.TemperatureFahrenheit);
        }


        [Fact]
        public async void CityNotFoundTest()
        {
            var weatherRepository = new Mock<IWeatherRepository>();

            weatherRepository.Setup(x => x.Get("Jakarta"))
               .ReturnsAsync(new Weather
               {
                   Location = "Jakarta",
               });

            var service = new WeatherService(weatherRepository.Object);
            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await service.Get("Metaverse"));
            Assert.Equal("City not found.", exception.Message);
        }
    }
}
