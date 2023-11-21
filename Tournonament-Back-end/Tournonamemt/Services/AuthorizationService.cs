using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tournonamemt.Repository.Interface;
using Tournonamemt.Services.Interface;


namespace Tournonamemt.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly string key = "lectureTest1234$lectureTest1234$";
        private readonly IUserRepository _userRepository;

        public AuthorizationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AuthenticateResponseDto> Authenticate(string login, string password)
        {
            var user = await _userRepository.GetByLoginAsync(login);
            if (user is null) return null;
            bool verify = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!verify) return null;

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("Id", user.Id.ToString())

                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticateResponseDto(user, tokenHandler.WriteToken(token));
        }

    }
}
