using Tournonamemt.Models;
using Tournonamemt.Services.Interface;

namespace Tournonamemt.Services
{
    public class BracketService : IBracketService
    {

        public Tournament CreateBracketMatches(Tournament tournament)
        {
            var firstTour = tournament.Bracket.Tours.First(x => x.TourNumber == 1);

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
        public async Task<bool> CalcCloseMatch(Bracket bracket, Match match)
        {
            if (bracket.Tournament.Format == TournamentFormat.Knockout)
            {
                await CalcKnockout(bracket, match);
            }
            else if (bracket.Tournament.Format == TournamentFormat.DoubleElimination)
            {
                return false;//Не будет в прототипе
            }

            return true;
        }

        private async Task<bool> CalcKnockout(Bracket bracket, Match match)
        {
            var winner = match.Scores.MaxBy(x => x.Value)?.Player;
            var currentTour = match.Tour.TourNumber;
            if (bracket.TourNumber == currentTour)
            {
                bracket.Tournament.Winner = winner;
                return true;
            }
            var nextMatchNumber = Math.Ceiling(match.Number / 2.0);
            var nextTour = bracket.Tours.FirstOrDefault(x => x.TourNumber == currentTour + 1);

            var nextMatch = nextTour.Matches.FirstOrDefault(x => x.Number == nextMatchNumber);
            match.Participants.Add(winner);
            match.Scores.Add(new Score { Player = winner, PlayerId = winner.Id });
            return true;
        }
    }
}
