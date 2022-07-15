using System.ComponentModel.DataAnnotations;

namespace SoftAuth.Model.RequestResponse.Menus
{
    public class CreateRequest
    {
        [Required]
        public int menu_group_id { get; set; }          
        public string name { get; set; }        
        public string controller_name { get; set; }
        public short order { get; set; }
        public string icon { get; set; }
    }
}
