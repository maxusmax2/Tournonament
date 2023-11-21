using Microsoft.AspNetCore.Mvc;
using Tournonamemt.Models.DTO;
using Tournonamemt.Services.Interface;

namespace Tournonamemt.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;

    public AuthController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpPost("Auth")]
    public async Task<IActionResult> Auth([FromBody] AuthRequest request)
    {
        var response = await _authorizationService.Authenticate(request.login, request.password);
        if (response == null) return BadRequest(response);
        return Ok(response);
    }
}

