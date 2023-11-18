using Tournonamemt.Models;

namespace Tournonamemt.Repository.Interface
{
    public interface ITournamentRepository
    {
        Task<Tournament?> GetTournamentAsync(int tournamentId);
        Task<Tournament?> SaveTournament(Tournament tournament);
        Task<List<Tournament>> GetTournamentsAsync(int pageNumber, int pageSize);
        Task<Tournament?> CloseGroup(int tournamentId);
        Task<Tournament> closeParticipantRecruitment(int tournamentId);
    }
}
