using Tournonamemt.Models;
using Tournonamemt.Security.Interface;

namespace Tournonamemt.Security
{
    public class RegistrationManager : IRegistrationManager
    {
        public void Registration(User user, string password)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
