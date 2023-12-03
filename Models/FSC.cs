namespace EMS.Models
{
    public class FSC
    {
        public int FSCId { get; set; }
        public int ElementId { get; set; }

        public Element? Element { get; set; }
    }
}