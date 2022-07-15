using System.ComponentModel.DataAnnotations;

namespace SoftAuth.Model.RequestResponse.Users
{
    public class LogRequest
    {
        [Required]
        public int user_id { get; set; }
        [Required]
        public string log { get; set; }
    }
}
