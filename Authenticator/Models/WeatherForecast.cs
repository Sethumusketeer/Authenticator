using System.ComponentModel.DataAnnotations;

namespace Authenticator.Models
{
    public class WeatherForecast
    {
        [Key]
        public DateOnly Date { get; set; }

        public string CityName { get; set; }
        public string CityCode { get; set; }

        public int Temperature { get; set; }

        public int TemperatureF => 32 + (int)(Temperature / 0.5556);

        public string? Description { get; set; }
        public string? Humidity { get; set; }
        public string? WindSpeed { get; set; }
        public string? Forecast { get; set; }
    }
}
