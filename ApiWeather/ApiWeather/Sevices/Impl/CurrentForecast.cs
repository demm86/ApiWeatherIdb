using ApiWeather.weatherApiModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiWeather.Sevices.Impl
{
    public class CurrentForecast : ICurrentForecast
    {

        private readonly HttpClient _client;
        private readonly WeatherSettings _settings;

        public CurrentForecast(HttpClient client, WeatherSettings settings)
        {
            _client = client;
            _settings = settings;
            _client.BaseAddress = new Uri(_settings.BaseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ForecastJsonResponse> GetCurrentForecast(string location)
        {
            var url = $"forecast.json?key={_settings.ApiKey}&q={location}&days={_settings.NoDaysForecast}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var contentTmp = JsonConvert.DeserializeObject<JToken>(content);

            return contentTmp.ToObject<ForecastJsonResponse>();

        }

    }
}
