namespace EMS.Models
{
    public class Bus 
    {
        public int BusId { get; set; }
        public int ElementId { get; set; }
        public int SubstationId { get; set; }
        public string? BusType { get; set; }

        public Element? Element { get; set; }
        public Substation? Substation { get; set; }
    }
}