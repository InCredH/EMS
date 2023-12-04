namespace EMS.Models
{
    public enum TransformerType
    {
        ICT,
        ST,
        GT,
        IBT,
    }

    public class Transformer
    {
        public int TransformerId { get; set; }
        public int ElementId { get; set; }
        public string? TransformerName { get; set; }
        public int Voltage1Id { get; set; }
        public int Voltage2Id { get; set; }

        // public TransformerType TransformerTypeEnum { get; set; } // Use the enum type
        public int MVACapacity { get; set; }

        public TransformerType TransformerTypeEnum { get; set; }
        public string? TransformerType
        {
            get => TransformerTypeEnum.ToString();
            set => TransformerTypeEnum = Enum.Parse<TransformerType>(value);
        }

        public Voltage? Voltage1 { get; set; }
        public Voltage? Voltage2 { get; set; }
        
        public Element? Element { get; set; }
    }
}
