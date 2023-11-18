using Tournonamemt.Models;

namespace Tournonamemt.Repository.Interface
{
    public interface IPlayerRepository
    {
        Task<Player> GetPlayerAsync(int playerId);
    }
}
