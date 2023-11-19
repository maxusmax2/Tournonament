using Tournonamemt.Models;
using Tournonamemt.Repository.Interface;

namespace Tournonamemt.Repository.Mock
{
    public class TournamentRepositoryMock : ITournamentRepository
    {
        private static Dictionary<int, Tournament> storage;
        private readonly IMatchRepository _matchRepository;

        public TournamentRepositoryMock(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        static TournamentRepositoryMock()
        {
            storage = new Dictionary<int, Tournament>();
            storage[0] = new Tournament();
        }

        public async Task<List<Tournament>> GetAllAsync(int pageNumber, int pageSize)
        {
            return storage.Values.Skip(pageNumber).Take(pageSize).ToList();
        }

        public async Task<Tournament?> GetAsync(int tournamentId)
        {
            return storage[tournamentId];
        }

        public async Task<Tournament?> SaveAsync(Tournament tournament)
        {
            if (tournament.Id == 0)
            {
                var newId = storage.Keys.Max() + 1;
                storage[newId] = tournament;
                tournament.Id = newId;
                return tournament;
            }
            storage[tournament.Id] = tournament;

            foreach (var tours in tournament.Bracket.Tours)
            {
                foreach (var match in tours.Matches)
                {
                    _matchRepository.SaveAsync(match);
                }
            }
            if (tournament.Groups != null)
            {
                foreach (var group in tournament.Groups)
                {
                    foreach (var match in group.Matchs)
                    {
                        _matchRepository.SaveAsync(match);
                    }
                }
            }
            return tournament;
        }
    }
}
