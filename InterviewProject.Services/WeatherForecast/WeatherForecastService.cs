using InterviewProject.Core.Models.General;
using InterviewProject.Core.Models.MetaWeather;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static InterviewProject.Core.Models.General.AppEnums;

namespace InterviewProject.Services.WeatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public AppSettings _appSettings;
        public HttpClient _httpClient;

        public WeatherForecastService(
            IOptions<AppSettings> appSettings,
            HttpClient httpClient)
        {
            _appSettings = appSettings.Value;

            httpClient.BaseAddress = new Uri(_appSettings.WeatherForecast.UrlBase);
            _httpClient = httpClient;
        }


        public async Task<AppResponse> SearchLocationAsync(string location)
        {
            var output = new AppResponse();

            try
            {
                var response = await _httpClient.GetStreamAsync(string.Format(_appSettings.WeatherForecast.LocationSearch, location));

                var weatherList = await JsonSerializer.DeserializeAsync<List<Weather>>(response);

                output.Status = true;
                output.Message = "Weather loaded!";
                output.Type = ResponseType.Success;
                output.Data = weatherList;

            }
            catch (Exception ex)
            {
                output.Status = false;
                output.Type = ResponseType.Error;
                output.Message = ex.Message;
                output.Data = ex;
                output.Trace = ex.StackTrace;
            }

            return output;
        }

        public async Task<AppResponse> ForecastByLocationIdAsync(int locationId)
        {
            var output = new AppResponse();

            try
            {
                var response = await _httpClient.GetStreamAsync(string.Format(_appSettings.WeatherForecast.Forecast, locationId));

                var weatherForecast = await JsonSerializer.DeserializeAsync<MetaWeatherForecast>(response);

                output.Status = true;
                output.Message = "Forecast loaded!";
                output.Type = ResponseType.Success;
                output.Data = weatherForecast;

            }
            catch (Exception ex)
            {
                output.Status = false;
                output.Type = ResponseType.Error;
                output.Message = ex.Message;
                output.Data = ex;
                output.Trace = ex.StackTrace;
            }

            return output;
        }

        public async Task<AppResponse> ForecastByDateAsync(int locationId)
        {
            var output = new AppResponse();

            try
            {
                var weatherForecast = new List<ConsolidatedWeather>();

                for (int i = 0; i < 5; i++)
                {
                    var startDate = DateTime.Today.AddDays(i);
                    var formattedDate = $"{startDate.Year}/{startDate.Month}/{startDate.Day}";

                    var response = await _httpClient.GetStreamAsync(string.Format(_appSettings.WeatherForecast.ByDate, locationId, formattedDate));

                    var weatherForecastList = await JsonSerializer.DeserializeAsync<List<ConsolidatedWeather>>(response);

                    weatherForecast.Add(weatherForecastList.FirstOrDefault());
                }

                output.Status = true;
                output.Message = "Forecast loaded!";
                output.Type = ResponseType.Success;
                output.Data = weatherForecast;

            }
            catch (Exception ex)
            {
                output.Status = false;
                output.Type = ResponseType.Error;
                output.Message = ex.Message;
                output.Data = ex;
                output.Trace = ex.StackTrace;
            }

            return output;
        }
    }
}
