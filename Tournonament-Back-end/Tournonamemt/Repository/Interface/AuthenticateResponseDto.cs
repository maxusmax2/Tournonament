using Tournonamemt.Models;

namespace Tournonamemt.Repository.Interface
{
    public record AuthenticateResponseDto(User User, string token);
}
