namespace EMS.Models
{
    public class Bay
    {
        public int BayId { get; set; }
        public int ElementId { get; set; }
        public int ConnectingElement1Id { get; set; }
        public int ConnectingElement2Id { get; set; }
        public int VoltageId { get; set; }
        public string? BayType { get; set; }
        public bool IsFuture { get; set; }

        public Element? ConnectingElement1 { get; set; }
        public Element? ConnectingElement2 { get; set; }
        public Element? Element { get; set; }
        public Voltage? Voltage { get; set; }

    }
}