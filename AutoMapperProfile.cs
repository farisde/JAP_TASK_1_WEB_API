using AutoMapper;
using MovieBuff.DTOs.Movie;
using MovieBuff.Models;

namespace MovieBuff
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Media, GetMovieDto>();
            CreateMap<CastMember, GetCastMemberDto>();
            CreateMap<Rating, GetRatingDto>();
            CreateMap<AddRatingDto, Rating>();
        }
    }
}