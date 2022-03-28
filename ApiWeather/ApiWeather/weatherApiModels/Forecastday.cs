using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiWeather.weatherApiModels
{
    public class Forecastday
    {
        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("date_epoch")]
        public int? dateEpoch { get; set; }

        [JsonProperty("day")]
        public Day Day { get; set; }

        [JsonProperty("astro")]
        public Astro Astro { get; set; }
    }
}
