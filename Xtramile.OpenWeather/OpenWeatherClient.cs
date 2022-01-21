using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
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

        public async Weather Get(string city)
        {
            var httpResponse = await this.httpClient.GetAsync(GetRequestUrl(city));

            if (httpResponse == null || !httpResponse.IsSuccessStatusCode) return null;

            var jsonString = await httpResponse.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(jsonString);

            var response = new OpenWeatherResponse();
            response.Id = int.Parse(jsonObject.SelectToken("id").ToString());
            response.DateTime = DateTime.UnixEpoch.AddSeconds(double.Parse(jsonObject.SelectToken("dt").ToString()));
            response.Name = jsonObject.SelectToken("name").ToString();

            var coordToken = jsonObject.SelectToken("coord");
            response.Coordinates.Longitude = double.Parse(coordToken.SelectToken("lon").ToString());
            response.Coordinates.Latitude = double.Parse(coordToken.SelectToken("lat").ToString());

            var sysToken = jsonObject.SelectToken("sys");
            response.Sys.Country = sysToken.SelectToken("country").ToString();
            response.Sys.Sunrise = DateTime.UnixEpoch.AddSeconds(double.Parse(sysToken.SelectToken("sunrise").ToString()));
            response.Sys.Sunset = DateTime.UnixEpoch.AddSeconds(double.Parse(sysToken.SelectToken("sunset").ToString()));

            var mainToken = jsonObject.SelectToken("main");
            response.Main.Temperature = double.Parse(mainToken.SelectToken("temp").ToString());
            response.Main.TemperatureMin = double.Parse(mainToken.SelectToken("temp_min").ToString());
            response.Main.TemperatureMax = double.Parse(mainToken.SelectToken("temp_max").ToString());
            response.Main.Humidity = double.Parse(mainToken.SelectToken("humidity").ToString());
            response.Main.Pressure = double.Parse(mainToken.SelectToken("pressure").ToString());
            response.Main.SeaLevel = double.Parse(mainToken.SelectToken("sea_level").ToString());
            response.Main.GroundLevel = double.Parse(mainToken.SelectToken("ground_level").ToString());

            var windToken = jsonObject.SelectToken("wind");
            response.Wind.Speed = double.Parse(windToken.SelectToken("speed").ToString());
            response.Wind.Degree = double.Parse(windToken.SelectToken("degree").ToString());
            response.Wind.Gust = double.Parse(windToken.SelectToken("gust").ToString());

            var cloudsToken = jsonObject.SelectToken("clouds");
            response.Clouds.All = double.Parse(cloudsToken.SelectToken("all").ToString());

            var weatherToken = jsonObject.SelectToken("weather");
            response.Weather.Id = int.Parse(weatherToken.SelectToken("id").ToString());
            response.Weather.Main = weatherToken.SelectToken("main").ToString();
            response.Weather.Description = weatherToken.SelectToken("description").ToString();
            response.Weather.Icon = weatherToken.SelectToken("icon").ToString();

            var rainToken = jsonObject.SelectToken("rain");
            response.Rain.OneHour = double.Parse(rainToken.SelectToken("1h").ToString());
            response.Rain.ThreeHour = double.Parse(rainToken.SelectToken("3h").ToString());

            var snowToken = jsonObject.SelectToken("snow");
            response.Rain.OneHour = double.Parse(snowToken.SelectToken("1h").ToString());
            response.Rain.ThreeHour = double.Parse(snowToken.SelectToken("3h").ToString());
        }
    }
}
