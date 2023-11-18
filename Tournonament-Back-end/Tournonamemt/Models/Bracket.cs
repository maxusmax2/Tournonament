namespace Tournonamemt.Models
{
    public class Bracket
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public int TourNumber { get; set; }
        public List<Tour> Tours { get; set; } = new List<Tour>();
    }
}
