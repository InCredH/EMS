using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class Element
    {
        public int ElementId { get; set; }
        public int? Substation1Id { get; set; }
        public int? Substation2Id { get; set; }
        public string? ElementType { get; set; }
        public string? ElementNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime CommissioningDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DecommissioningDate { get; set; }
        public int? LocationId { get; set; }

        public Substation? Substation1 { get; set; }
        public Substation? Substation2 { get; set; }
        public Location? Location { get; set; }
        public ICollection<ElementOwner>? ElementOwners { get; set; }
    }
}