using Tournonamemt.Repository.Interface;

namespace Tournonamemt.Services.Interface
{
    public interface IAuthorizationService
    {
        public Task<AuthenticateResponseDto> Authenticate(string login, string password);
    }
}
