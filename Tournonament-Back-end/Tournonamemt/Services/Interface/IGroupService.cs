using Tournonamemt.Models;

namespace Tournonamemt.Services.Interface
{
    public interface IGroupService
    {
        Group CreateGroupMatches(Group group);
        Task<Tournament> CloseGroups(Tournament tournament);
        Task<List<Group>> GetTournamentsGroupsAsync(int tournamentId);
    }
}
