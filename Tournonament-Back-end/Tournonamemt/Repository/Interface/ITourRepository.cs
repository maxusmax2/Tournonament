using Tournonamemt.Models;

namespace Tournonamemt.Repository.Interface
{
    public interface ITourRepository
    {
        Task<Tour?> GetAsync(int tourId);
        Task<Tour> Save(Tour tour);
        Task Update(Tour tour);
    }
}
