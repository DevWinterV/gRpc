using BasketApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasketApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IItemService itemService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IItemService itemService)
        {
            _logger = logger;
            this.itemService = itemService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("item")]
        public async Task<IActionResult> GetItem([FromQuery] int id)
        {
             
            return Ok(await itemService.GetItemAsync(id));
        }
    }
}
