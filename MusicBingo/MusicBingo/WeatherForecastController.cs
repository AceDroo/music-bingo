using Microsoft.AspNetCore.Mvc;

namespace MusicBingo;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly Random _random = new();

    private readonly string[] _summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
    
    [HttpGet]
    [Route("weatherforecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(CreateWeatherForecast).ToArray();
    }

    private WeatherForecast CreateWeatherForecast(int index)
    {
        return new WeatherForecast(
            DateTime.Now.AddDays(index), 
            _random.Next(-20, 55), 
            _summaries[_random.Next(_summaries.Length)]
        );
    }
}