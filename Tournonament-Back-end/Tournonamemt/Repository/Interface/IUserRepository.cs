using Tournonamemt.Models;

namespace Tournonamemt.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int playerId);
        Task<User> Save(User player);
    }
}
