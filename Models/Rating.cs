namespace JAP_TASK_1_WEB_API.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public Movie RatedMovie { get; set; }
        public int RatedMovieId { get; set; }
    }
}