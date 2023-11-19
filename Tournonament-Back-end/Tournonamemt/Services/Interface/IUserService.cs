using Tournonamemt.Models;
using Tournonamemt.Models.DTO;

namespace Tournonamemt.Services.Interface
{
    public interface IUserService
    {
        Task<User?> Get(int playerId);
        Task<User?> Create(UserCreateDto playerCreateDto);
    }
}
