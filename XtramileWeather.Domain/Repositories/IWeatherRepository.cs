using XtramileWeather.Domain.Entities;

namespace XtramileWeather.Domain.Repositories
{
    public interface IWeatherRepository
    {
        Weather Get(string city);
    }
}
