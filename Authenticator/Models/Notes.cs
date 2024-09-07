using System.ComponentModel.DataAnnotations;

namespace Authenticator.Models
{
    public class Notes
    {
        public int UserId { get; set; }
        [Key]
        public int RecordId { get; set; }
        public string Content { get; set; }
    }
}
