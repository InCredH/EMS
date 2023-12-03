namespace EMS.Models
{
    public class Constituent
    {
        public int ConstituentId { get; set; }
        public string? ConstituentName { get; set; }

        public ICollection<Owner>? Owners { get; set; }
    }
}