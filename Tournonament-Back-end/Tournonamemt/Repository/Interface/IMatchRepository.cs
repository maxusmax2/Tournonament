using Tournonamemt.Models;

namespace Tournonamemt.Repository.Interface
{
    public interface IMatchRepository
    {
        Task<Match> GetAsync(int matchId);
        Task<Match?> SaveAsync(Match tournament);
    }
}
