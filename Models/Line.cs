namespace EMS.Models
{
    
    public class Line
    {
        public int LineId { get; set; }
        public string? LineType {  get; set; }
        public int ElementId { get; set; }
        public int FromBusId { get; set; }
        public int ToBusId { get; set; }
        public int? VoltageId { get; set; }
        public string? CircuitNumber { get; set; }
        public string? LineName { get; set; }
        public double Length { get; set; }
        public string? ConductorType { get; set; }
        public bool AutoReclosure { get; set; }
        public string? LineCircuitName { get; set; }
        public bool SendingEndSPS { get; set; }
        public bool ReceivingEndSPS { get; set; }
        public DateOnly? FirstChargingDate { get; set; }

        public Element? Element { get; set; }
        public Bus? FromBus { get; set; }
        public Bus? ToBus { get; set; }
        public Voltage? Voltage { get; set; }
    }
}