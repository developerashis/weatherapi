using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApi.Helper;
using WeatherApi.Model;

namespace WeatherApi.Service
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private static int index  = 0;
        public WeatherService(IHttpClientHelper httpClientHelper) {
            _httpClientHelper = httpClientHelper;
        }
        public async Task<List<Temparature>> GetWeather(string columnToFilter)
        {
            string apiUrl = string.Format(APIConstants.ApiUrl, columnToFilter);
            var response = await _httpClientHelper.SendHttpRequest(Method.Get, apiUrl, null, APIConstants.WeatherAPIBaseUrl);
            if (response != null && response.IsSuccessStatusCode) {                
                dynamic temp = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                return new List<Temparature>() { new Temparature() { Name = temp.name, Temp = temp.main.temp, Index = ++ index } } ;
             }
            return null;
        }
    }
}
