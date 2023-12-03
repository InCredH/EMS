namespace EMS.Models
{
    public class SVC
    {
        public int SVCId { get; set; }
        public int ElementId { get; set; }
        public int BusId { get; set; }
        public string? SVCName { get; set; }
        public string? SVCNumber { get; set; }

        public Element? Element { get; set; }
        public Bus? Bus { get; set; }
    }
}