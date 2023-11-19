using Tournonamemt.Models;

namespace Tournonamemt.Services.Interface
{
    public interface IAuthorizationService
    {
        public string Authenticate(User user, string password);
    }
}
