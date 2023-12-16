using Microsoft.AspNetCore.Mvc;
using Tournonamemt.Models;
using Tournonamemt.Services.Interface;

namespace Tournonamemt.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MatchController : ControllerBase
{
    private readonly IMatchService _matchService;

    public MatchController(IMatchService matchService)
    {
        _matchService = matchService;
    }

    // GET: api/Match/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Match>> GetMatch(int id)
    {
        var match = await _matchService.GetMatchAsync(id);
        if (match is null)
            return NotFound();
        return Ok(match);
    }
}