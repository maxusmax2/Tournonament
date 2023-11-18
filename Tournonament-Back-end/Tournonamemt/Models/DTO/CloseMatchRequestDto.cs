namespace Tournonamemt.Models.DTO
{
    public class CloseMatchRequestDto
    {
        public int TournamentId;
        public int MatchId;
        public List<Score> ScoreList = new();
    }
}
