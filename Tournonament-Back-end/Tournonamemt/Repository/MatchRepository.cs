using Microsoft.EntityFrameworkCore;
using Tournonamemt.Models;
using Tournonamemt.Repository.Interface;

namespace Tournonamemt.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly ApplicationContext _context;
        public MatchRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Match> GetAsync(int matchId)
        {
            return await _context.matches
                .Include(x => x.Tournament)
                .Include(x => x.Tour)
                .Include(x => x.Participants)
                .Include(x => x.Scores)
                .FirstAsync(x => x.Id == matchId);
        }

        public async Task<Match?> SaveAsync(Match match)
        {
            await _context.matches.AddAsync(match);
            return await GetAsync(match.Id);
        }
    }
}
