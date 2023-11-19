namespace Tournonamemt.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int GroupNumber { get; set; }
        public int ParticipantNumber { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public List<User> Participants { get; set; } = new List<User>();
        public List<Match> Matchs { get; set; } = new List<Match>();
    }
}
