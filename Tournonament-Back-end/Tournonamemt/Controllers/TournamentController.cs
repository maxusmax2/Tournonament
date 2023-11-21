using Microsoft.AspNetCore.Mvc;
using Tournonamemt.Models;
using Tournonamemt.Models.DTO;
using Tournonamemt.Services.Interface;

namespace Tournonamemt.Controllers;

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
    public async Task<IActionResult> Get(int tournamentId)
    {
        var tournament = await _tournamentService.GetTournamentAsync(tournamentId);
        if (tournament is null) return NotFound();
        return Ok(tournament);
    }
    [HttpPost]
    public async Task<IActionResult> Create(TournamentCreateDto dto)
    {
        var tournament = await _tournamentService.CreateTournamentAsync(dto);
        if (tournament is null) return BadRequest();
        return Ok(tournament);
    }

    [HttpPut("CloseRecruitment")]
    public async Task<IActionResult> CloseRecruitment(int tournamentId)
    {
        var tournament = await _tournamentService.CloseParticipantRecruitmentAsync(tournamentId);
        if (tournament is null) return BadRequest();
        return Ok(tournament);
    }

    [HttpPut("AddParticipant")]
    public async Task<IActionResult> AddParticipant(int playerId, int tournamentId)
    {
        var tournament = await _tournamentService.AddParticipantAsync(playerId, tournamentId);
        if (tournament is null) return BadRequest();
        return Ok(tournament);
    }

    [HttpPut("RemoveParticipant")]
    public async Task<IActionResult> RemoveParticipant(int playerId, int touramentId)
    {
        var tournament = await _tournamentService.RemoveParticipantAsync(playerId, touramentId);
        if (tournament is null) return BadRequest();
        return Ok(tournament);
    }

    [HttpPut("DeclineTournament")]
    public async Task<IActionResult> DeclineTournament(int tournamentId)
    {
        var tournament = await _tournamentService.DeclineTournamentAsync(tournamentId);
        if (tournament is null) return BadRequest();
        return Ok(tournament);
    }

    [HttpGet("GetAll")]
    public async Task<List<Tournament>> GetAll(int pageNumber, int pageGize)
    {
        return await _tournamentService.GetTournamentsAsync(pageNumber, pageGize);
    }

    [HttpPut("CloseGroups")]
    public async Task<IActionResult> CloseGroups(int tournamentId)
    {
        var tournament = await _tournamentService.CloseGroupsAsync(tournamentId);
        if (tournament is null)
            return BadRequest();
        return Ok(tournament);
    }
    [HttpPut("CloseMatch")]
    public async Task<IActionResult> CloseMatch(CloseMatchRequestDto dto)
    {
        var tournament = await _tournamentService.CloseMatchAsync(dto);
        if (tournament is null)
            return BadRequest();
        return Ok(tournament);
    }

    [HttpGet("GetTournamentByDisciplineName")]
    public async Task<IActionResult> GetTournamentByDisciplineName(string name)
    {
        var tournaments = await _tournamentService.GetTournamentByDesciplineName(name);
        if (tournaments is null) return BadRequest();
        return Ok(tournaments);
    }
    [HttpGet("GetTournamentByName")]
    public async Task<IActionResult> GetTournamentByName(string name)
    {
        var tournaments = await _tournamentService.GetTournamentByName(name);
        if (tournaments is null) return BadRequest();
        return Ok(tournaments);
    }
}

