using Microsoft.Extensions.DependencyInjection;
using Xtramile.OpenWeather;
using XtramileWeather.Application.Services;
using XtramileWeather.Application.Services.Abstractions;
using XtramileWeather.Domain.Repositories;
using XtramileWeather.Persistence;

namespace XtramileWeather.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddHttpClient<IWeatherRepository, OpenWeatherClient>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IWeatherService, WeatherService>();
        }
    }
}
