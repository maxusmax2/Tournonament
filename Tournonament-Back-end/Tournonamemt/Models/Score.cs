namespace Tournonamemt.Models
{
    public class Score
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
