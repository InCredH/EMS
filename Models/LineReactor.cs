namespace EMS.Models
{
    public class LineReactor
    {
        public int LineReactorId { get; set; }
        public int ElementId { get; set; }
        public int SubstationId { get; set; }
        public int LineId { get; set; }

        public Element? Element { get; set; }
        public Substation? Substation { get; set; }
        public Line? Line { get; set; }
    }
}