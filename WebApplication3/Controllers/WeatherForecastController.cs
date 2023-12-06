using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _logger.LogCritical("Hello my first custom logger : Log CRITICAL at : {utcTime}", DateTime.UtcNow);
            _logger.LogError("Hello my first custom logger : Log ERROR at : {utcTime}", DateTime.UtcNow);
            _logger.LogWarning("Hello my first custom logger : Log WARNING at : {utcTime}", DateTime.UtcNow);
            _logger.LogInformation("Hello my first custom logger : Log INFORMATION at : {utcTime}", DateTime.UtcNow);
            _logger.LogDebug("Hello my first custom logger : Log DEBUG at : {utcTime}", DateTime.UtcNow);
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogCritical("Hello my first custom logger : Log CRITICAL at : {utcTime}", DateTime.UtcNow);
            _logger.LogError("Hello my first custom logger : Log ERROR at : {utcTime}", DateTime.UtcNow);
            _logger.LogWarning("Hello my first custom logger : Log WARNING at : {utcTime}", DateTime.UtcNow);
            _logger.LogInformation("Hello my first custom logger : Log INFORMATION at : {utcTime}", DateTime.UtcNow);
            _logger.LogDebug("Hello my first custom logger : Log DEBUG at : {utcTime}", DateTime.UtcNow);
           
            
            //_logger.LogWarning("Hello my first custom logger : Log WARNING at : {utcTime}", DateTime.UtcNow);
            //_logger.LogInformation("Hello my first custom logger : Log INFORMATION at : {utcTime}", DateTime.UtcNow);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
