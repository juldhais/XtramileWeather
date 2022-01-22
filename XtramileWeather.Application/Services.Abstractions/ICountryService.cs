using System;
using System.Collections.Generic;
using XtramileWeather.Application.Resources;

namespace XtramileWeather.Application.Services.Abstractions
{
    public interface ICountryService
    {
        CountryResource Get(int id);
        List<CountryResource> GetAll();
        List<CityResource> GetCities(int countryId);
    }
}
