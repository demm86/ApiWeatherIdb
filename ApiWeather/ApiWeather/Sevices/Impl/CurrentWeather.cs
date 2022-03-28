using ApiWeather.weatherApiModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiWeather.Sevices.Impl
{
    public class CurrentWeather : ICurrentWeather
    {

        private readonly HttpClient _client;
        private readonly WeatherSettings _settings;

        public CurrentWeather(HttpClient client, WeatherSettings settings)
        {
            _client = client;
            _settings = settings;
            _client.BaseAddress = new Uri(_settings.BaseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<CurrentJsonResponse> GetCurrentWeather(string location)
        {
            var url = $"current.json?key={_settings.ApiKey}&q={location}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var contentTmp = JsonConvert.DeserializeObject<JToken>(content);

            return contentTmp.ToObject<CurrentJsonResponse>();

        }

    }
}
