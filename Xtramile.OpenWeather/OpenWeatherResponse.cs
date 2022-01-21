using System;

namespace Xtramile.OpenWeather
{
    internal class OpenWeatherResponse
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public Coordinates Coordinates { get; set; }
        public Sys Sys { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public Weather Weather { get; set; }
        public Rain Rain { get; set; }
        public Snow Snow { get; set; }

        public OpenWeatherResponse()
        {
            Coordinates = new Coordinates();
            Sys = new Sys();
            Main = new Main();
            Wind = new Wind();
            Clouds = new Clouds();
            Weather = new Weather();
            Rain = new Rain();
            Snow = new Snow();
        }
    }

    internal class Coordinates
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    internal class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    internal class Main
    {
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public double SeaLevel { get; set; }
        public double GroundLevel { get; set; }
    }

    internal class Wind
    {
        public double Speed { get; set; }
        public double Degree { get; set; }
        public double Gust { get; set; }
    }

    internal class Clouds
    {
        public double All { get; set; }
    }

    internal class Sys
    {
        public int Type { get; set; }

        public int ID { get; set; }

        public double Message { get; set; }

        public string Country { get; set; }

        public DateTime Sunrise { get; set; }

        public DateTime Sunset { get; set; }
    }

    internal class Rain
    {
        public double OneHour { get; set; }
        public double ThreeHour { get; set; }
    }

    internal class Snow
    {
        public double OneHour { get; set; }
        public double ThreeHour { get; set; }
    }
}
