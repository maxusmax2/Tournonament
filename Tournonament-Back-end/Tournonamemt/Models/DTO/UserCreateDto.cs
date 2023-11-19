namespace Tournonamemt.Models.DTO
{
    public class UserCreateDto
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public DateTime Birthday { get; set; }
        public string AboutMe { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
    }
}
