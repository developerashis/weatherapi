using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApi.Service;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {      
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        [Route("{coulmnToFilter}")]
        public async Task<IActionResult> Get(string coulmnToFilter)
        {
            return Ok(await _weatherService.GetWeather(coulmnToFilter));
        }
    }
}
