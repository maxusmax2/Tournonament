using System.Text.Json.Serialization;
using Tournonamemt.Models.DTO;

namespace Tournonamemt.Models
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public DateTime Birthday { get; set; }
        public string AboutMe { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
        public string ImageUrl { get; set; }


        public User() { }
        public User(UserCreateDto playerCreateDto)
        {
            Id = playerCreateDto.Id;
            NickName = playerCreateDto.NickName;
            Birthday = playerCreateDto.Birthday;
            AboutMe = playerCreateDto.AboutMe;
            Password = playerCreateDto.Password;
            Login = playerCreateDto.Login;
            Role = playerCreateDto.Role;

        }
    }
}
