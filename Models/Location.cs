namespace EMS.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string? LocationName { get; set; }
        public int RegionId { get; set; }
        public int StateId { get; set; }
        public string? Alias { get; set; }

        public Region? Region { get; set; }
        public State? State { get; set; }
    }
}