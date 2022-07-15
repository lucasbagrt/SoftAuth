using SoftAuth.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace SoftAuth.Model
{
    public class Profile : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        public string type { get; set; }
        public string dashboard { get; set; }
    }
}
