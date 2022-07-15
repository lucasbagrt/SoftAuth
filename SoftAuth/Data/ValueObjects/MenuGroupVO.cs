using SoftAuth.Model;
using System.ComponentModel.DataAnnotations;

namespace SoftAuth.Data.ValueObjects
{
    public class MenuGroupVO
    {
        public int id { get; set; }
        public int application_id { get; set; }        
        public string name { get; set; }
        public short order { get; set; }
        public string icon { get; set; }
        public Application Application { get; set; }   
    }
}
