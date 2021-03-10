namespace InterviewProject.Core.Models
{
    public class WeatherForecast
    {
        public string Date { get; set; }

        public double TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Icon { get; set; }

        public string Summary { get; set; }

        public static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }
}
