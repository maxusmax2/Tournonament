using Microsoft.AspNetCore.Mvc;

using Tournonamemt.Models;
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
        public async Task<User> Get(int userId)
        {
            return await _userService.Get(userId);
        }
        [HttpPost]
        public async Task<User> Create(UserCreateDto dto)
        {
            return await _userService.Create(dto);
        }
    }
}
