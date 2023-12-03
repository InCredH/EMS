namespace EMS.Models
{
    public class GeneratingUnit 
    {
        public int GeneratingUnitId { get; set; }
        public int ElementId { get; set; }
        public string? GeneratingUnitName { get; set; }
        public int GeneratingStationId { get; set; }
        public int InstalledCapacity { get; set; }
        public int VoltageId { get; set; }
        public int GeneratingTransformerHVVoltageId { get; set; }

        public GeneratingStation? GeneratingStation { get; set; }
        public Element? Element { get; set; }
        public Voltage? Voltage { get; set; }
        public Voltage? GeneratingTransformerHVVoltage { get; set; }
    }
}