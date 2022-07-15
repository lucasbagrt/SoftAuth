namespace SoftAuth.Data.ValueObjects
{
    public class ApplicationVO
    {
        public int id { get; set; }
        public string name { get; set; }        
        public string hash { get; set; }
        public bool self_accreditation { get; set; }
    }
}
