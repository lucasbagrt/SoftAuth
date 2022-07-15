using System.ComponentModel.DataAnnotations;

namespace SoftAuth.Model.RequestResponse.Users;


public class AuthenticateRequest
{
    [Required]
    public string username { get; set; }

    [Required]
    public string password { get; set; }
}