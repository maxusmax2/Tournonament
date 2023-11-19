using Microsoft.AspNetCore.Mvc;
using Tournonamemt.Models;
using Tournonamemt.Models.DTO;
using Tournonamemt.Services.Interface;

namespace Tournonamemt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet]
        public async Task<Tournament> Get(int tournamentId)
        {
            return await _tournamentService.GetTournamentAsync(tournamentId);
        }
        [HttpPost]
        public async Task<Tournament> Create(TournamentCreateDto dto)
        {
            return await _tournamentService.CreateTournamentAsync(dto);
        }

        [HttpPut("CloseRecruitment")]
        public async Task<Tournament> CloseRecruitment(int tournamentId)
        {
            return await _tournamentService.CloseParticipantRecruitmentAsync(tournamentId);
        }

        [HttpPut("AddParticipant")]
        public async Task<Tournament> AddParticipant(int playerId, int tournamentId)
        {
            return await _tournamentService.AddParticipantAsync(playerId, tournamentId);
        }

        [HttpPut("RemoveParticipant")]
        public async Task<Tournament> RemoveParticipant(int playerId, int touramentId)
        {
            return await _tournamentService.RemoveParticipantAsync(playerId, touramentId);
        }

        [HttpDelete]
        public async Task<Tournament> DeclineTournament(int tournamentId)
        {
            return await _tournamentService.DeclineTournamentAsync(tournamentId);
        }

        [HttpGet("GetAll")]
        public async Task<List<Tournament>> GetAll(int pageNumber, int pageGize)
        {
            return await _tournamentService.GetTournamentsAsync(pageNumber, pageGize);
        }

        [HttpPut("CloseGroups")]
        public async Task<Tournament> CloseGroups(int tournamentId)
        {
            return await _tournamentService.CloseGroupsAsync(tournamentId);
        }
        [HttpPut("CloseMatch")]
        public async Task<Tournament> CloseMatch(CloseMatchRequestDto dto)
        {
            return await _tournamentService.CloseMatchAsync(dto);
        }
    }
}
