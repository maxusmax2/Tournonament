namespace Tournonamemt.Models.DTO
{
    public class CloseMatchRequestDto
    {
        public int TournamentId { get; set; }
        public int MatchId { get; set; }
        public List<ScoreDto> ScoreList { get; set; }
    }
}
