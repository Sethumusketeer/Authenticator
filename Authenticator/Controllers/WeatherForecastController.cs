using Authenticator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authenticator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DynamicDbContext _context;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(DynamicDbContext context, ILogger<WeatherForecastController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast/{nameOfCity}/{dateInput}")]
        public IEnumerable<WeatherForecast> Get(string nameOfCity, string dateInput)
        {
            DateTime baseDate = DateTime.Parse(dateInput);

            var weatherDetails = _context.WeatherDetails.Where(x => x.Temperature != 0).ToArray();
            var city = _context.CityNames.FirstOrDefault(x => x.CityName == nameOfCity);
            var description = weatherDetails.Where(x => x.description != null).Select(a => a.description).ToArray();
            var Humidity = weatherDetails.Where(x => x.description != null).Select(a => a.humidity).ToArray();
            var WindSpeed = weatherDetails.Where(x => x.description != null).Select(a => a.windSpeed).ToArray();
            var Forecast = weatherDetails.Where(x => x.description != null).Select(a => a.forecast).ToArray();

            if(city == null) { return Enumerable.Empty<WeatherForecast>(); }

            return Enumerable.Range(0, 5).Select(index => new WeatherForecast
            {
                CityName = city.CityName,
                CityCode = city.CityCode,
                Date = DateOnly.FromDateTime(baseDate.AddDays(index)),
                Temperature = Random.Shared.Next(-20, 55),
                Description = description[Random.Shared.Next(description.Length)],
                Humidity = Humidity[Random.Shared.Next(Humidity.Length)].ToString(),
                WindSpeed = WindSpeed[Random.Shared.Next(WindSpeed.Length)].ToString(),
                Forecast = Forecast[Random.Shared.Next(Forecast.Length)],
            }).ToArray();
        }

        [HttpGet("getCities/{cityName}")]
        public ActionResult<IEnumerable<string>> GetCities(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                return BadRequest("City name is required");
            }

            var similarCityNames = _context.CityNames
                .Where(city => city.CityName.StartsWith(cityName))
                .Select(city => city.CityName)
                .ToList();

            if (!similarCityNames.Any())
            {
                return NotFound("No similar cities found");
            }

            return Ok(similarCityNames);
        }
    }
}
