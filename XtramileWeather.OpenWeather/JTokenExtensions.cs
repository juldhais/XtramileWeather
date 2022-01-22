using Newtonsoft.Json.Linq;
using System;

namespace XtramileWeather.OpenWeather
{
    public static class JTokenExtensions
    {
        public static double ToDouble(this JToken token)
        {
            if (token == null) return 0;

            return Convert.ToDouble(token.ToString());
        }

        public static int ToInteger(this JToken token)
        {
            if (token == null) return 0;

            return Convert.ToInt32(token.ToString());
        }

        public static DateTime ToDateTime(this JToken token)
        {
            if (token == null) return default;

            return DateTime.UnixEpoch.AddSeconds(token.ToDouble());
        }
    }
}
