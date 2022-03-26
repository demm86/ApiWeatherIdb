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
    public class CurrentController : ControllerBase
    {

        private readonly ICurrentWeather _currentWeather;
        public CurrentController(ICurrentWeather currentWeather)
        {
            _currentWeather = currentWeather;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<CurrentJsonResponse> Get(string location)
        {
            return await _currentWeather.GetCurrentWeather(location);
        }
    }
}
