using Tournonamemt.Models;
using Tournonamemt.Models.DTO;
using Tournonamemt.Repository.Interface;
using Tournonamemt.Services.Interface;

namespace Tournonamemt.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGroupService _groupService;
        private readonly IBracketService _bracketService;
        private readonly IMatchRepository _matchRepository;
        private readonly ITourRepository _tourRepository;
        private readonly IFileService _fileService;

        public TournamentService(ITournamentRepository tournamentRepository, IUserRepository userRepository, IGroupService groupService, IBracketService bracketService, IMatchRepository matchRepository, ITourRepository tourRepository, IFileService fileService)
        {
            _tournamentRepository = tournamentRepository;
            _userRepository = userRepository;
            _groupService = groupService;
            _bracketService = bracketService;
            _matchRepository = matchRepository;
            _tourRepository = tourRepository;
            _fileService = fileService;
        }

        public async Task<Tournament?> AddParticipantAsync(int playerId, int tournamentId)
        {
            var tournament = await _tournamentRepository.GetAsync(tournamentId);
            if (tournament is null)
                return null;

            var player = await _userRepository.GetAsync(playerId);
            if (player is null)
                return null;

            if (tournament.ParticipantNumber >= tournament.ParticipantNumberMax)
                return null;

            tournament.Participants.Add(player);
            tournament.ParticipantNumber++;

            await _tournamentRepository.Update(tournament);

            return tournament;
        }

        public async Task<Tournament?> CloseMatchAsync(CloseMatchRequestDto request)
        {
            var tournament = await _tournamentRepository.GetAsync(request.TournamentId);
            if (tournament is null) return null;

            var match = await _matchRepository.GetAsync(request.MatchId);
            if (match.status == Models.Enums.MatchStatus.Finish)
            {
                return null;
            }
            if (match is null) return null;

            foreach (var score in request.ScoreList)
            {
                var player = await _userRepository.GetAsync(score.PlayerId);
                if (player is null) return null;
                match.Scores.Add(new Score { PlayerId = score.PlayerId, Value = score.Score, Player = player });
            }

            match.status = Models.Enums.MatchStatus.Finish;

            if (match.IsGroupStep == false)
            {
                await _bracketService.CalcCloseMatch(tournament, match);
            }

            await _tournamentRepository.Update(tournament);
            return tournament;
        }

        public async Task<Tournament?> CreateTournamentAsync(TournamentCreateDto tournamentDto)
        {
            var tournament = new Tournament(tournamentDto);
            if (tournament.WithGroupStep && tournament.GroupNumber <= 0)
                return null;
            tournament.ImageUrl = await _fileService.UploadTournamentImage(tournamentDto.image);
            await _tournamentRepository.SaveAsync(tournament);
            return tournament;
        }

        public async Task<Tournament?> DeclineTournamentAsync(int tournamentId)
        {
            var tournament = await _tournamentRepository.GetAsync(tournamentId);
            if (tournament is null)
                return null;

            if (tournament.Status == TournamentStatus.End)
                return null;
            tournament.Status = TournamentStatus.Decline;
            await _tournamentRepository.Update(tournament);
            return tournament;
        }

        public async Task<Tournament?> GetTournamentAsync(int tournamentId)
        {
            return await _tournamentRepository.GetAsync(tournamentId);
        }

        public async Task<List<Tournament>> GetTournamentsAsync(int pageNumber, int pageSize)
        {
            return await _tournamentRepository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<Tournament?> RemoveParticipantAsync(int playerId, int tournamentId)
        {

            var tournament = await _tournamentRepository.GetAsync(tournamentId);
            if (tournament is null || tournament.Status == TournamentStatus.Decline)
                return null;

            var player = tournament.Participants.FirstOrDefault(x => x.Id == playerId);
            if (player is null)
                return null;

            tournament.Participants.Remove(player);
            tournament.ParticipantNumber--;
            if (tournament.ParticipantNumber < 0) tournament.ParticipantNumber = 0;
            await _tournamentRepository.Update(tournament);
            return tournament;
        }
        public async Task<Tournament?> CloseParticipantRecruitmentAsync(int tournamentId)
        {
            var tournament = await _tournamentRepository.GetAsync(tournamentId);

            if (tournament is null || tournament.Status == TournamentStatus.Decline) return null;
            if (tournament.Status == TournamentStatus.CloseRecruitment) return null;

            tournament.Status = TournamentStatus.CloseRecruitment;
            if (tournament.WithGroupStep)
            {
                var participantCountLivingFromGroup = GetClosestPowerOf2(tournament.ParticipantNumber / tournament.GroupNumber.Value);
                tournament.numberLeavingTheGroup = participantCountLivingFromGroup;
                FillTournamentTours(tournament, participantCountLivingFromGroup * tournament.GroupNumber.Value);
                FillGroupsOfPlayers(tournament, participantCountLivingFromGroup);
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

            await _tournamentRepository.Update(tournament);
            return tournament;
        }
        public async Task<Tournament?> CloseGroupsAsync(int tournamentId)
        {
            var tournament = await _tournamentRepository.GetAsync(tournamentId);
            if (tournament is null || tournament.Status == TournamentStatus.Decline) return null;

            if (tournament.Groups.Any(x => x.Matchs.Any(x => x.status != Models.Enums.MatchStatus.Finish)))
            {
                return null;
            }
            await _groupService.CloseGroups(tournament);
            await _tournamentRepository.Update(tournament);
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

            while (participantsNumber >= 2)
            {
                participantsNumber /= 2;
                n++;
            }
            return n;
        }


        private Tournament FillTournamentTours(Tournament tournament, int participantNumber)
        {
            var numberOfTour = GetTourNumberOfParticipants(participantNumber);

            tournament.Bracket.TourNumber = numberOfTour;
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
                    tour.Matches.Add(new Match { TournamentId = tournament.Id, IsGroupStep = false, Number = i + 1, Tour = tour, });
                }
                matchCountInTour /= 2;
            }
            return tournament;
        }
        private Tournament FillGroupsOfPlayers(Tournament tournament, int participantCountLivingFromGroup)
        {
            int counterParticipants = 0;

            foreach (var group in tournament.Groups)
            {
                group.ParticipantNumber = participantCountLivingFromGroup;
                group.Participants.AddRange(tournament.Participants.ToArray()[counterParticipants..(counterParticipants + participantCountLivingFromGroup)]);
                counterParticipants += participantCountLivingFromGroup;
            }
            return tournament;
        }

        public async Task<List<Tournament>> GetTournamentByDesciplineName(string name, int pageNumber, int pageGize)
        {
            return await _tournamentRepository.GetByDesciplineName(name, pageNumber, pageGize);
        }

        public async Task<List<Tournament>> GetTournamentByName(string name, int pageNumber, int pageGize)
        {
            return await _tournamentRepository.GetTournamentByName(name, pageNumber, pageGize);
        }
    }
}
