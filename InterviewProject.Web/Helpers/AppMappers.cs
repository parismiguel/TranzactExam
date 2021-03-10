using InterviewProject.Core.Models;
using InterviewProject.Core.Models.MetaWeather;
using System;

namespace InterviewProject.Helpers
{
    public static class AppMappers
    {
        public static WeatherForecast ToWeatherForecast(this ConsolidatedWeather input)
        {
            return new WeatherForecast { 
                Date = input.ApplicableDate,
                TemperatureC = Math.Round(input.TheTemp.Value, 2),
                Icon = $"https://www.metaweather.com/static/img/weather/{input.WeatherStateAbbr}.svg",
                Summary = input.WeatherStateName
            };
        }
    }
}
