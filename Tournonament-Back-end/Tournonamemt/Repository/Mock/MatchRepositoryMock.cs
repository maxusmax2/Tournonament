using Tournonamemt.Models;
using Tournonamemt.Repository.Interface;

namespace Tournonamemt.Repository.Mock
{
    public class MatchRepositoryMock : IMatchRepository
    {
        private static Dictionary<int, Match> storage = new Dictionary<int, Match>();
        static MatchRepositoryMock()
        {
            storage = new Dictionary<int, Match>();
            storage[0] = new Match();
        }
        public async Task<Match> GetAsync(int matchId)
        {
            return storage[matchId];
        }

        public async Task<Match?> SaveAsync(Match match)
        {
            if (match.Id == 0)
            {
                var newId = storage.Keys.Max() + 1;
                storage[newId] = match;
                match.Id = newId;
                return match;
            }
            storage[match.Id] = match;
            return match;
        }
    }
}
