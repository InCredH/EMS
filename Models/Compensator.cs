namespace EMS.Models
{
    public class Compensator
    {
        public int CompensatorId { get; set; }
        public int ElementId { get; set; }
        public int PercentageVariableCompensation { get; set; }
        public int PercentageFixedCompensation { get; set; }

        public Element? Element { get; set; }
    }
}