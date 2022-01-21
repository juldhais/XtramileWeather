using System;
using XtramileWeather.Domain.Entities.Abstractions;

namespace XtramileWeather.Domain.Entities
{
    public class City : BaseEntity
    {
        public Country Country { get; set; }
        public Guid? CountryId { get; set; }
        public string Name { get; set; }
    }
}
