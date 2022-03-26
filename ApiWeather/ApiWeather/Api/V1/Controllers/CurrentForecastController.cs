using ApiWeather.Sevices;
using ApiWeather.weatherApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeather.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CurrentForecastController : ControllerBase
    {

        private readonly ICurrentForecast _currentForeCast;

        // Dependency Injection
        public CurrentForecastController(ICurrentForecast currentForeCast)
        {
            _currentForeCast = currentForeCast;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ForecastJsonResponse> Get(string location)
        {
            return await _currentForeCast.GetCurrentForecast(location);
        }
    }
}
