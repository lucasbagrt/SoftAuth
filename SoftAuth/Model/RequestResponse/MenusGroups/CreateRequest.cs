namespace SoftAuth.Model.RequestResponse.MenusGroups
{
    public class CreateRequest
    {        
        public int application_id { get; set; }               
        public string name { get; set; }
        public short order { get; set; }
        public string icon { get; set; }
    }
}
