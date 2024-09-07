using System.ComponentModel.DataAnnotations;

namespace Authenticator.Models
{
    public class CityNames
    {
        [Key]
        public string CityName { get; set; }
        public string CityCode { get; set; }
    }
}
