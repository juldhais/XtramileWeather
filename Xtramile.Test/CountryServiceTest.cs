using Moq;
using System;
using System.Collections.Generic;
using Xtramile.Application.Services;
using XtramileWeather.Domain.Entities;
using XtramileWeather.Domain.Repositories;
using Xunit;

namespace Xtramile.Test
{
    public class CountryServiceTest
    {
        [Fact]
        public void GetAllCountryTest()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.SaveChanges()).Returns(1);

            var countryRepository = new Mock<ICountryRepository>();
            countryRepository.Setup(x => x.GetAll())
                .Returns(new List<Country>
                {
                    new Country { Id = Guid.NewGuid(), Name = "Indonesia" },
                    new Country { Id = Guid.NewGuid(), Name = "Australia" },
                    new Country { Id = Guid.NewGuid(), Name = "Japan" }
                });

            var countryService = new CountryService(unitOfWork.Object, countryRepository.Object);
            var result = countryService.GetAll();
            Assert.Equal(3, result.Count);

        }
    }
}
