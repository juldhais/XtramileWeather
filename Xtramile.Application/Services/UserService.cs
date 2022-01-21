using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Xtramile.Application.Extensions;
using Xtramile.Application.Resources;
using Xtramile.Application.Services.Abstractions;
using XtramileWeather.Domain.Entities;
using XtramileWeather.Domain.Exceptions;
using XtramileWeather.Domain.Repositories;

namespace Xtramile.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;

        public UserService(
            IUnitOfWork unitOfWork,
            IUserRepository UserRepository)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = UserRepository;
        }

        public UserResource Get(Guid id)
        {
            var entity = userRepository.Get(id);

            var resource = new UserResource();

            // map Entity to Resource using extensions method
            resource.MapFrom(entity);

            return resource;
        }

        public List<UserResource> GetAll()
        {
            var countries = userRepository.GetAll();

            // Entity to Resource projection using Linq, can be done by AutoMapper/QueryableExtensions also
            var resources = countries
                .OrderBy(x => x.Username)
                .Select(x => new UserResource
                {
                    Id = x.Id,
                    Username = x.Username
                }).ToList();

            return resources;
        }

        private string HashString(string text)
        {
            using (var alg = SHA256.Create())
                return string.Join(null, alg.ComputeHash(Encoding.UTF8.GetBytes(text)).Select(x => x.ToString("x2")));
        }

        public UserResource Create(EditUserResource resource, Guid? createdById)
        {
            var entity = new User();

            entity.Username = resource.Username;
            entity.Password = HashString(resource.Password);

            userRepository.Create(entity, createdById);

            unitOfWork.SaveChanges();

            return Get(entity.Id);
        }

        public UserResource Update(EditUserResource resource, Guid? updatedById)
        {
            var entity = userRepository.Get(resource.Id);

            entity.Username = resource.Username;
            entity.Password = HashString(resource.Password);

            userRepository.Update(entity, updatedById);

            unitOfWork.SaveChanges();

            return Get(entity.Id);
        }

        public void Delete(Guid id, Guid? deletedById)
        {
            userRepository.Delete(id, deletedById);

            unitOfWork.SaveChanges();
        }

        public UserResource Login(string username, string password)
        {
            var user = userRepository.GetByUsername(username);
            if (user == null)
                throw new BadRequestException("User not found.");

            if (user.Password != HashString(password))
                throw new BadRequestException("Password did not match.");

            var resource = new UserResource();
            resource.MapFrom(user);

            return resource;
        }
    }
}
