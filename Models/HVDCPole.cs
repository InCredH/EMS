namespace EMS.Models
{
    public class HVDCPole
    {
        public int HVDCPoleId { get; set; }
        public int ElementId { get; set; }
        public string? PoleType { get; set; }
        public int VoltageId { get; set; }
        public string? PoleName { get; set; }
        public string? PoleNumber { get; set; }
        public double MaxFiringAngle { get; set; }
        public double MinFiringAngle { get; set; }
        
        public Voltage? Voltage { get; set; }
        public Element? Element { get; set; }
    }
}