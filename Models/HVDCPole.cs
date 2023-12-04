namespace EMS.Models
{
    public enum PoleType
    {
        Rectifier,
        InverterAndRectifier
        
        // Add other pole types as needed
    }
    public class HVDCPole
    {
        public int HVDCPoleId { get; set; }
        public int ElementId { get; set; }
        public PoleType PoleTypeEnum { get; set; }
        public string? PoleType
        {
            get => PoleTypeEnum.ToString(); // String representation of enum for storing in DB if needed
            set => PoleTypeEnum = Enum.Parse<PoleType>(value);
        }

        public int VoltageId { get; set; }
        public string? PoleName { get; set; }
        public string? PoleNumber { get; set; }
        public double MaxFiringAngle { get; set; }
        public double MinFiringAngle { get; set; }
        
        public Voltage? Voltage { get; set; }
        public Element? Element { get; set; }
    }
}