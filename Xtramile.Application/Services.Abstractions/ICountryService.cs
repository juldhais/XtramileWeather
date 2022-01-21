using System;
using System.Collections.Generic;
using Xtramile.Application.Resources;

namespace Xtramile.Application.Services.Abstractions
{
    public interface ICountryService
    {
        CountryResource Get(Guid id);
        List<CountryResource> GetAll();
        List<CityResource> GetCities(Guid countryId);

        CountryResource Create(CountryResource resource, Guid? createdById);
        CountryResource Update(CountryResource resource, Guid? updatedById);
        void Delete(Guid id, Guid? deletedById);
    }
}
