using System;

namespace XtramileWeather.Domain.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("Unauthorized") { }
        public UnauthorizedException(string message) : base(message) { }
    }
}

