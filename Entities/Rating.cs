namespace MovieBuff.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public Media RatedMedia { get; set; }
        public int RatedMediaId { get; set; }
        public User User { get; set; }
    }
}