using System;
using System.Collections.Generic;
using System.Linq;
using Xtramile.Persistence.Context;
using XtramileWeather.Domain.Entities;
using XtramileWeather.Domain.Repositories;

namespace Xtramile.Persistence.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext db;

        public CityRepository(DataContext db)
        {
            this.db = db;
        }

        public City Get(Guid id)
        {
            return db.City.Find(id);
        }

        public List<City> GetAll()
        {
            return db.City.ToList();
        }

        public void Create(City entity, Guid? createdById)
        {
            entity.Id = Guid.NewGuid();
            entity.DateCreated = DateTime.Now;
            entity.CreatedById = createdById;
            db.City.Add(entity);
        }

        public void Update(City entity, Guid? updatedById)
        {
            entity.DateUpdated = DateTime.Now;
            entity.UpdatedById = updatedById;
        }

        public void Delete(Guid id, Guid? deletedById)
        {
            var entity = db.City.Find(id);
            db.City.Remove(entity);
        }
    }
}
