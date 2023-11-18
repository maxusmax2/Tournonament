using Tournonamemt.Models.Enums;

namespace Tournonamemt.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsGroupStep { get; set; }
        public DateTime? Date { get; set; }
        public int ParticipantNumber { get; set; }
        public int? TourId { get; set; }
        public Tour? Tour { get; set; }
        public MatchStatus status { get; set; } = MatchStatus.Init;
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public List<Player> Participants { get; set; }
        public List<Score> Scores { get; set; }
    }
}
