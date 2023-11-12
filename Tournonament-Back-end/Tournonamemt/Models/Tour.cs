﻿namespace Tournonamemt.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public int TourNumber { get; set; }
        public int ParticipantsNumber { get; set; }
        public int MatchNumber { get; set; }
        public List<Players>? Participants { get; set; }
        public List<Match>? Match { get; set; }
    }
}
