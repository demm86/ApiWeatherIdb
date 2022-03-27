using ApiWeather.Sevices;
using ApiWeather.weatherApiModels;
using Microsoft.AspNetCore.Cors;
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
    public class SearchLocationController : ControllerBase
    {

        private readonly ISearchLocation _searchLocation;

        // Dependency Injection
        public SearchLocationController(ISearchLocation searchLocation)
        {
            _searchLocation = searchLocation;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<SearchJsonResponse>> Get(string location)
        {

            return await _searchLocation.GetLocation(location);

        }
    }
}
