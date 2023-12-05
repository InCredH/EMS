namespace EMS.Models
{
    public enum BusType
    {
        Main,
        Transfer,
        Auxillary,
    }
    public class Bus 
    {
        public int BusId { get; set; }
        public int ElementId { get; set; }
        public string? BusName { get; set; }
        public BusType BusTypeEnum { get; set; } // Use the enum type

        public string? BusType
        {
            get => BusTypeEnum.ToString(); // String representation of enum for storing in DB if needed
            set => BusTypeEnum = Enum.Parse<BusType>(value);
        }

        public Element? Element { get; set; }
    }
}