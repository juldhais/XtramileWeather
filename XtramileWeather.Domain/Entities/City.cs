using XtramileWeather.Domain.Entities.Abstractions;

namespace XtramileWeather.Domain.Entities
{
    public class City : BaseEntity
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
