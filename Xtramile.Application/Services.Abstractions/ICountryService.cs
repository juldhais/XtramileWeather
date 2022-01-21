using System;
using System.Collections.Generic;
using Xtramile.Application.Resources;

namespace Xtramile.Application.Services.Abstractions
{
    public interface ICountryService
    {
        CountryResource Get(int id);
        List<CountryResource> GetAll();
        List<CityResource> GetCities(int countryId);
    }
}
