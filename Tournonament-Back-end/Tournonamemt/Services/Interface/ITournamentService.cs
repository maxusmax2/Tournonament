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
        Task<Tournament> CloseMatch(CloseMatchRequestDto request);
        Task<Tournament?> CloseGroups(int tournamentId);
    }
}
