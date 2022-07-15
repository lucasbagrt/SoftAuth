using System.ComponentModel.DataAnnotations;

namespace SoftAuth.Model.RequestResponse.Systems
{
    public class CreateRequest
    {
        [Required]
        public string name { get; set; }        
        public bool? self_accreditation { get; set; }
    }
}
