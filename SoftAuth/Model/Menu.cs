using SoftAuth.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftAuth.Model
{
    [Table("menus")]
    public class Menu : BaseEntity
    {
        [Required]
        public int menu_group_id { get; set; }
        [ForeignKey("menu_group_id")]
        public virtual MenuGroup MenuGroup { get; set; }        

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(150)]
        public string controller_name { get; set; }

        public short order { get; set; }
        public string icon { get; set; }
    }
}
