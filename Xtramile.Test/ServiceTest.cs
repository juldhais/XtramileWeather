using Moq;
using System;
using System.Collections.Generic;
using Xtramile.Application.Services;
using XtramileWeather.Domain.Entities;
using XtramileWeather.Domain.Repositories;
using Xunit;

namespace Xtramile.Test
{
    public class ServiceTest
    {
        [Fact]
        public void GetAllCountryTest()
        {
            var countryRepository = new Mock<ICountryRepository>();
            countryRepository.Setup(x => x.GetAll())
                .Returns(new List<Country>
                {
                    new Country { Id = 1, Name = "Indonesia" },
                    new Country { Id = 2, Name = "Australia" },
                    new Country { Id = 3, Name = "Japan" }
                });

            var countryService = new CountryService(countryRepository.Object);
            var result = countryService.GetAll();
            Assert.Equal(3, result.Count);

        }
    }
}
