using Microsoft.AspNetCore.Mvc;

namespace BackEndSim.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FakeDataController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Hatchery", "Incubator", "Nursery", "Growout", "Harvest", "Processing", "Packaging", "Distribution", "Retail", "Consumer"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public FakeDataController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}