using Tournonamemt.Models;
using Tournonamemt.Services.Interface;

namespace Tournonamemt.Services
{
    public class GroupService : IGroupService
    {
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
                        Participants = new List<Player> { firstParticipant, secondParticipant },
                        TournamentId = group.TournamentId,
                        IsGroupStep = true,
                        Number = matchCounter,
                        ParticipantNumber = 2,
                        Scores = new List<Score>
                        {
                        new Score {Player = firstParticipant},
                        new Score {Player = secondParticipant}
                    }
                    };
                    matchCounter++;
                    group.Matchs.Add(match);
                }
            }
            return group;
        }

        public Tournament CloseGroups(Tournament tournament)
        {
            var PlayersInGroupByScore = tournament.Groups.
                ToDictionary(g => g.GroupNumber,
                            g => g.Participants
                            .OrderBy(p => g.Matchs
                                .Where(x => x.Participants.Contains(p))
                                .Count(x => x.Scores.MaxBy(x => x.Value).PlayerId == p.Id))
                            .Select((p, i) => new { p, i })
                            .ToDictionary(x => x.i, x => x.p));

            var participantCountLivingFromGroup = GetClosestPowerOf2(tournament.Groups.Select(x => x.ParticipantNumber).MinBy(x => x));
            var tour = tournament.Bracket.Tours.FirstOrDefault(x => x.TourNumber == 1);
            var matchCounter = 0;
            for (int i = 1; i < tournament.GroupNumber; i += 2)
            {
                var firstGroup = PlayersInGroupByScore[i];
                var secondGroup = PlayersInGroupByScore[i + 1];
                for (int j = 1; j <= participantCountLivingFromGroup; j++)
                {
                    var match = tour.Matches[matchCounter];
                    match.Participants.Add(firstGroup[j]);
                    match.Participants.Add(secondGroup[participantCountLivingFromGroup + 1 - j]);
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
