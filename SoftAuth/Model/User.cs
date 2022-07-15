using SoftAuth.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftAuth.Model
{
    [Table("users")]
    public class User : BaseEntity
    {        
        [Required]
        [StringLength(50)]
        public string first_name { get; set; }
     
        [Required]
        [StringLength(100)]
        public string last_name { get; set; } 

        [Required]
        [StringLength(150)]
        public string email { get; set; } 
        
        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [StringLength(150)]
        public string password { get; set; }       
        public Role Role { get; set; }
    }
}
