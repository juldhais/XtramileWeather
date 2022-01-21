using System;
using System.Collections.Generic;
using Xtramile.Application.Resources;

namespace Xtramile.Application.Services.Abstractions
{
    public interface IUserService
    {
        UserResource Get(Guid id);
        List<UserResource> GetAll();

        UserResource Create(EditUserResource resource, Guid? createdById);
        UserResource Update(EditUserResource resource, Guid? updatedById);
        void Delete(Guid id, Guid? deletedById);

        UserResource Login(string username, string password);
    }
}
