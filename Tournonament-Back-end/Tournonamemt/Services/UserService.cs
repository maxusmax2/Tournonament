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
            if (await _playerRepository.GetByLoginAsync(playerCreateDto.Login) is not null) return null;
            var user = new User(playerCreateDto);

            _registrationManager.Registration(user, user.Password);

            await _playerRepository.Save(user);
            return user;
        }

        public async Task<User?> Get(int playerId)
        {
            var user = await _playerRepository.GetAsync(playerId);
            return user;
        }
    }
}
