using Tournonamemt.Models;

namespace Tournonamemt.Repository.Interface
{
    public interface ITournamentRepository
    {
        Task<Tournament?> GetAsync(int tournamentId);
        Task<Tournament> SaveAsync(Tournament tournament);
        Task<List<Tournament>> GetAllAsync(int pageNumber, int pageSize);
        Task Update(Tournament tournament);
        Task<List<Tournament>> GetByDesciplineName(string name);
        Task<List<Tournament>> GetTournamentByName(string name);
    }
}
