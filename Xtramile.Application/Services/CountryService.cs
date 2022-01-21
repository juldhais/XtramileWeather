using System;
using System.Collections.Generic;
using System.Linq;
using Xtramile.Application.Extensions;
using Xtramile.Application.Resources;
using Xtramile.Application.Services.Abstractions;
using XtramileWeather.Domain.Entities;
using XtramileWeather.Domain.Repositories;

namespace Xtramile.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICountryRepository countryRepository;

        public CountryService(
            IUnitOfWork unitOfWork,
            ICountryRepository countryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.countryRepository = countryRepository;
        }

        public CountryResource Get(Guid id)
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

            // Entity to Resource projection using Linq, can be done by AutoMapper/QueryableExtensions also
            var resources = countries
                .OrderBy(x => x.Name)
                .Select(x => new CountryResource
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return resources;
        }

        public List<CityResource> GetCities(Guid countryId)
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

        public CountryResource Create(CountryResource resource, Guid? createdById)
        {
            var entity = new Country();

            // map Resource to Entity
            entity.MapFrom(resource);

            countryRepository.Create(entity, createdById);

            unitOfWork.SaveChanges();

            return Get(entity.Id);
        }

        public CountryResource Update(CountryResource resource, Guid? updatedById)
        {
            var entity = countryRepository.Get(resource.Id);

            // map Resource to Entity
            entity.MapFrom(resource);

            countryRepository.Update(entity, updatedById);

            unitOfWork.SaveChanges();

            return Get(entity.Id);
        }

        public void Delete(Guid id, Guid? deletedById)
        {
            countryRepository.Delete(id, deletedById);

            unitOfWork.SaveChanges();
        }
    }
}
