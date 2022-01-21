using System;
using System.Collections.Generic;
using System.Linq;
using Xtramile.Persistence.Context;
using XtramileWeather.Domain.Entities;
using XtramileWeather.Domain.Repositories;

namespace Xtramile.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext db;

        public UserRepository(DataContext db)
        {
            this.db = db;
        }

        public User Get(Guid id)
        {
            return db.User.Find(id);
        }

        public List<User> GetAll()
        {
            return db.User.ToList();
        }

        public User GetByUsername(string username)
        {
            return db.User
                .Where(x => x.Username == username)
                .FirstOrDefault();
        }

        public void Create(User entity, Guid? createdById)
        {
            entity.Id = Guid.NewGuid();
            entity.DateCreated = DateTime.Now;
            entity.CreatedById = createdById;
            db.User.Add(entity);
        }

        public void Update(User entity, Guid? updatedById)
        {
            entity.DateUpdated = DateTime.Now;
            entity.UpdatedById = updatedById;
        }
        public void Delete(Guid id, Guid? deletedById)
        {
            var entity = db.User.Find(id);
            db.User.Remove(entity);
        }
    }
}
