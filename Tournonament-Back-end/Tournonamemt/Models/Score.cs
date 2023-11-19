namespace Tournonamemt.Models
{
    public class Score
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int PlayerId { get; set; }
        public User Player { get; set; }
    }
}
