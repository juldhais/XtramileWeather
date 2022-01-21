using System.Threading.Tasks;
using XtramileWeather.Domain.Entities;

namespace XtramileWeather.Domain.Repositories
{
    public interface IWeatherRepository
    {
        Task<Weather> Get(string city);
    }
}
