using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace Application1
{
    public interface IApplication2ApiClient
    {
        [Get("/WeatherForecast")]
        public Task<HttpResponseMessage> GetWeatherForecastsAsync();
    }
}
