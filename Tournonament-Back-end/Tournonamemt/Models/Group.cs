namespace Tournonamemt.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int GroupNumber { get; set; }
        public int ParticipantNumber { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public List<Player> Participants { get; set; } = new List<Player>();
        public List<Match> Matchs { get; set; } = new List<Match>();
    }
}
