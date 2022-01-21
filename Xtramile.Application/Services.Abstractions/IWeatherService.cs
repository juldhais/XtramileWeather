using Xtramile.Application.Resources;

namespace Xtramile.Application.Services.Abstractions
{
    public interface IWeatherService
    {
        WeatherResource Get(string city);
    }
}
