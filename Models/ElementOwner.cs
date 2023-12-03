namespace EMS.Models
{
    public class ElementOwner
    {
        public int ElementId { get; set; }
        public Element? Element { get; set; }

        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
