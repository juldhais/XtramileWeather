using System.Collections.Generic;
using System.Linq;
using XtramileWeather.Application.Extensions;
using XtramileWeather.Application.Resources;
using XtramileWeather.Application.Services.Abstractions;
using XtramileWeather.Domain.Repositories;

namespace XtramileWeather.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public CountryResource Get(int id)
        {
            var entity = countryRepository.Get(id);

            var resource = new CountryResource();

            // map Entity to Resource using extensions method
            resource.MapFrom(entity);

            return resource;
        }

        public List<CountryResource> GetAll()
        {
            var countries = countryRepository.GetAll();

            // Entity to Resource projection using Linq, can also be done by AutoMapper/QueryableExtensions
            var resources = countries
                .OrderBy(x => x.Name)
                .Select(x => new CountryResource
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return resources;
        }

        public List<CityResource> GetCities(int countryId)
        {
            var cities = countryRepository.GetCities(countryId);

            var resources = cities
                .OrderBy(x => x.Name)
                .Select(x => new CityResource
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return resources;
        }
    }
}
