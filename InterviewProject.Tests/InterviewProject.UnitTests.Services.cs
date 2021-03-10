using InterviewProject.Core.Models.General;
using InterviewProject.Core.Models.MetaWeather;
using InterviewProject.Services.WeatherForecast;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace InterviewProject.Tests
{
    public class InterviewProject_WeatherService
    {
        public HttpClient _httpClient;
        public IOptions<AppSettings> _settings;

        public InterviewProject_WeatherService()
        {
            var settings = new AppSettings
            {
                WeatherForecast = new Weatherforecast
                {
                    UrlBase = "https://www.metaweather.com/api/",
                    LocationSearch = "location/search?query={0}",
                    Forecast = "location/{0}",
                    ByDate = "location/{0}/{1}"
                }
            };

            _settings = Options.Create(settings);
            _httpClient = new HttpClient();
        }
 
        [Fact]
        public async Task SearchLocationAsync_ReturnLimaCity()
        {
            var weatherService = new WeatherForecastService(_settings, _httpClient);

            var weatherResponse = await weatherService.SearchLocationAsync("Lima");

            var weatherList = (List<Weather>)weatherResponse.Data;

            Assert.Equal("Lima", weatherList[0].Title);
        }
    }
}
