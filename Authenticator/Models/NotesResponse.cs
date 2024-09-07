using System.ComponentModel.DataAnnotations;

namespace Authenticator.Models
{
    public class NotesResponse
    {
        [Key]
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
