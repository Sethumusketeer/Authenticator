using System.ComponentModel.DataAnnotations;

namespace Authenticator.Models
{
    public class WeatherUser
    {
        public string Name { get; set; }
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
