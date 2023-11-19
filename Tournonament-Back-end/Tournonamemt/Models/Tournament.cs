using Tournonamemt.Models.DTO;

namespace Tournonamemt.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int ParticipantNumber { get; set; }
        public int ParticipantNumberMax { get; set; }
        public decimal PrizeFund { get; set; }
        public string Description { get; set; }
        public TournamentFormat Format { get; set; }
        public TournamentStatus Status { get; set; }
        public bool WithGroupStep { get; set; }
        public int? GroupNumber { get; set; }
        public List<Group> Groups { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public int BracketId { get; set; }
        public Bracket Bracket { get; set; }
        public int WinnerId { get; set; }
        public User Winner { get; set; }
        public List<User> Participants { get; set; }


        public Tournament() { }
        public Tournament(TournamentCreateDto tournamentCreateDto)
        {
            Name = tournamentCreateDto.Name;
            Date = tournamentCreateDto.Date;
            ParticipantNumber = 0;
            ParticipantNumberMax = tournamentCreateDto.ParticipantNumberMax;
            PrizeFund = tournamentCreateDto.PrizeFund;
            Description = tournamentCreateDto.Description;
            Format = tournamentCreateDto.Format;
            Status = TournamentStatus.Wait;
            WithGroupStep = tournamentCreateDto.WithGroupStep;
            GroupNumber = tournamentCreateDto.GroupNumber;
            Location = tournamentCreateDto.Location;
            DisciplineId = tournamentCreateDto.DisciplineId;
            Participants = new();
            Bracket = new();
            if (WithGroupStep)
            {
                Groups = new();
                for (int i = 1; i <= GroupNumber; i++)
                {
                    Groups.Add(new Group { GroupNumber = i , TournamentId = Id});
                }
            }

        }
    }
}
