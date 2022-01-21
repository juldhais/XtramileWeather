using XtramileWeather.Domain.Entities.Abstractions;

namespace XtramileWeather.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
