using System.Collections.Generic;
using System.Linq;
using XtramileWeather.Domain.Entities;
using XtramileWeather.Domain.Repositories;

namespace XtramileWeather.Persistence
{
    public class CountryRepository : ICountryRepository
    {
        static List<Country> CountryDataSource = new List<Country>
        {
            new Country { Id = 1, Name = "Indonesia" },
            new Country { Id = 2, Name = "Australia" },
            new Country { Id = 3, Name = "Japan" },
        };

        static List<City> CityDataSource = new List<City>
        {
            new City { Id = 1, CountryId = 1, Name = "Jakarta" },
            new City { Id = 2, CountryId = 1, Name = "Bogor" },
            new City { Id = 3, CountryId = 1, Name = "Semarang" },
            new City { Id = 4, CountryId = 1, Name = "Yogyakarta" },
            new City { Id = 5, CountryId = 1, Name = "Surabaya" },

            new City { Id = 6, CountryId = 2, Name = "Sydney" },
            new City { Id = 7, CountryId = 2, Name = "Melbourne" },
            new City { Id = 8, CountryId = 2, Name = "Brisbane" },
            new City { Id = 9, CountryId = 2, Name = "Perth" },
            new City { Id = 10, CountryId = 2, Name = "Canberra" },

            new City { Id = 11, CountryId = 3, Name = "Tokyo" },
            new City { Id = 12, CountryId = 3, Name = "Osaka" },
            new City { Id = 13, CountryId = 3, Name = "Nagoya" },
            new City { Id = 14, CountryId = 3, Name = "Kyoto" },
            new City { Id = 15, CountryId = 3, Name = "Kobe" },
        };

        public Country Get(int id)
        {
            return CountryDataSource.FirstOrDefault(x => x.Id == id);
        }

        public List<Country> GetAll()
        {
            return CountryDataSource;
        }

        public List<City> GetCities(int countryId)
        {
            return CityDataSource.Where(x => x.CountryId == countryId).ToList();
        }
    }
}
