using System;
using System.Collections.Generic;
using XtramileWeather.Domain.Entities;

namespace XtramileWeather.Domain.Repositories
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        List<City> GetCities(Guid countryId);
    }
}
