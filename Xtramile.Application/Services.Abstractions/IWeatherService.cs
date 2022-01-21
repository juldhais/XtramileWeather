using System.Threading.Tasks;
using Xtramile.Application.Resources;

namespace Xtramile.Application.Services.Abstractions
{
    public interface IWeatherService
    {
        Task<WeatherResource> Get(string city);
    }
}
