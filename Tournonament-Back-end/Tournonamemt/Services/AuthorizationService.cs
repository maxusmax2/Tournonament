using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tournonamemt.Models;
using Tournonamemt.Services.Interface;


namespace Tournonamemt.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly string key;


        public AuthorizationService(string key)
        {
            this.key = key;
        }
        public string Authenticate(User user, string password)
        {

            bool verify = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!verify)
            {
                throw new ArgumentException("WRONG PASSWORD");
            }

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
            return tokenHandler.WriteToken(token);
        }

    }
}
