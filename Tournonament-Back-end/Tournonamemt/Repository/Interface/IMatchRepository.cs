using Tournonamemt.Models;

namespace Tournonamemt.Repository.Interface
{
    public interface IMatchRepository
    {
        Task<Match> GetMatchAsync(int matchId);
    }
}
