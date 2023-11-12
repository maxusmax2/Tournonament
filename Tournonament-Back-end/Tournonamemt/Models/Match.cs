namespace Tournonamemt.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ParticipantNumber { get; set; }
        public int TourId{ get; set; }
        public Tour Tour { get; set; }
        public List<Players> Participants { get; set; }
        public List<Score> Scores { get; set; }
    }
}
