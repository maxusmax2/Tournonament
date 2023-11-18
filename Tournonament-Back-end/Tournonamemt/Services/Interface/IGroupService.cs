using Tournonamemt.Models;

namespace Tournonamemt.Services.Interface
{
    public interface IGroupService
    {
        Group CreateGroupMatches(Group group);
        Tournament CloseGroups(Tournament tournament);
    }
}
