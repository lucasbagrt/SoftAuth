namespace SoftAuth.Model.RequestResponse.Profiles
{
    public class CreateAppUserRequest
    {        
        public int user_id { get; set; }             
        public string application { get; set; } //hash or id        
    }
}
