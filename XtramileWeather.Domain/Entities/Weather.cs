using System;

namespace XtramileWeather.Domain.Entities
{
    public class Weather
    {
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public double Wind { get; set; }
        public double Visibility { get; set; }
        public string SkyConditions { get; set; }
        public double TemperatureFahrenheit { get; set; }
        public double DewPoint { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
    }
}
