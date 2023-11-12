namespace Tournonamemt.Models
{
    public class Round
    {
        public int Id { get; set; }
        public int RoundNumber { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public List<Players> Participants { get; set; }
        public List<Score> Scores { get; set; }
    }
}
