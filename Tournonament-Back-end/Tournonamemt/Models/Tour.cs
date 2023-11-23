namespace Tournonamemt.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public int TourNumber { get; set; }
        public int ParticipantsNumber { get; set; }
        public int MatchNumber { get; set; }
        public List<User>? Participants { get; set; } = new List<User>();
        public List<Match>? Matches { get; set; } = new List<Match>();
    }
}
