using ApiWeather.weatherApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeather.Sevices
{
    public interface ICurrentForecast
    {
        Task<ForecastJsonResponse> GetCurrentForecast(string location);
    }
}
