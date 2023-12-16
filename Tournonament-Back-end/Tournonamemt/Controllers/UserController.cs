using Microsoft.AspNetCore.Mvc;
using Tournonamemt.Models.DTO;
using Tournonamemt.Services.Interface;

namespace Tournonamemt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthorizationService _authorizationService;

        public UserController(IUserService userService, IAuthorizationService authorizationService)
        {
            _userService = userService;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int userId)
        {
            var user = await _userService.Get(userId);
            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
        {
            var user = await _userService.Create(dto);
            if (user is null)
                return BadRequest();
            var response = await _authorizationService.Authenticate(dto.Login, dto.Password);
            return Ok(response);
        }
        [HttpGet("GetMatchies/{userId}")]
        public async Task<IActionResult> GetMatchies(int userId)
        {
            var matches = await _userService.GetMatchies(userId);
            if (matches is null)
                return NotFound();

            return Ok(matches);
        }

        [HttpGet("GetTournament/{userId}")]
        public async Task<IActionResult> GetTournament(int userId)
        {
            var tournaments = await _userService.GetTournaments(userId);
            if (tournaments is null)
                return NotFound();

            return Ok(tournaments);
        }
    }
}
