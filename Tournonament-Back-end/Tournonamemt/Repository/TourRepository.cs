using Microsoft.EntityFrameworkCore;
using Tournonamemt.Models;
using Tournonamemt.Repository.Interface;

namespace Tournonamemt.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly ApplicationContext _context;

        public TourRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Tour?> GetAsync(int tourId)
        {
            return await _context.tours
                .Include(x => x.Matches)
                .Include(x => x.Participants)
                .FirstAsync(x => x.Id == tourId);

        }

        public async Task<Tour> Save(Tour tour)
        {
            await _context.tours.AddAsync(tour);
            await _context.SaveChangesAsync();
            return tour;
        }

        public async Task Update(Tour tour)
        {
            await _context.SaveChangesAsync();
        }
    }
}
