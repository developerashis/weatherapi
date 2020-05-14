using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApi.Model;

namespace WeatherApi.Service
{
    public interface IWeatherService
    {
        public  Task<List<Temparature>> GetWeather(string columnToFilter);
    }
}
