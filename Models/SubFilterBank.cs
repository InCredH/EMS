namespace EMS.Models
{
    public class SubFilterBank
    {
        public int SubFilterBankId { get; set; }
        public int ElementId { get; set; }
        public int FilterBankId { get; set; }

        public FilterBank? FilterBank { get; set; }
        public Element? Element { get; set; }
    }
}