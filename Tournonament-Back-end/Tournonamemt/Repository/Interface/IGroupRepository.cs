using Tournonamemt.Models;

namespace Tournonamemt.Repository.Interface
{
    public interface IGroupRepository
    {
        Task<Group> GetAsync(int groupId);
        Task<List<Group>> GetTournamentsGroupsAsync(int tournamentId);
    }
}
