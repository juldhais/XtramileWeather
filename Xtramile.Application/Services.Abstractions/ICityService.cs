using System;
using System.Collections.Generic;
using Xtramile.Application.Resources;

namespace Xtramile.Application.Services.Abstractions
{
    public interface ICityService
    {
        CityResource Get(Guid id);
        List<CityResource> GetAll();

        CityResource Create(CityResource resource, Guid? createdById);
        CityResource Update(CityResource resource, Guid? updatedById);
        void Delete(Guid id, Guid? deletedById);
    }
}
