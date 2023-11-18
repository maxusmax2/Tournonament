using System.Text.Json.Serialization;

namespace Tournonamemt.Models
{
    public class Player
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
    }
}
