using Tournonamemt.Models;

namespace Tournonamemt.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int playerId);
        Task<User> Save(User player);
        Task Update(User player);
        Task<User?> GetByLoginAsync(string login);
        Task<List<Match>> GetMatchies(int userId);
        Task<List<Tournament>> GetTournaments(int userId);
    }
}
