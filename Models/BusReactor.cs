namespace EMS.Models
{
    public class BusReactor 
    {
        public int BusReactorId { get; set; }
        public int ElementId { get; set; }
        public int BusId { get; set; }
        public int MVARCapacity { get; set; }
        public string? BusName { get; set; }

        public Element? Element { get; set; }
        public Bus? Bus { get; set; }
    }
}