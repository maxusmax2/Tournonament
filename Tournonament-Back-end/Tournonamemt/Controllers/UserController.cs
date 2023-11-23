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

        public UserController(IUserService userService)
        {
            _userService = userService;
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
        public async Task<IActionResult> Create([FromForm] UserCreateDto dto)
        {
            var user = await _userService.Create(dto);
            if (user is null)
                return BadRequest();

            return Ok(user);

        }
    }
}
