namespace EMS.Models
{
    public class LineReactor
    {
        public int LineReactorId { get; set; }
        public int ElementId { get; set; }
        public int LineId { get; set; }
        public int MVARCapacity { get; set; }
        public String LineReactorName { get; set; }
        public Element? Element { get; set; }
        
        public Line? Line { get; set; }
    }
}