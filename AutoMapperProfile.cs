using AutoMapper;
using JAP_TASK_1_WEB_API.DTOs.Movie;
using JAP_TASK_1_WEB_API.Models;

namespace JAP_TASK_1_WEB_API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movie, GetMovieDto>();
            CreateMap<CastMember, GetCastMemberDto>();
            CreateMap<Rating, GetRatingDto>();
        }
    }
}