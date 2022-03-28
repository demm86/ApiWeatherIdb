using ApiWeather;
using ApiWeather.Controllers;
using ApiWeather.Sevices;
using ApiWeather.Sevices.Impl;
using ApiWeather.weatherApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitApiWeatherTest
{
    public class CurrentControllerTest
    {

        CurrentController _controller;
        ICurrentWeather _service;


        public CurrentControllerTest()
        {


            HttpClient client = new HttpClient();
            WeatherSettings settings = new WeatherSettings();
            settings.ApiKey = "c3295b150c1a4447bd184010210709";
            settings.BaseUrl = "http://api.weatherapi.com/v1/";
            settings.NoDaysForecast = 5;



            _service = new CurrentWeather(client, settings);
            _controller = new CurrentController(_service);

        }


        [Fact]
        public void GetAllTest()
        {
            var result = _controller.Get("london");

            //Assert
            Assert.IsType<CurrentJsonResponse>(result.Result);


        }



    }
}
