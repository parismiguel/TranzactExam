namespace InterviewProject.Core.Models.General
{
    public class AppSettings
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public Weatherforecast WeatherForecast { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
    }

    public class Weatherforecast
    {
        public string UrlBase { get; set; }
        public string LocationSearch { get; set; }
        public string Forecast { get; set; }
        public string ByDate { get; set; }
    }

}
