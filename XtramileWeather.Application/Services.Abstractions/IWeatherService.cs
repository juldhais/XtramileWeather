using System.Threading.Tasks;
using XtramileWeather.Application.Resources;

namespace XtramileWeather.Application.Services.Abstractions
{
    public interface IWeatherService
    {
        Task<WeatherResource> Get(string city);
    }
}
