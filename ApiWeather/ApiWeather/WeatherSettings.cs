using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeather
{
    public class WeatherSettings
    {
        public string ApiKey { get; set; }

        public string BaseUrl { get; set; }

        public int NoDaysForecast { get; set; }
    }
}
