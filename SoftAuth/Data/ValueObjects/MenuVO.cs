using SoftAuth.Model;

namespace SoftAuth.Data.ValueObjects
{
    public class MenuVO
    {       
        public int id { get; set; }
        public int menu_group_id { get; set; }                    
        public string name { get; set; }        
        public string controller_name { get; set; }
        public short order { get; set; }
        public string icon { get; set; }
        public MenuGroup menu_group { get; set; }                
    }
}
