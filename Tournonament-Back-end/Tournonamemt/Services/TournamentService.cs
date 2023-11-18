using Tournonamemt.Models;
using Tournonamemt.Models.DTO;
using Tournonamemt.Repository.Interface;
using Tournonamemt.Services.Interface;

namespace Tournonamemt.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IGroupService _groupService;
        private readonly IBracketService _bracketService;
        private readonly IMatchRepository _matchRepository;

        public TournamentService(ITournamentRepository tournamentRepository, IPlayerRepository playerRepository, IGroupService groupService, IBracketService bracketService, IMatchRepository matchRepository)
        {
            _tournamentRepository = tournamentRepository;
            _playerRepository = playerRepository;
            _groupService = groupService;
            _bracketService = bracketService;
            _matchRepository = matchRepository;
        }

        public async Task<Tournament?> AddParticipantAsync(int playerId, int tournamentId)
        {
            var tournament = await _tournamentRepository.GetTournamentAsync(tournamentId);
            if (tournament is null)
                return null;

            var player = await _playerRepository.GetPlayerAsync(playerId);
            if (player is null)
                return null;

            if (tournament.ParticipantNumber >= tournament.ParticipantNumberMax)
                return null;

            tournament.Participants.Add(player);
            tournament.ParticipantNumber++;

            await _tournamentRepository.SaveTournament(tournament);

            return tournament;
        }

        public async Task<Tournament?> CloseMatch(CloseMatchRequestDto request)
        {
            var tournament = await _tournamentRepository.GetTournamentAsync(request.TournamentId);
            if (tournament is null) return null;

            var match = await _matchRepository.GetMatchAsync(request.MatchId);
            if (match is null) return null;

            foreach (var score in request.ScoreList)
            {
                var currentScore = match.Scores.FirstOrDefault(x => x.PlayerId == score.PlayerId);
                if (currentScore is null) continue;
                currentScore.Value = score.Value;
            }
            match.status = Models.Enums.MatchStatus.Finish;

            if (match.IsGroupStep == false)
            {
                await _bracketService.CalcCloseMatch(tournament.Bracket, match);
            }

            await _tournamentRepository.SaveTournament(tournament);
            return tournament;
        }

        public async Task<Tournament> CreateTournamentAsync(TournamentCreateDto tournamentDto)
        {
            var tournament = new Tournament(tournamentDto);
            await _tournamentRepository.SaveTournament(tournament);
            return tournament;
        }

        public async Task<Tournament?> DeclineTournamentAsync(int tournamentId)
        {
            var tournament = await _tournamentRepository.GetTournamentAsync(tournamentId);
            if (tournament is null)
                return null;

            tournament.Status = TournamentStatus.Decline;
            await _tournamentRepository.SaveTournament(tournament);
            return tournament;
        }

        public async Task<Tournament?> GetTournamentAsync(int tournamentId)
        {
            return await _tournamentRepository.GetTournamentAsync(tournamentId);
        }

        public async Task<List<Tournament>> GetTournamentsAsync(int pageNumber, int pageSize)
        {
            return await _tournamentRepository.GetTournamentsAsync(pageNumber, pageSize);
        }

        public async Task<Tournament?> RemoveParticipantAsync(int playerId, int tournamentId)
        {
            var tournament = await _tournamentRepository.GetTournamentAsync(tournamentId);
            if (tournament is null)
                return null;

            var player = tournament.Participants.FirstOrDefault(x => x.Id == playerId);
            if (player is null)
                return null;

            if (tournament.ParticipantNumber >= tournament.ParticipantNumberMax)
                return null;
            tournament.Participants.Remove(player);
            tournament.ParticipantNumber--;

            await _tournamentRepository.SaveTournament(tournament);

            return tournament;
        }
        public async Task<Tournament?> closeParticipantRecruitment(int tournamentId)
        {
            var tournament = await _tournamentRepository.GetTournamentAsync(tournamentId);

            if (tournament is null) return null;
            if (tournament.WithGroupStep)
            {
                var participantCountLivingFromGroup = GetClosestPowerOf2(tournament.Groups.Select(x => x.ParticipantNumber).MinBy(x => x));
                FillTournamentTours(tournament, participantCountLivingFromGroup * tournament.GroupNumber.Value);
                foreach (var group in tournament.Groups)
                {
                    _groupService.CreateGroupMatches(group);
                }
            }
            else if (tournament.Format == TournamentFormat.Knockout)
            {
                FillTournamentTours(tournament, GetClosestPowerOf2(tournament.ParticipantNumber));
                _bracketService.CreateBracketMatches(tournament);
            }

            await _tournamentRepository.SaveTournament(tournament);
            return tournament;
        }
        public async Task<Tournament?> CloseGroups(int tournamentId)
        {
            var tournament = await _tournamentRepository.GetTournamentAsync(tournamentId);
            if (tournament is null) return null;

            if (tournament.Groups.Any(x => x.Matchs.Any(x => x.status != Models.Enums.MatchStatus.Finish)))
            {
                return null;
            }
            _groupService.CloseGroups(tournament);
            await _tournamentRepository.SaveTournament(tournament);
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

        private int GetTourNumberOfParticipants(int participantsNumber)
        {
            int n = 0;

            while (participantsNumber <= 2)
            {
                participantsNumber /= 2;
                n++;
            }
            return n;
        }


        private Tournament FillTournamentTours(Tournament tournament, int participantNumber)
        {
            var numberOfTour = GetTourNumberOfParticipants(participantNumber);

            for (int i = 1; i <= numberOfTour; i++)
            {
                tournament.Bracket.Tours.Add(new Tour { TourNumber = i });
            }

            var matchCountInTour = participantNumber / 2;
            foreach (var tour in tournament.Bracket.Tours)
            {
                tour.Matches = new();
                tour.MatchNumber = matchCountInTour;
                for (int i = 0; i < matchCountInTour; i++)
                {
                    tour.Matches.Add(new Match { TournamentId = tournament.Id, IsGroupStep = false, Number = i + 1 });
                }
                matchCountInTour /= 2;
            }
            return tournament;
        }

    }
}
