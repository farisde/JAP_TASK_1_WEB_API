using MovieBuff.DTOs.Movie;
using MovieBuff.Models;
using System.Threading.Tasks;

namespace MovieBuff.Services.RatingService
{
    public interface IRatingService
    {
        Task<ServiceResponse<GetRatingDto>> AddMovieRating(AddRatingDto newRating);
    }
}
