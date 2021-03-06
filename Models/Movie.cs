using System;
using System.Collections.Generic;

namespace JAP_TASK_1_WEB_API.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverImage { get; set; }
        public List<CastMember> Cast { get; set; }
        public double Rating { get; set; }
        public List<Rating> RatingList { get; set; }
        public bool IsMovie { get; set; }
    }
}