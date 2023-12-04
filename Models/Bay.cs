namespace EMS.Models
{
    public enum BayType
    {
        Tie,
        Main,
        Bus_Coupler,
        Bus_Sectionalizer,
        TBC,
    }

    public class Bay
    {
        public int BayId { get; set; }
        public int ElementId { get; set; }
        public int ConnectingElement1Id { get; set; }
        public int ConnectingElement2Id { get; set; }
        public int VoltageId { get; set; }
        public BayType BayTypeEnum { get; set; } // Use the enum type

        public string? BayType
        {
            get => BayTypeEnum.ToString(); // String representation of enum for storing in DB if needed
            set => BayTypeEnum = Enum.Parse<BayType>(value);
        }

        public bool IsFuture { get; set; }

        public Element? ConnectingElement1 { get; set; }
        public Element? ConnectingElement2 { get; set; }
        public Element? Element { get; set; }
        public Voltage? Voltage { get; set; }
    }
}
