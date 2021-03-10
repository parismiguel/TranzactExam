using InterviewProject.Core.Models.General;
using System.Threading.Tasks;

namespace InterviewProject.Services.WeatherForecast
{
    public interface IWeatherForecastService
    {
        Task<AppResponse> SearchLocationAsync(string location);
        Task<AppResponse> ForecastByLocationIdAsync(int locationId);
        Task<AppResponse> ForecastByDateAsync(int locationId);
    }
}
