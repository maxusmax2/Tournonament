using Tournonamemt.Models;
using Tournonamemt.Repository.Interface;
using Tournonamemt.Services.Interface;

namespace Tournonamemt.Services
{
    public class GroupService : IGroupService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IGroupRepository _groupRepository;
        public GroupService(ITourRepository tourRepository, IGroupRepository groupRepository)
        {
            _tourRepository = tourRepository;
            _groupRepository = groupRepository;
        }
        public Group CreateGroupMatches(Group group)
        {
            int matchCounter = 1;
            for (int i = 0; i < group.ParticipantNumber; i++)
            {
                var firstParticipant = group.Participants[i];
                for (int j = i + 1; j < group.ParticipantNumber; j++)
                {
                    var secondParticipant = group.Participants[j];
                    var match = new Match
                    {
                        Participants = new List<User> { firstParticipant, secondParticipant },
                        TournamentId = group.TournamentId,
                        IsGroupStep = true,
                        Number = matchCounter,
                        ParticipantNumber = 2,
                    };
                    matchCounter++;
                    group.Matchs.Add(match);
                }
            }
            return group;
        }

        public async Task<Tournament> CloseGroups(Tournament tournament)
        {
            var groups = new List<Group>();
            foreach (var group in tournament.Groups)
            {
                groups.Add(await _groupRepository.GetAsync(group.Id));

            }
            var PlayersInGroupByScore = groups
                .ToDictionary(g => g.GroupNumber,
                            g => g.Participants
                            .OrderBy(p => g.Matchs
                                .Where(x => x.Participants.Contains(p))
                                .Count(x => x.Scores.MaxBy(x => x.Value).PlayerId == p.Id))
                            .Select((p, i) => new { p, i })
                            .ToDictionary(x => x.i, x => x.p));

            var tour = await _tourRepository.GetAsync(tournament.Bracket.Tours.FirstOrDefault(x => x.TourNumber == 1).Id);
            var matchCounter = 0;
            for (int i = 1; i < tournament.GroupNumber; i += 2)
            {
                var firstGroup = PlayersInGroupByScore[i];
                var secondGroup = PlayersInGroupByScore[i + 1];
                for (int j = 0; j <= tournament.numberLeavingTheGroup - 1; j++)
                {
                    var match = tour.Matches[matchCounter];
                    match.Participants.Add(firstGroup[j]);
                    match.Participants.Add(secondGroup[tournament.numberLeavingTheGroup.Value - 1 - j]);
                    matchCounter++;
                }
            }
            return tournament;
        }

        private int GetClosestPowerOf2(int number)
        {
            int powerOf2 = 1;
            while (powerOf2 < number)
            {
                powerOf2 = powerOf2 << 1; // shift 'powerOf2' left by 1 bit
            }
            return powerOf2;
        }
    }
}
