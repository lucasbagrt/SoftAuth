using System.ComponentModel.DataAnnotations;

namespace SoftAuth.Model.RequestResponse.Users
{
    public class CreateRequest
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public Role Role { get; set; }
    }
}
