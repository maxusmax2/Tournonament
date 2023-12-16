using Tournonamemt.Models;
using Tournonamemt.Models.DTO;

namespace Tournonamemt.Services.Interface
{
    public interface ITournamentService
    {
        Task<Tournament?> GetTournamentAsync(int tournamentId);
        Task<List<Tournament>> GetTournamentsAsync(int pageNumber, int pageSize);
        Task<Tournament> CreateTournamentAsync(TournamentCreateDto tournamentDto);
        Task<Tournament> DeclineTournamentAsync(int tournamentId);
        Task<Tournament> AddParticipantAsync(int playerId, int tournamentId);
        Task<Tournament> RemoveParticipantAsync(int playerId, int tournamentId);
        Task<Tournament> CloseMatchAsync(CloseMatchRequestDto request);
        Task<Tournament> CloseParticipantRecruitmentAsync(int tournamentId);
        Task<Tournament?> CloseGroupsAsync(int tournamentId);
        Task<List<Tournament>> Search(string name, int pageNumber, int pageGize);
        Task<List<Tour>?> GetTournamentsToursAsync(int tournamentId);
    }
}
