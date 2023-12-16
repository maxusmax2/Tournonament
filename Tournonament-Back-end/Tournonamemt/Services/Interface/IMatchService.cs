using Tournonamemt.Models;

namespace Tournonamemt.Services.Interface;

public interface IMatchService
{
    Task<Match> GetMatchAsync(int matchId);
}
