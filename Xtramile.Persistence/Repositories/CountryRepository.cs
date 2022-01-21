using System;
using System.Collections.Generic;
using System.Linq;
using Xtramile.Persistence.Context;
using XtramileWeather.Domain.Entities;
using XtramileWeather.Domain.Repositories;

namespace Xtramile.Persistence.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext db;

        public CountryRepository(DataContext db)
        {
            this.db = db;
        }

        public Country Get(Guid id)
        {
            return db.Country.Find(id);
        }

        public List<Country> GetAll()
        {
            return db.Country.ToList();
        }

        public List<City> GetCities(Guid countryId)
        {
            return db.City
                .Where(x => x.CountryId == countryId)
                .ToList();
        }

        public void Create(Country entity, Guid? createdById)
        {
            entity.Id = Guid.NewGuid();
            entity.DateCreated = DateTime.Now;
            entity.CreatedById = createdById;
            db.Country.Add(entity);
        }

        public void Update(Country entity, Guid? updatedById)
        {
            entity.DateUpdated = DateTime.Now;
            entity.UpdatedById = updatedById;
        }

        public void Delete(Guid id, Guid? deletedById)
        {
            var entity = db.Country.Find(id);
            db.Country.Remove(entity);
        }
    }
}
