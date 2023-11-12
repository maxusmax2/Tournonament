namespace Tournonamemt.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int GroupNumber { get; set; }
        public List<Players> Participant { get; set; }
        public List<Match> Match { get; set; }
        public int? TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
