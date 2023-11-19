using Tournonamemt.Models;

namespace Tournonamemt.Security.Interface
{
    public interface IRegistrationManager
    {
        void Registration(User player, string password);
    }
}
