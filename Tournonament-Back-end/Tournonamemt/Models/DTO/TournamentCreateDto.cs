﻿namespace Tournonamemt.Models.DTO
{
    public class TournamentCreateDto
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int ParticipantNumberMax { get; set; }
        public decimal PrizeFund { get; set; }
        public string Description { get; set; }
        public TournamentFormat Format { get; set; }
        public bool WithGroupStep { get; set; }
        public int? GroupNumber { get; set; }
        public string Location { get; set; }
        public string Discipline { get; set; }
        public int? NumberLeavingTheGroup { get; set; }
        public int CreatorId { get; set; }

    }
}
