using Tournonamemt.Models;

namespace Tournonamemt.Repository.Mock
{
    public class UserRepositoryMock
    {
        private static Dictionary<int, User> storage;
        static UserRepositoryMock()
        {
            storage = new Dictionary<int, User>();
            storage[0] = new User();
            storage[1] = new User() { Id = 1, NickName = "user1", Role = "player" };
            storage[2] = new User() { Id = 2, NickName = "user2", Role = "player" };
            storage[3] = new User() { Id = 3, NickName = "user3", Role = "player" };
            storage[4] = new User() { Id = 4, NickName = "user4", Role = "player" };
            storage[5] = new User() { Id = 5, NickName = "user5", Role = "player" };
            storage[6] = new User() { Id = 6, NickName = "user6", Role = "player" };
            storage[7] = new User() { Id = 7, NickName = "user7", Role = "player" };
            storage[8] = new User() { Id = 8, NickName = "user8", Role = "player" };
            storage[9] = new User() { Id = 9, NickName = "user9", Role = "player" };
            storage[10] = new User() { Id = 10, NickName = "user10", Role = "player" };
            storage[11] = new User() { Id = 11, NickName = "user11", Role = "player" };
            storage[12] = new User() { Id = 12, NickName = "user12", Role = "player" };
            storage[13] = new User() { Id = 13, NickName = "user13", Role = "player" };
            storage[14] = new User() { Id = 14, NickName = "user14", Role = "player" };
            storage[15] = new User() { Id = 15, NickName = "user15", Role = "player" };
            storage[16] = new User() { Id = 16, NickName = "user16", Role = "player" };
        }
        public async Task<User> GetAsync(int playerId)
        {
            return storage[playerId];
        }

        public async Task Save(User player)
        {
            if (player.Id == 0)
            {
                var newId = storage.Keys.Max() + 1;
                storage[newId] = player;
                player.Id = newId;
                return;
            }
            storage[player.Id] = player;
        }
    }
}
