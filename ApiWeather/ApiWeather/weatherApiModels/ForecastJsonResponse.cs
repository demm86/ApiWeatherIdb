using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiWeather.weatherApiModels
{
    public class ForecastJsonResponse
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
        [JsonProperty("current")]
        public Current Current { get; set; }
        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }
    }
}
