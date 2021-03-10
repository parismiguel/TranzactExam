using System.Text.Json.Serialization;

namespace InterviewProject.Core.Models.MetaWeather
{

    public class MetaWeatherResponse
    {
        public Weather[] Weather { get; set; }
    }

    public class Weather
    {
        /// <summary>
        /// Name of the location
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// (City|Region / State / Province|Country|Continent)
        /// </summary>
        [JsonPropertyName("location_type")]
        public string LocationType { get; set; }

        /// <summary>
        /// Where On Earth ID
        /// </summary>
        [JsonPropertyName("woeid")]
        public int Woeid { get; set; }

        /// <summary>
        /// Latitude, Longitude
        /// </summary>
        [JsonPropertyName("latt_long")]
        public string LatLong { get; set; }
    }

}
