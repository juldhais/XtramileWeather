using Microsoft.Extensions.DependencyInjection;
using Xtramile.Application.Services;
using Xtramile.Application.Services.Abstractions;
using Xtramile.OpenWeather;
using Xtramile.Persistence.Repositories;
using XtramileWeather.Domain.Repositories;

namespace XtramileWeather.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWeatherRepository, OpenWeatherClient>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWeatherService, WeatherService>();
        }
    }
}
