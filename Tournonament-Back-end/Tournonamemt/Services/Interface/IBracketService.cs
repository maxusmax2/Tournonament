using Tournonamemt.Models;

namespace Tournonamemt.Services.Interface
{
    public interface IBracketService
    {
        public Tournament CreateBracketMatches(Tournament tournament);
        Task<bool> CalcCloseMatch(Tournament tournament, Match match);

    }
}
