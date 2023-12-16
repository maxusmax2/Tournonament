using Tournonamemt.Models;
using Tournonamemt.Repository.Interface;
using Tournonamemt.Services.Interface;

namespace Tournonamemt.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<Match> GetMatchAsync(int matchId)
        {
            return await _matchRepository.GetAsync(matchId);
        }
    }
}
