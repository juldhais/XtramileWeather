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
    public class CityService : ICityService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICityRepository cityRepository;

        public CityService(
            IUnitOfWork unitOfWork,
            ICityRepository cityRepository)
        {
            this.unitOfWork = unitOfWork;
            this.cityRepository = cityRepository;
        }

        public CityResource Get(Guid id)
        {
            var entity = cityRepository.Get(id);

            var resource = new CityResource();

            // map Entity to Resource using extensions method
            resource.MapFrom(entity);

            return resource;
        }

        public List<CityResource> GetAll()
        {
            var countries = cityRepository.GetAll();

            // Entity to Resource projection using Linq, can be done by AutoMapper/QueryableExtensions also
            var resources = countries
                .OrderBy(x => x.Name)
                .Select(x => new CityResource
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return resources;
        }

        public CityResource Create(CityResource resource, Guid? createdById)
        {
            var entity = new City();

            // map Resource to Entity
            entity.MapFrom(resource);

            cityRepository.Create(entity, createdById);

            unitOfWork.SaveChanges();

            return Get(entity.Id);
        }

        public CityResource Update(CityResource resource, Guid? updatedById)
        {
            var entity = cityRepository.Get(resource.Id);

            // map Resource to Entity
            entity.MapFrom(resource);

            cityRepository.Update(entity, updatedById);

            unitOfWork.SaveChanges();

            return Get(entity.Id);
        }

        public void Delete(Guid id, Guid? deletedById)
        {
            cityRepository.Delete(id, deletedById);

            unitOfWork.SaveChanges();
        }
    }
}
