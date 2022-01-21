using System;

namespace Xtramile.Application.Resources
{
    public class WeatherResource
    {
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public decimal Wind { get; set; }
        public decimal Visibility { get; set; }
        public string SkyConditions { get; set; }
        public decimal TemperatureFahrenheit { get; set; }
        public decimal TemperatureCelcius { get; set; }
        public decimal DewPoint { get; set; }
        public decimal Humidity { get; set; }
        public decimal Pressure { get; set; }
    }
}
