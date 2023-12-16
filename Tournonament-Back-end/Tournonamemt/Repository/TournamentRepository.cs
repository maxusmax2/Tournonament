using Microsoft.EntityFrameworkCore;
using Tournonamemt.Models;
using Tournonamemt.Repository.Interface;

namespace Tournonamemt.Repository
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly ApplicationContext _context;
        public TournamentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<Tournament>> GetAllAsync(int pageNumber, int pageSize)
        {
            return _context.tournaments.Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }

        public async Task<Tournament?> GetAsync(int tournamentId)
        {
            return await _context.tournaments
                .Include(x => x.Tours)
                .Include(x => x.Participants)
                .Include(x => x.Groups)
                .FirstOrDefaultAsync(x => x.Id == tournamentId);
        }

        public async Task<List<Tournament>> GetByDesciplineName(string name, int pageNumber, int pageGize)
        {
            return await _context.tournaments.Where(x => x.Discipline.Contains(name)).Skip(pageNumber * pageGize).Take(pageGize).ToListAsync();
        }

        public async Task<List<Tournament>> Search(string name, int pageNumber, int pageGize)
        {
            return await _context.tournaments.Where(x => x.Name.Contains(name) || x.Discipline.Contains(name)).Skip(pageNumber * pageGize).Take(pageGize).ToListAsync();
        }

        public async Task<Tournament> SaveAsync(Tournament tournament)
        {
            await _context.tournaments.AddAsync(tournament);
            await _context.SaveChangesAsync();
            return tournament;
        }
        public async Task Update(Tournament tournament)
        {
            await _context.SaveChangesAsync();
        }
    }
}
