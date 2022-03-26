using ApiWeather.weatherApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiWeather.Sevices.Impl
{
    public class SearchLocation : ISearchLocation
    {

        private readonly HttpClient _client;
        private readonly WeatherSettings _settings;

        public SearchLocation(HttpClient client, WeatherSettings settings)
        {
            _client = client;
            _settings = settings;
            _client.BaseAddress = new Uri(_settings.BaseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<SearchJsonResponse>> GetLocation(string location)
        {
            var url = $"search.json?key={_settings.ApiKey}&q={location}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<SearchJsonResponse>>(content);

        }
    }
}
