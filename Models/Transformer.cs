namespace EMS.Models
{
    public class Transformer
    {
        public int TransformerId { get; set; }
        public int ElementId { get; set; }
        public string? TransformerName { get; set; }
        public string? TransformerType { get; set; }
        public int Voltage1Id { get; set; }
        public int Voltage2Id { get; set; }
        public int LocationId { get; set; }
        public int MVACapacity { get; set; }

        public Voltage? Voltage1 { get; set; }
        public Voltage? Voltage2 { get; set; }
        public Location? Location { get; set; }
        public Element? Element { get; set; }
    }
}