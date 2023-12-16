using Tournonamemt.Models;
using Tournonamemt.Repository.Interface;
using Tournonamemt.Services.Interface;

namespace Tournonamemt.Services
{
    public class BracketService : IBracketService
    {
        private readonly ITourRepository _tourRepository;
        public BracketService(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }
        public Tournament CreateBracketMatches(Tournament tournament)
        {
            var firstTour = tournament.Tours.First(x => x.TourNumber == 1);

            var playerCounter = 0;
            foreach (var match in firstTour.Matches)
            {
                match.ParticipantNumber = 2;
                match.Participants.Add(tournament.Participants[playerCounter]);
                match.Participants.Add(tournament.Participants[playerCounter + 1]);
                playerCounter += 2;
            }
            return tournament;

        }
        public async Task<bool> CalcCloseMatch(Tournament tournament, Match match)
        {
            if (tournament.Format == TournamentFormat.Knockout)
            {
                await CalcKnockout(tournament, match);
            }
            else if (tournament.Format == TournamentFormat.DoubleElimination)
            {
                return false;//Не будет в прототипе
            }

            return true;
        }

        private async Task<bool> CalcKnockout(Tournament tournament, Match match)
        {
            var winner = match.Scores.MaxBy(x => x.Value)?.Player;
            var currentTour = match.Tour.TourNumber;
            if (tournament.TourNumber == currentTour)
            {
                tournament.Winner = winner;
                return true;
            }
            var nextMatchNumber = Math.Ceiling(match.Number / 2.0);
            var nextTour = await _tourRepository.GetAsync(tournament.Tours.FirstOrDefault(x => x.TourNumber == currentTour + 1).Id);

            var nextMatch = nextTour.Matches.FirstOrDefault(x => x.Number == nextMatchNumber);
            nextMatch.Participants.Add(winner);
            return true;
        }
    }
}
