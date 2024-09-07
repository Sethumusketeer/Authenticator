using System.ComponentModel.DataAnnotations;

namespace Authenticator.Models
{
    public class WeatherDetails
    {
        [Key] 
        public int Temperature { get; set; }
        public string? description { get; set; }
        public int? humidity { get; set; }
        public int? windSpeed { get; set; }
        public string? forecast { get; set; }
    }
}
