using System;
using System.Collections.Generic;
using JAP_TASK_1_WEB_API.Models;

namespace JAP_TASK_1_WEB_API.DTOs.Movie
{
    public class GetMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverImage { get; set; }
        public List<GetCastMemberDto> Cast { get; set; }
        public double Rating { get; set; }
        public List<GetRatingDto> RatingList { get; set; }
        public bool IsMovie { get; set; }
    }
}