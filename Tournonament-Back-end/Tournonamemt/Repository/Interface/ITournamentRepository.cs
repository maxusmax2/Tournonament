using Tournonamemt.Models;

namespace Tournonamemt.Repository.Interface
{
    public interface ITournamentRepository
    {
        Task<Tournament?> GetAsync(int tournamentId);
        Task<Tournament> SaveAsync(Tournament tournament);
        Task<List<Tournament>> GetAllAsync(int pageNumber, int pageSize);
        Task Update(Tournament tournament);
        Task<List<Tournament>> GetByDesciplineName(string name, int pageNumber, int pageGize);
        Task<List<Tournament>> Search(string name, int pageNumber, int pageGize);

    }
}
