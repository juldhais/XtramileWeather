using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using XtramileWeather.Domain.Entities;
using XtramileWeather.Domain.Repositories;

namespace Xtramile.OpenWeather
{
    public class OpenWeatherClient : IWeatherRepository
    {
        // api.openweathermap.org/data/2.5/weather?q=Karawang&appid=5441d3fdf371995af5f6b7b987520faf
        private HttpClient httpClient;
        private string baseUrl = "api.openweathermap.org";
        private string apiKey = "5441d3fdf371995af5f6b7b987520faf";

        public OpenWeatherClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private string GetRequestUrl(string query)
        {
            return $"{baseUrl}/data/2.5/weather?appid={apiKey}&q={query}";
        }

        public async Task<Weather> Get(string city)
        {
            var httpResponse = await this.httpClient.GetAsync(GetRequestUrl(city));
            if (httpResponse == null || !httpResponse.IsSuccessStatusCode) return null;

            var jsonString = await httpResponse.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(jsonString);

            var response = new OpenWeatherResponse();
            response.Cod = jsonObject.SelectToken("cod").ToInteger();
            response.Id = jsonObject.SelectToken("id").ToInteger();
            response.DateTime = jsonObject.SelectToken("dt").ToDateTime();
            response.Name = jsonObject.SelectToken("name").ToString();
            response.Visibility = jsonObject.SelectToken("visibility").ToDouble();

            var coordToken = jsonObject.SelectToken("coord");
            response.Coordinates.Longitude = coordToken.SelectToken("lon").ToDouble();
            response.Coordinates.Latitude = coordToken.SelectToken("lat").ToDouble();

            var sysToken = jsonObject.SelectToken("sys");
            response.Sys.Country = sysToken.SelectToken("country").ToString();
            response.Sys.Sunrise = sysToken.SelectToken("sunrise").ToDateTime();
            response.Sys.Sunset = sysToken.SelectToken("sunset").ToDateTime();

            var mainToken = jsonObject.SelectToken("main");
            response.Main.Temperature = mainToken.SelectToken("temp").ToDouble();
            response.Main.TemperatureMin = mainToken.SelectToken("temp_min").ToDouble();
            response.Main.TemperatureMax = mainToken.SelectToken("temp_max").ToDouble();
            response.Main.Humidity = mainToken.SelectToken("humidity").ToDouble();
            response.Main.Pressure = mainToken.SelectToken("pressure").ToDouble();
            response.Main.SeaLevel = mainToken.SelectToken("sea_level").ToDouble();
            response.Main.GroundLevel = mainToken.SelectToken("ground_level").ToDouble();

            var windToken = jsonObject.SelectToken("wind");
            response.Wind.Speed = windToken.SelectToken("speed").ToDouble();
            response.Wind.Degree = windToken.SelectToken("degree").ToDouble();
            response.Wind.Gust = windToken.SelectToken("gust").ToDouble();

            var cloudsToken = jsonObject.SelectToken("clouds");
            response.Clouds.All = cloudsToken.SelectToken("all").ToDouble();

            var weatherToken = jsonObject.SelectToken("weather");
            response.Weather.Id = weatherToken.SelectToken("id").ToInteger();
            response.Weather.Main = weatherToken.SelectToken("main").ToString();
            response.Weather.Description = weatherToken.SelectToken("description").ToString();
            response.Weather.Icon = weatherToken.SelectToken("icon").ToString();

            var rainToken = jsonObject.SelectToken("rain");
            response.Rain.OneHour = rainToken.SelectToken("1h").ToDouble();
            response.Rain.ThreeHour = rainToken.SelectToken("3h").ToDouble();

            var snowToken = jsonObject.SelectToken("snow");
            response.Rain.OneHour = snowToken.SelectToken("1h").ToDouble();
            response.Rain.ThreeHour = snowToken.SelectToken("3h").ToDouble();

            var result = new Weather();
            result.Location = response.Name;
            result.Time = response.DateTime;
            result.Wind = response.Wind.Speed;
            result.Visibility = response.Visibility;
            result.SkyConditions = response.Weather.Description;
            result.TemperatureFahrenheit = response.Main.Temperature;
            result.DewPoint = response.Clouds.All;
            result.Humidity = response.Main.Humidity;
            result.Pressure = response.Main.Pressure;

            return result;
        }
    }
}
