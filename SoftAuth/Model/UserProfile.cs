using SoftAuth.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftAuth.Model
{
    public class UserProfile : BaseEntity
    {
        [Required]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual User user { get; set; }
        [Required]
        public int profile_id { get; set; }
        [ForeignKey("profile_id")]
        public virtual Profile role { get; set; }
        [Required]
        public int application_id { get; set; }
        [ForeignKey("application_id")]
        public virtual Application Application { get; set; }
    }
}
