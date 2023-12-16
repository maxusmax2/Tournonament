using Microsoft.EntityFrameworkCore;
using Tournonamemt.Models;
using Tournonamemt.Repository.Interface;

namespace Tournonamemt.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationContext _context;
        public GroupRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Group> GetAsync(int groupId)
        {
            return await _context.groups
                .Include(x => x.Tournament)
                .Include(x => x.Participants)
                .Include(x => x.Matchs)
                .FirstAsync(x => x.Id == groupId);
        }

        public async Task<List<Group>> GetTournamentsGroupsAsync(int tournamentId)
        {
            return await _context.groups
                .Include(x => x.Participants)
                .Include(x => x.Matchs)
                .Where(x=> x.TournamentId == tournamentId)
                .ToListAsync();
        }
    }
}
