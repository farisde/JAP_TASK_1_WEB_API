using MovieBuff.Models;
using System;
using System.Collections.Generic;

namespace MovieBuff.DTOs.Movie
{
    public class GetMediaDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverImage { get; set; }
        public List<GetCastMemberDto> Cast { get; set; }
        public double Rating { get; set; }
        public List<GetRatingDto> RatingList { get; set; }
        public MediaType MediaType { get; set; }
    }
}