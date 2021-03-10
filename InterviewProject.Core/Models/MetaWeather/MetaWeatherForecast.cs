using System;
using System.Text.Json.Serialization;

namespace InterviewProject.Core.Models.MetaWeather
{

    public class MetaWeatherForecast: Weather
    {
        [JsonPropertyName("consolidated_weather")]
        public ConsolidatedWeather[] ConsolidatedWeather { get; set; }

        /// <summary>
        /// Time in location
        /// </summary>
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("sun_rise")]
        public DateTime SunRise { get; set; }

        [JsonPropertyName("sun_set")]
        public DateTime SunSet { get; set; }

        /// <summary>
        /// Name of the timezone that the location is in
        /// </summary>
        [JsonPropertyName("timezone_name")]
        public string TimeZoneName { get; set; }

        /// <summary>
        /// Parent location
        /// </summary>
        [JsonPropertyName("parent")]
        public Weather Parent { get; set; }

        [JsonPropertyName("sources")]
        public WeatherSource[] Sources { get; set; }

        [JsonPropertyName("timezone")]
        public string TimeZone { get; set; }
    }


    public class ConsolidatedWeather
    {
        /// <summary>
        /// Internal identifier for the forecast
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Text description of the weather state
        /// </summary>
        [JsonPropertyName("weather_state_name")]
        public string WeatherStateName { get; set; }

        /// <summary>
        /// One or two letter abbreviation of the weather state
        /// </summary>
        [JsonPropertyName("weather_state_abbr")]
        public string WeatherStateAbbr { get; set; }

        /// <summary>
        /// Compass point of the wind direction
        /// </summary>
        [JsonPropertyName("wind_direction_compass")]
        public string WindDirectionCompass { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("applicable_date")]
        public string ApplicableDate { get; set; }

        [JsonPropertyName("min_temp")]
        public float? MinTemp { get; set; }

        [JsonPropertyName("max_temp")]
        public float? MaxTemp { get; set; }

        [JsonPropertyName("the_temp")]
        public float? TheTemp { get; set; }

        [JsonPropertyName("wind_speed")]
        public float? WindSpeed { get; set; }

        [JsonPropertyName("wind_direction")]
        public float? WindDirection { get; set; }

        [JsonPropertyName("air_pressure")]
        public float? AirPressure { get; set; }

        [JsonPropertyName("humidity")]
        public int? Humidity { get; set; }

        [JsonPropertyName("visibility")]
        public float? Visibility { get; set; }

        /// <summary>
        /// Our interpretation of the level to which the forecasters agree with each other - 100% being a complete consensus.
        /// </summary>
        [JsonPropertyName("predictability")]
        public int? Predictability { get; set; }
    }

    public class WeatherSource
    {
        /// <summary>
        /// Name of the source
        /// </summary>
        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("Slug")]
        public string Slug { get; set; }

        /// <summary>
        /// URL of the source
        /// </summary>
        [JsonPropertyName("Url")]
        public string Url { get; set; }

        [JsonPropertyName("CrawlRate")]
        public int CrawlRate { get; set; }
    }

}
