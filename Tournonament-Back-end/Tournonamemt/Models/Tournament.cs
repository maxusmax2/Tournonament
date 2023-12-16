using System.ComponentModel.DataAnnotations.Schema;
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
        public int? numberLeavingTheGroup { get; set; }
        public List<Group> Groups { get; set; }
        public string Location { get; set; }
        public string? ImageUrl { get; set; }

        public string Discipline { get; set; }
        public int CreatorId { get; set; }
        public int? WinnerId { get; set; }
        [NotMapped]
        public User? Winner { get; set; }
        public List<User> Participants { get; set; }
        public int TourNumber { get; set; }
        public List<Tour> Tours { get; set; }


        public Tournament() { }
        public Tournament(TournamentCreateDto tournamentCreateDto)
        {
            Name = tournamentCreateDto.Name;
            Date = tournamentCreateDto.Date;
            CreatorId = tournamentCreateDto.CreatorId;
            numberLeavingTheGroup = tournamentCreateDto.NumberLeavingTheGroup;
            ParticipantNumber = 0;
            ParticipantNumberMax = tournamentCreateDto.ParticipantNumberMax;
            PrizeFund = tournamentCreateDto.PrizeFund;
            Description = tournamentCreateDto.Description;
            Format = tournamentCreateDto.Format;
            Status = TournamentStatus.Wait;
            WithGroupStep = tournamentCreateDto.WithGroupStep;
            GroupNumber = tournamentCreateDto.GroupNumber;
            Location = tournamentCreateDto.Location;
            Discipline = tournamentCreateDto.Discipline;
            Participants = new();
            if (WithGroupStep)
            {
                Groups = new();
                for (int i = 1; i <= GroupNumber; i++)
                {
                    Groups.Add(new Group { GroupNumber = i, TournamentId = Id });
                }
            }

        }
    }
}
