namespace EMS.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string? OwnerName { get; set; }
        public int ConstituentId { get; set; }

        public Constituent? Constituent { get; set; }
        public ICollection<ElementOwner>? ElementOwners { get; set; }
        public ICollection<OwnerSubstation>? OwnerSubstations { get; set; }
    }
}