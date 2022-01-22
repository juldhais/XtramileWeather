using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using XtramileWeather.Application.Resources;
using XtramileWeather.Application.Services.Abstractions;
using XtramileWeather.Domain.Exceptions;
using XtramileWeather.WebApi.Controllers;
using Xunit;

namespace XtramileWeather.Test
{
    public class ControllerTest
    {
        [Fact]
        public void GetAllCountryTest()
        {
            var countryService = new Mock<ICountryService>();

            countryService.Setup(x => x.GetAll())
                .Returns(new List<CountryResource>
                {
                    new CountryResource { Id = 1, Name = "Indonesia" },
                    new CountryResource { Id = 2, Name = "Australia" },
                });

            var countryController = new CountryController(countryService.Object);
            var actionResult = countryController.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var value = Assert.IsType<List<CountryResource>>(okResult.Value);

            Assert.NotNull(value);
            Assert.Equal(2, value.Count);
            Assert.Contains(value, x => x.Name == "Indonesia");
            Assert.Contains(value, x => x.Name == "Australia");
        }

        [Fact]
        public async void CityEmptyTest()
        {
            var weatherService = new Mock<IWeatherService>();

            weatherService.Setup(x => x.Get(""))
                .ThrowsAsync(new BadRequestException("City cannot be empty."));

            var weatherController = new WeatherController(weatherService.Object);
            var exception = await Assert.ThrowsAsync<BadRequestException>(async () => await weatherController.Get(""));
            Assert.Equal("City cannot be empty.", exception.Message);
        }
    }
}
