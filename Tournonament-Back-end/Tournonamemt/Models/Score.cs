namespace Tournonamemt.Models
{
    public class Score
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int PlayerId { get; set; }
        public Players Player { get; set; }
        public int? MatchId { get; set; }
        public Match? Match { get; set; }
        public int? RoundId { get; set; }
        public Round? Round { get; set; }
    }
}
