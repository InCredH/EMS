namespace EMS.Models
{
    public class OwnerSubstation
    {
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }
        
        public int SubstationId { get; set; }
        public Substation? Substation { get; set; }
    }
}