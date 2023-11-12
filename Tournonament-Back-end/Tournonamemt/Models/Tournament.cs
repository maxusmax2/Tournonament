namespace Tournonamemt.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int ParticipantNumber { get; set; }
        public decimal PrizeFund { get; set; }
        public string Description { get; set; }
        public TournamentFormat Format { get; set; }
        public bool WithGroupStep { get; set; }
        public int? GroupNumber { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }

    }
}
