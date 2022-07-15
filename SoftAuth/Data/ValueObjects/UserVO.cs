using SoftAuth.Model;
using System.Text.Json.Serialization;

namespace SoftAuth.Data.ValueObjects
{
    public class UserVO
    {
        public int id { get; set; }
        public string first_name { get; set; } 
        public string last_name { get; set; } 
        public string email { get; set; }
        public string username { get; set; }
        [JsonIgnore]
        public string password { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }
        public UserVO(User user, string token)
        {
            id = user.id;
            first_name = user.first_name;
            last_name = user.last_name;
            email = user.email;
            username = user.username;
            Role = user.Role;
            Token = token;
        }
        public UserVO()
        {
        }
    }
}
