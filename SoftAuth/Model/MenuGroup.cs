using SoftAuth.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftAuth.Model
{
    [Table("menu_groups")]
    public class MenuGroup : BaseEntity
    {
        [Required]
        public int application_id { get; set; }
        [ForeignKey("application_id")]
        public virtual Application Application { get; set; }
        public string name { get; set; }
        public short order { get; set; }
        public string icon { get; set; }
    }
}
