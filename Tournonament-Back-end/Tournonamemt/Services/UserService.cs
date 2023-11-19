using Tournonamemt.Models;
using Tournonamemt.Models.DTO;
using Tournonamemt.Repository.Interface;
using Tournonamemt.Security.Interface;
using Tournonamemt.Services.Interface;

namespace Tournonamemt.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _playerRepository;
        private readonly IRegistrationManager _registrationManager;
        public UserService(IUserRepository playerRepository, IRegistrationManager registrationManager)
        {
            _playerRepository = playerRepository;
            _registrationManager = registrationManager;
        }

        public async Task<User?> Create(UserCreateDto playerCreateDto)
        {
            var user = new User(playerCreateDto);
            _registrationManager.Registration(user, user.Password);

            _playerRepository.Save(user);
            return user;
        }

        public async Task<User?> Get(int playerId)
        {
            return await _playerRepository.GetAsync(playerId);
        }
    }
}
