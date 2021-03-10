using InterviewProject.Core.Models;
using InterviewProject.Core.Models.General;
using InterviewProject.Core.Models.MetaWeather;
using InterviewProject.Helpers;
using InterviewProject.Services.WeatherForecast;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            IWeatherForecastService weatherForecastService,
            ILogger<WeatherForecastController> logger)
        {
            _weatherForecastService = weatherForecastService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync(string location)
        {
            var weatherList = await _weatherForecastService.SearchLocationAsync(location);

            if (weatherList.Status)
            {
                var weatherResponse = (List<Weather>)weatherList.Data;

                if (weatherResponse.Count == 0)
                {
                    return new List<WeatherForecast>();
                }

                var locationId = weatherResponse.FirstOrDefault().Woeid;
                var forecastResponse = await _weatherForecastService.ForecastByDateAsync(locationId);

                if (forecastResponse.Status)
                {
                    var forecastList  = (List<ConsolidatedWeather>)forecastResponse.Data;

                    return forecastList.Select(x=> x.ToWeatherForecast());
                }
            }

            return new List<WeatherForecast>();
        }
    }
}
