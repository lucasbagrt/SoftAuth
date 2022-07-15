using SoftAuth.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftAuth.Model
{
    [Table("applications")]
    public class Application : BaseEntity
    {        
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        
        [Required]
        [StringLength(150)]
        public string hash { get; set; }

        public bool self_accreditation { get; set; }

    }
}
