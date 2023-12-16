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
    private readonly IGroupService _groupService;

    public TournamentController(ITournamentService tournamentService, IGroupService groupService)
    {
        _tournamentService = tournamentService;
        _groupService = groupService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(int tournamentId)
    {
        var tournament = await _tournamentService.GetTournamentAsync(tournamentId);
        if (tournament is null) return NotFound();
        return Ok(tournament);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TournamentCreateDto dto)
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

    [HttpPut("CloseMatch")]
    public async Task<IActionResult> CloseMatch(CloseMatchRequestDto dto)
    {
        var tournament = await _tournamentService.CloseMatchAsync(dto);
        if (tournament is null)
            return BadRequest();
        return Ok(tournament);
    }
    [HttpPut("CloseGroups")]
    public async Task<IActionResult> CloseGroups(int tournamentId)
    {
        var tournament = await _tournamentService.CloseGroupsAsync(tournamentId);
        if (tournament is null)
            return BadRequest();
        return Ok(tournament);
    }


    [HttpGet("Search")]
    public async Task<IActionResult> GetTournamentByName(string name, int pageNumber, int pageGize)
    {
        var tournaments = await _tournamentService.Search(name, pageNumber, pageGize);
        if (tournaments is null) return BadRequest();
        return Ok(tournaments);
    }

    [HttpGet("GetTournamentsTours")]
    public async Task<IActionResult> GetTournamentsTours(int tournamentId)
    {
        var tours = await _tournamentService.GetTournamentsToursAsync(tournamentId);
        if (tours is null) return BadRequest();
        return Ok(tours);
    }
    [HttpGet("GetTournamentsGroups/{tournamentId}")]
    public async Task<IActionResult> GetTournamentsGroups(int tournamentId)
    {
        var groups = await _groupService.GetTournamentsGroupsAsync(tournamentId);
        if (groups is null) return BadRequest();
        return Ok(groups);
    }
}

